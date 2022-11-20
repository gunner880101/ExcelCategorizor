﻿using ClosedXML.Excel;
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
    }
}