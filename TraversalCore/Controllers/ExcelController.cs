using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TraversalCore.Models;

namespace TraversalCore.Controllers
{
    [AllowAnonymous]
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells[1, 1].Value = "Rota";
            worksheet.Cells[1, 2].Value = "Rehber";
            worksheet.Cells[1, 3].Value = "Kontenjan";

            worksheet.Cells[2, 1].Value = "Gürcistan - Batum Turu";
            worksheet.Cells[2, 2].Value = "Kadir Yıldız";
            worksheet.Cells[2, 3].Value = "50";

            worksheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            worksheet.Cells[3, 2].Value = "Zeynep Öztürk";
            worksheet.Cells[3, 3].Value = "35";

            var bytes = excel.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet", "dosya1.xlsx");
        }
        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity

                }).ToList();
            }

            return destinationModels;
        }
        public IActionResult DestinationExcelReport()  //veritabanındaki verileri excele aktar
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowcount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowcount, 1).Value = item.City;
                    workSheet.Cell(rowcount, 2).Value = item.DayNight;
                    workSheet.Cell(rowcount, 3).Value = item.Price;
                    workSheet.Cell(rowcount, 4).Value = item.Capacity;
                    rowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}   
