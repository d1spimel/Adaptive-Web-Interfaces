using ClosedXML.Excel;
using LR8.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR8.Services
{
    public class VersionService : IVersionService
    {
        public int GetFirstVersion()
        {
            int number = new Random().Next();
            return number;
        }

        public string GetSecondVersion()
        {
            return "Second Version was getted!";
        }

        public byte[] GetThirdVersion()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("API Version");

                worksheet.Cell("A1").Value = "Name";
                worksheet.Cell("A2").Value = "Version";
                worksheet.Cell("A3").Value = "Description";

                worksheet.Cell("B1").Value = "GetVersion1";
                worksheet.Cell("B2").Value = 1.0;
                worksheet.Cell("B3").Value = "Return number.";

                worksheet.Cell("C1").Value = "GetVersion2";
                worksheet.Cell("C2").Value = 2.0;
                worksheet.Cell("C3").Value = "Return text.";

                worksheet.Cell("D1").Value = "GetVersion3";
                worksheet.Cell("D2").Value = 3.0;
                worksheet.Cell("D3").Value = "Return EXCEL file.";

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
