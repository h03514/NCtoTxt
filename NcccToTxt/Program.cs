using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

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


                string pattern = @"\b\w*I87+\w*\b";


                foreach (var line in di.GetFiles("*"))
                {
                    Match m = Regex.Match(line.Name, pattern);

                    if(m.Success)
                    //if (line.Name == "test(1).txt")
                    {
                        path = @"D:\\桌面\\新增資料夾 (4)\\ddd\\1.txt";

                        // Create the file, or overwrite if the file exists.
                        using (FileStream fs = File.Create(path))
                        {
                           
                            List<string> lists = new List<string>();

                           
                            fs.Close();

                            //System.Globalization.TaiwanCalendar tc = new System.Globalization.TaiwanCalendar();

                            //DateTime d = DateTime.Now;
                            //var abc = new DateTime(2012,2,29);
                            //Console.WriteLine(tc.GetYear(abc).ToString());
                            //Console.WriteLine(tc.GetMonth(abc).ToString("00"));
                            //Console.WriteLine(tc.GetDayOfMonth(abc).ToString("00"));
                            //string salesDate = String.Format( tc.GetYear(abc).ToString()+tc.GetMonth(d).ToString("00")+tc.GetDayOfMonth(d).ToString("00"));
                            ////Console.WriteLine(salesDate.ToString());

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
                        // Open the stream and read it back.
                        using (StreamReader sr = new StreamReader(@"D:\桌面\新增資料夾 (4)\" + line.Name))
                        {
                            DataTable dt = new DataTable();
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                string aa = s.Substring(0, 3);
                                string bb = s.Substring(3, 7);

                                if (aa == "0CF")
                                {
                                    //dt.Rows.Add(new object[] { "1".PadRight(5) + aa.PadRight(10) + bb });
                                }

                                if (aa == "0CH")
                                {
                                    //dt.Rows.Add(new object[] { "2".PadRight(5) + aa.PadRight(10) + bb });
                                }

                                if (aa == "0CE")
                                {
                                    //dt.Rows.Add(new object[] { "3".PadRight(5) + aa.PadRight(10) + bb });
                                }


                            }
                            
                            //swr.WriteLine(srr.ReadToEnd());
                            sr.Close();

                        }

                        //using (StreamReader srr = new StreamReader(@"D:\桌面\新增資料夾 (4)\ddd\" + "1.txt"))
                        //{
                        //    StreamWriter swr = new StreamWriter(@"D:\桌面\新增資料夾 (4)\ddd\" + "1.txt", false, Encoding.Default);

                        //    // invoke the ReadToEnd method
                        //    swr.WriteLine(srr.ReadToEnd());

                        //    swr.Close();
                        //    srr.Close();
                        //}



                        Console.WriteLine("D:\\桌面\\新增資料夾 (4)\\" + line.ToString());
                        //File.Move();
                        FileMove("D:\\桌面\\新增資料夾 (4)\\" + line.ToString(), "D:\\桌面\\新增資料夾 (4)\\done\\" + line.ToString());
                        new StreamWriter((@"D:\桌面\新增資料夾 (4)\ddd\" + "1.txt").Replace(".txt", "-ansi.txt"), false, Encoding.ASCII);

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

        public static void FileMove(string source, string dest)
        {
            try
            {
                File.Move(source, dest);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
