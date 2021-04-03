using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace SAPMouse
{
    public class ExcellHandling
    {
        public Workbook wb;
        public Worksheet ws;
        public _Application excelApplication;
        string filePath = @"D:\DoImportu2.xlsx";
        public ExcellHandling()
        {
            excelApplication = new _Excel.Application();
            wb = excelApplication.Workbooks.Open(filePath);
            ws = wb.Worksheets[1];
        }
        public string readCustNumber(int row)
        {
            var customerCell = ws.Cells[row, 1].Value;
            return customerCell.ToString();
        }
        public string readTeamNumber(int row)
        {
            var customerCell = ws.Cells[row, 2].Value;
            return customerCell.ToString();
        }
        public string readRegionNumber(int row)
        {
            var customerCell = ws.Cells[row, 3].Value;
            return customerCell.ToString();
        }
        public string readContactPersonNumber(int row)
        {
            var customerCell = ws.Cells[row, 4].Value;
            return customerCell.ToString();
        }
       
    }
}
