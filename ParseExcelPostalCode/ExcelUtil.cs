using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
