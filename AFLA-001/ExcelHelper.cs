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
                //指定要讀取的工作表，名稱必須與 Excel 一致(excel內分頁名稱)
                var worksheet = workbook.Worksheet("IO表");

                // 取得最後一個有資料的列號
                int lastRow = worksheet.LastRowUsed().RowNumber();


                // 從第 2 列開始，第 1 列是標題
                for (int row = 2; row <= lastRow; row++)
                {

                    string ioNumber = worksheet.Cell(row, 1).GetString().Trim();
                    // IO 編號空白就跳過
                    if (string.IsNullOrWhiteSpace(ioNumber))
                        continue;
                    string plcpoint = worksheet.Cell(row, 4).GetString().Trim();
                    // plcpoint 例如 "DI[0]"、"DI[10]" 或 "DO[35]"
                    int start = plcpoint.IndexOf('[');
                    int end = plcpoint.IndexOf(']');

                    //Substring取值,index從0開始(起始位置,取幾個)
                    if (start < 0 || end <= start ||
                        !int.TryParse(
                            plcpoint.Substring(start + 1, end - start - 1),
                            out int index))
                    {
                        throw new FormatException($"IO 綁定格式錯誤：{plcpoint}");

                    }

                    // 建立 IOModel 物件
                    if (plcpoint.StartsWith("DI"))
                    {
                        IOModel DI = new IOModel
                        {
                            IOnumber = ioNumber,
                            IOname = worksheet.Cell(row, 2).GetString(),
                            PlcPonit = plcpoint,
                            //IOname_English = worksheet.Cell(row, 3).GetString(),
                            Index = index //取出索引的值
                        };
                        ioList.Add(DI);
                    }
                    else if (plcpoint.StartsWith("DO"))
                    {
                        IOModel DO = new IOModel
                        {
                            IOnumber = ioNumber,
                            IOname = worksheet.Cell(row, 2).GetString(),
                            PlcPonit = plcpoint,
                            //IOname_English = worksheet.Cell(row, 3).GetString(),
                            Variable = worksheet.Cell(row, 5).GetString(),
                            Index = index
                        };
                        ioList.Add(DO);
                    }
                }
            }
            return ioList;
        }
    }
}
