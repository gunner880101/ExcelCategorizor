using ClosedXML.Excel;
using ParseExcelPostalCode.models;

namespace ParseExcelPostalCode
{
    public static class ExcelUtil
    {
        public static List<T> ImportExcel<T>(string excelFilePath, string sheetName)
        {
            List<T> list = new List<T>();
            Type typeOfObject = typeof(T);
            using (IXLWorkbook workbook = new XLWorkbook(excelFilePath))
            {
                var worksheet = workbook.Worksheets.Where(w => w.Name == sheetName).First();
                var properties = typeOfObject.GetProperties();
                // header column texts
                var columns = worksheet.FirstRow().Cells().Select((v, i) => new { Value = v.Value, Index = i + 1 });
                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                {
                    T? obj = (T?)Activator.CreateInstance(typeOfObject);
                    foreach (var prop in properties)
                    {
                        int colIndex = columns.SingleOrDefault(c => c.Value.ToString() == prop.Name.ToString()).Index;
                        var val = row.Cell(colIndex).Value;
                        var type = prop.PropertyType;
                        prop.SetValue(obj, Convert.ChangeType(val, type));
                    }
                    list.Add(obj);
                }
            }
            return list;
        }

        public static List<IndustryJob> FillEmptyCells(List<IndustryJob> list)
        {
            if (list.Count == 0) return list;

            var temp = list[0].Industry1;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].Industry1.Length == 0)
                {
                    list[i].Industry1 = temp;
                }
                else
                {
                    temp = list[i].Industry1;
                }
            }
            return list;
        }

        public static List<IndustryJob> SplitJobs(List<IndustryJob> list)
        {
            if (list.Count == 0) return list;
            List<IndustryJob> result = new List<IndustryJob>();
            foreach (var item in list)
            {
                var jobs = item.Job.Split(" ");
                foreach (string job in jobs)
                {
                    if (job.Length == 0 || job == "") continue;
                    IndustryJob newItem = new IndustryJob()
                    {
                        Industry1 = item.Industry1,
                        Industry2 = item.Industry2,
                        Job = job,
                    };
                    result.Add(newItem);
                }
            }
            return result;
        }

        public static List<Industry> GenerateIndustryRecordList(List<IndustryJob> industryJobs)
        {
            List<Industry> industries = new List<Industry>();
            uint currentId = 1;
            // generate first-level industries
            foreach (var item in industryJobs)
            {
                if (industries.Exists((industry) => industry.name == item.Industry1))
                {
                    continue;
                }
                var timestamp = (ulong)Utils.GetCurrentTimestamp();
                Industry temp = new Industry()
                {
                    id = currentId++,
                    name = item.Industry1,
                    pid = 0,
                    level = 1,
                    sort = 1,
                    create_time = timestamp,
                    update_time = timestamp,
                };
                industries.Add(temp);
            }
            // generate second-level industries
            foreach (var item in industryJobs)
            {
                if (industries.Exists((industry) => industry.name == item.Industry2))
                {
                    continue;
                }
                var timestamp = (ulong)Utils.GetCurrentTimestamp();
                uint pid = industries.Where((industry) => industry.name == item.Industry1).First().id;
                var temp = new Industry()
                {
                    id = currentId++,
                    name = item.Industry2,
                    pid = pid,
                    level = 2,
                    sort = 2,
                    create_time = timestamp,
                    update_time = timestamp,
                };
                industries.Add(temp);
            }
            return industries;
        }

        public static List<Job> GenerateJobRecordList(List<IndustryJob> industryJobs, List<Industry> industries)
        {
            List<Job> jobs = new List<Job>();
            uint currentId = 1;
            foreach (var item in industryJobs)
            {
                uint pid = industries.Where((industry) => industry.name == item.Industry2).First().id;
                var timestamp = (ulong)Utils.GetCurrentTimestamp();
                Job temp = new Job()
                {
                    id = currentId++,
                    name = item.Job,
                    pid = pid,
                    sort = 1,
                    create_time = timestamp,
                    update_time = timestamp,
                };
                jobs.Add(temp);
            }
            return jobs;
        }

        public static List<Industry> GenerateThirdIndustryRecordList(List<IndustryJob> industryJobs, List<Industry> industries)
        {
            List<Industry> jobs = new List<Industry>();
            uint currentId = 1;
            uint industryCount = (uint)industries.Count;
            foreach (var item in industryJobs)
            {
                uint pid = industries.Where((industry) => industry.name == item.Industry2).First().id;
                var timestamp = (ulong)Utils.GetCurrentTimestamp();
                Industry temp = new Industry()
                {
                    id = industryCount + currentId++,
                    name = item.Job,
                    pid = pid,
                    sort = 1,
                    level = 3,
                    create_time = timestamp,
                    update_time = timestamp,
                };
                jobs.Add(temp);
            }
            return jobs;
        }

        public static bool ExportAsExcelFile<T>(String filePath, String sheetName, List<T> list)
        {
            bool exported = false;
            using(IXLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(sheetName).FirstCell().InsertTable<T>(list, false);
                workbook.SaveAs(filePath);
                exported = true;
            }
            return exported;
        }
    }
}
