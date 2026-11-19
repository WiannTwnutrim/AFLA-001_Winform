using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                using var parser = new TextFieldParser(filePath);
                parser.SetDelimiters(",");//透過,分割
                parser.ReadFields();//讀標題

                while (!parser.EndOfData)//只要沒有更多資料可讀取
                {
                    var field = parser.ReadFields();
                    if (field == null || field.Length < 4) continue;//如果是空白或是不滿4列(di只有四列)跳過
                    string ionumber = field[0].Trim();
                    if (string.IsNullOrEmpty(ionumber)) continue;
                    string ioname = field[1].Trim();
                    string plcpoint = field[3].Trim();// plcpoint 例如 "DI[0]"、"DI[10]" 或 "DO[35]"
                    

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
                            IOnumber = ionumber,
                            IOname = ioname,
                            PlcPonit = plcpoint,
                            //IOname_English = worksheet.Cell(row, 3).GetString(),
                            Index = index //取出索引的值
                        };
                        ioList.Add(DI);
                    }
                    else if (plcpoint.StartsWith("DO"))
                    {
                        string dovariabe = field[4].Trim();
                        if (string.IsNullOrEmpty(dovariabe)) continue;
                        IOModel DO = new IOModel
                        {
                            IOnumber = ionumber,
                            IOname = ioname,
                            PlcPonit = plcpoint,
                            //IOname_English = worksheet.Cell(row, 3).GetString(),
                            Variable = dovariabe,
                            Index = index
                        };
                        ioList.Add(DO);
                    }                    
                }
                return ioList;
            }
            catch(Exception ex)
            {
                throw new FormatException(ex.ToString());
            }
        }
    }
}






