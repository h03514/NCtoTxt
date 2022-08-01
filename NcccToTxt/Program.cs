using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace NcccToTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"D:\桌面\新增資料夾 (4)\");
            string path = "";
            foreach (var file in di.GetFiles("*.txt"))
            {
                try
                {
                    foreach(string line in System.IO.File.ReadLines(file.FullName))
                    {
                        if (file.Name == "test(1).txt")
                        {
                            path = @"D:\\桌面\\新增資料夾 (4)\\ddd\\1.txt";

                            // Create the file, or overwrite if the file exists.
                            using (FileStream fs = File.Create(path))
                            {
                                // 前三碼
                                string aa = line.Substring(0, 3);

                                // 機構清算代碼
                                string ab = line.Substring(4, 7);

                                // 中心處理日 
                                string ac = line.Substring(11, 8);
                                List<string> lists = new List<string>();

                               
                                if (aa.ToUpper() == "OFH")
                                {
                                    lists.Add("1"+aa.PadRight(5)+ab.PadRight(2)+ac.PadRight(5));
                                    //string.Join("-", words);
                                }
                                byte[] info = new UTF8Encoding(true).GetBytes(lists.ToString());
                                // Add some information to the file.
                                fs.Write(info, 0, info.Length);
                                Console.WriteLine("ad");
                            }
                          
                        }


                        if (file.Name == "test(2).txt")
                        {
                            path = @"D:\\桌面\\新增資料夾 (4)\\ddd\\2.txt";
                        }
                    }
          

                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
