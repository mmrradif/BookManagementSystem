using AspNetCore.Reporting;
//using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
//using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using PracticalExam.Database_Context;
using PracticalExam.Database_Models;
using System.Reflection.Metadata.Ecma335;
using System.Data;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using DocumentFormat.OpenXml.Spreadsheet;
using PracticalExam.Repositories;
using System.Data.SqlClient;
using ClosedXML.Excel;

namespace PracticalExam.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment host;
        private readonly BookDbContext db;

        public ReportController(IWebHostEnvironment host,  BookDbContext db)
        {
            this.host = host;
            this.db = db;   
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }


        public IActionResult Report()
        {
            return View();
        }

        public IActionResult GenerateReportPdf(DateTime startDate, DateTime endDate)
        {
            var dt = new DataTable();
            dt = GetBookInfo(startDate, endDate);

            string mimeType = "";
            int extension = 1;
            var path = $"{host.WebRootPath}\\Reports\\rptBooks.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm1", "DUPL");
            parameters.Add("prm2", "Mirpur-1, Dhaka");
            parameters.Add("prm3", "Outbook List");
            parameters.Add("prm4", "Page");

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsBooks", dt);

            var res = localReport.Execute(RenderType.Pdf, extension,parameters,mimeType);
            return File(res.MainStream, "application/pdf");
        }


        string constr = "Server=.;Database=BookDb;Trusted_Connection=True";
        public DataTable GetBookInfo(DateTime startDate, DateTime endDate)
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("spGetBookInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate;

                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                con.Close();
            }
            return dt;
        }






        //[HttpPost]
        //public IActionResult DownloadExcel(DateTime fromDate, DateTime toDate)
        //{
        //    // Query the database to get the books within the date range
        //    var books = db.tblBook
        //    .Where(b => b.Date >= fromDate && b.Date <= toDate)
        //    .ToList();

        //    // If there are no books within the date range, return a message to the user
        //    if (books.Count == 0)
        //    {
        //        //return Content("No data found within the specified date range.");

        //        TempData["Message"] = "No data found within the specified date range.";
        //        TempData["MessageType"] = "alert-warning";
        //        return RedirectToAction("Report");

        //    }

        //    // Create a new Excel workbook
        //    XLWorkbook workbook = new XLWorkbook();

        //    // Add a new worksheet to the workbook
        //    IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet1");

        //    // Set the header row
        //    worksheet.Cell(1, 1).Value = "Id";
        //    worksheet.Cell(1, 2).Value = "Date";
        //    worksheet.Cell(1, 3).Value = "Book Name";
        //    worksheet.Cell(1, 4).Value = "Author";
        //    worksheet.Cell(1, 5).Value = "Quantity";

        //    // Set the header row style to bold and centered
        //    worksheet.Row(1).Style.Font.Bold = true;
        //    worksheet.Row(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        //    // Set the data style to centered
        //    var dataRange = worksheet.Range("A2:E" + (books.Count + 1).ToString());
        //    dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        //    // Set the column width of "Book Name" to fit the text
        //    worksheet.Column(2).Width = 10;
        //    worksheet.Column(3).Width = 30;
        //    worksheet.Column(4).Width = 20;
        //    worksheet.Column(5).Width = 15;


        //    // Add data to the worksheet
        //    int row = 2;
        //    foreach (var book in books)
        //    {
        //        worksheet.Cell(row, 1).Value = book.Id;
        //        worksheet.Cell(row, 2).Value = book.Date;
        //        worksheet.Cell(row, 3).Value = book.BookName;
        //        worksheet.Cell(row, 4).Value = book.Author;
        //        worksheet.Cell(row, 5).Value = book.Quantity;
        //        row++;
        //    }

        //    // Set the response headers
        //    Response.Headers.Add("Content-Disposition", $"attachment; filename=\"ExcelReport.xlsx\"");
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //    // Write the workbook to the response stream
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        workbook.SaveAs(memoryStream);
        //        memoryStream.WriteTo(Response.Body);
        //    }

        //    return new EmptyResult();
        //}



        [HttpPost]
        public IActionResult DownloadExcel(DateTime startDate, DateTime endDate)
        {
            var books = db.tblBook
                .Where(b => b.Date >= startDate && b.Date <= endDate)
                .ToList();

            if (books.Count == 0)
            {
                TempData["Message"] = "No data found within the specified date range.";
                TempData["MessageType"] = "alert-warning";
                return RedirectToAction("Report");
            }

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");

            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Date";
            worksheet.Cell(1, 3).Value = "Book Name";
            worksheet.Cell(1, 4).Value = "Author";
            worksheet.Cell(1, 5).Value = "Quantity";

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var dataRange = worksheet.Range("A2:E" + (books.Count + 1).ToString());
            dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            worksheet.Column(2).Width = 10;
            worksheet.Column(3).Width = 30;
            worksheet.Column(4).Width = 20;
            worksheet.Column(5).Width = 15;

            int row = 2;
            foreach (var book in books)
            {
                worksheet.Cell(row, 1).Value = book.Id;
                worksheet.Cell(row, 2).Value = book.Date;
                worksheet.Cell(row, 3).Value = book.BookName;
                worksheet.Cell(row, 4).Value = book.Author;
                worksheet.Cell(row, 5).Value = book.Quantity;
                row++;
            }

            Response.Headers.Add("Content-Disposition", $"attachment; filename=\"ExcelReport.xlsx\"");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.Body);
            }

            return new EmptyResult();
        }

    }
}



