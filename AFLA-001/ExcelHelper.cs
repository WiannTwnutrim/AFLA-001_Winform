using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLA_001
{
    public class ExcelHelper
    {
        public List<IOModel> LoadIO(string filePath)
        {
            // 建立 List，存放讀取到的 IO 資料
            List<IOModel> ioList = new List<IOModel>();

            // 開啟 Excel
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                //指定要讀取的工作表，名稱必須與 Excel 一致。
                var worksheet = workbook.Worksheet("IO_test");

                // 取得最後一個有資料的列號
                int lastRow = worksheet.LastRowUsed().RowNumber();

                // 從第 2 列開始，第 1 列是標題
                for (int row = 2; row <= lastRow; row++)
                {
                    string ioNumber = worksheet.Cell(row, 1).GetString().Trim();

                    // IO 編號空白就跳過
                    if (string.IsNullOrWhiteSpace(ioNumber))
                        continue;

                    // 建立 IOModel 物件
                    IOModel io = new IOModel
                    {
                        IOnumber = ioNumber,
                        IOname = worksheet.Cell(row, 2).GetString(),
                        IOname_English = worksheet.Cell(row, 3).GetString(),
                        PLCStatus = Convert.ToBoolean(worksheet.Cell(row, 4).GetValue<int>())
                    };

                    // 加入 List
                    ioList.Add(io);
                }
            }

            return ioList;
        }
    }
}
