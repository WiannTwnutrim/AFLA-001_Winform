using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AFLA_001
{
    public class ExcelHelper
    {
        public bool TryLoadActionCommands(string path, out List<Motion> result, out string error)
        {
            result = new List<Motion>();
            error = string.Empty;
            try
            {
                using var parser = new TextFieldParser(path);
                parser.SetDelimiters(",");

                string[]? header = parser.ReadFields();
                if (header == null || !header.SequenceEqual(
                        new[] { "Index", "PC寫入", "PC讀" }, StringComparer.OrdinalIgnoreCase))
                {
                    error = "功能 CSV 欄位須依序為 Index,PC寫入,PC讀。";
                    return false;
                }

                var motions = new List<Motion>();
                var indexes = new HashSet<int>();
                while (!parser.EndOfData)
                {
                    long line = parser.LineNumber;
                    string[]? fields = parser.ReadFields();
                    if (fields == null || fields.Length != 3 ||
                        !int.TryParse(fields[0], out int index) || index < 0 ||
                        string.IsNullOrWhiteSpace(fields[1]))
                    {
                        error = $"功能 CSV 第 {line} 列的索引或命令點位無效。";
                        return false;
                    }

                    if (!indexes.Add(index))
                    {
                        error = $"功能 CSV 第 {line} 列的 Index {index} 重複。";
                        return false;
                    }

                    motions.Add(new Motion
                    {
                        Index = index,
                        Writelabel = fields[1].Trim(),
                        Readlabel = fields[2].Trim()
                    });
                }

                result = motions;
                return true;
            }
            catch (Exception ex) when (IsCsvReadError(ex))
            {
                result.Clear();
                error = ex.Message;
                return false;
            }
        }
       

        public bool TryLoadIO(string filePath, out List<IOModel> result, out string error)
        {
            result = new List<IOModel>();
            error = string.Empty;
            List<IOModel> ioList = new List<IOModel>();
            try
            {
                using var parser = new TextFieldParser(filePath);
                parser.SetDelimiters(",");//透過,分割
                parser.ReadFields();//讀標題

                while (!parser.EndOfData)//只要沒有更多資料可讀取
                {
                    long line = parser.LineNumber;
                    var field = parser.ReadFields();
                    if (field == null || field.Length < 4) continue;//如果是空白或是不滿4列(di只有四列)跳過
                    string ionumber = field[0].Trim();
                    if (string.IsNullOrEmpty(ionumber)) continue;
                    string ioname = field[1].Trim();
                    int index = Convert.ToInt32(field[3].Trim());// 取index


                    //int start = plcpoint.IndexOf('[');
                    //int end = plcpoint.IndexOf(']');
                    
                    ////Substring取值,index從0開始(起始位置,取幾個)
                    //if (start < 0 || end <= start ||
                    //    !int.TryParse(
                    //        plcpoint.Substring(start + 1, end - start - 1),
                    //        out int index))
                    //{
                    //    error = $"IO CSV 第 {line} 列的綁定格式錯誤：{plcpoint}";
                    //    return false;

                    //}

                    // 建立 IOModel 物件
                    if (ionumber.StartsWith("DI"))
                    {
                        IOModel DI = new IOModel
                        {
                            IOnumber = ionumber,
                            IOname = ioname,
                            //IOname_English = worksheet.Cell(row, 3).GetString(),
                            Index = index //取出索引的值
                        };
                        ioList.Add(DI);
                    }
                    else if (ionumber.StartsWith("DO"))
                    {
                        if (field.Length < 5)
                        {
                            error = $"IO CSV 第 {line} 列缺少 DO 變數欄位。";
                            return false;
                        }

                        string dovariabe = field[4].Trim();
                        if (string.IsNullOrEmpty(dovariabe)) continue;
                        IOModel DO = new IOModel
                        {
                            IOnumber = ionumber,
                            IOname = ioname,
                            //IOname_English = worksheet.Cell(row, 3).GetString(),
                            Variable = dovariabe,
                            Index = index
                        };
                        ioList.Add(DO);
                    }                    
                }
                result = ioList;
                return true;
            }
            catch (Exception ex) when (IsCsvReadError(ex))
            {
                result.Clear();
                error = ex.Message;
                return false;
            }
        }

        private static bool IsCsvReadError(Exception ex)
        {
            return ex is IOException or UnauthorizedAccessException or MalformedLineException
                or ArgumentException or NotSupportedException;
        }
    }
}
