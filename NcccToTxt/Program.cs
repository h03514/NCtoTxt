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
                    {
                        path = @"D:\\桌面\\新增資料夾 (4)\\ddd\\1.txt";
                        
                        // 建立TXT檔
                        using (FileStream fs = File.Create(path,1024))
                        {
                            fs.Close();
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

                                StreamWriter swr = new StreamWriter(@"D:\桌面\新增資料夾 (4)\ddd\" + "1.txt", false, Encoding.Default);
                                swr.WriteLine("abc");
                                swr.WriteLine("馬克張");
                                swr.WriteLine("234,#$%");
                                swr.Close();
                                swr.Dispose();
                            }
                            sr.Close();
                        }

                        Console.WriteLine("D:\\桌面\\新增資料夾 (4)\\" + line.ToString());
                        //File.Move();
                        FileMove("D:\\桌面\\新增資料夾 (4)\\" + line.ToString(), "D:\\桌面\\新增資料夾 (4)\\done\\" + line.ToString());
                       
                        // 轉ANSI
                        //new StreamWriter((@"D:\桌面\新增資料夾 (4)\ddd\" + "1.txt").Replace(".txt", "-ansi.txt"), false, Encoding.ASCII);

                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
