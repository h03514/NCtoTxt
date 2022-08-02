using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;

namespace NcccToTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"D:\桌面\新增資料夾 (4)\");
            string path = "";
            //foreach (var file in di.GetFiles("*.txt"))
            //{
            try
            {
                foreach (var line in di.GetFiles("*.txt"))
                {
                    if (line.Name == "test(1).txt")
                    {
                        path = @"D:\\桌面\\新增資料夾 (4)\\ddd\\1.txt";

                        // Create the file, or overwrite if the file exists.
                        using (FileStream fs = File.Create(path))
                        {
                           
                            List<string> lists = new List<string>();

                            // Open the stream and read it back.
                            using (StreamReader sr = File.OpenText(@"D:\桌面\新增資料夾 (4)\"+line.Name))
                            {
                                DataTable dt = new DataTable();
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    string aa = s.Substring(0, 3);
                                    string bb = s.Substring(3, 7);

                                    if (aa == "0CF")
                                    {
                                        dt.Rows.Add(new object[] { "1".PadRight(5) + aa.PadRight(10) + bb });
                                    }

                                    if (aa == "0CH")
                                    {
                                        dt.Rows.Add(new object[] { "2".PadRight(5) + aa.PadRight(10) + bb });
                                    }

                                    if (aa == "0CE")
                                    {
                                        dt.Rows.Add(new object[] { "3".PadRight(5) + aa.PadRight(10) + bb });

                                    }
                                    Console.WriteLine("1".PadRight(5)+aa.PadRight(10)+bb);
                                }
                            }


                            //if (aa.ToUpper() == "0FH")
                            //{
                            //    lists.Add("1" + aa.PadRight(5) + ab.PadRight(2) + ac.PadRight(5));
                            //    //string.Join("-", words);
                            //}
                            //byte[] info = new UTF8Encoding(true).GetBytes(lists.ToString());
                            //// Add some information to the file.
                            //fs.Write(info, 0, info.Length);
                            //Console.WriteLine("ad");
                        }

                    }


                    if (line.Name == "test(2).txt")
                    {
                        path = @"D:\\桌面\\新增資料夾 (4)\\ddd\\2.txt";
                    }
                }


               
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //}
        }
    }
}
