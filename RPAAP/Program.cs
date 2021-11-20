using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;

/// <summary>
/// RPA Action 协议
/// </summary>
namespace RPAAP
{
    class Program
    {
        //static void Main(string[] args)
        static void Main()
        {
            RequestClientStdTest();//new ResponseClientStd();//
            //JsonTest();
            //Test();
        }

        static void RequestClientStdTest()
        {
            var r = new RequestClientStd(@"E:\zifeiobject\RPAAP\RPAAP\bin\Debug\ResponseClientStdTest.exe");
            var p = r.Request("a", "b", new Dictionary<string, Param>
            {
                { "a", new Param("说說\na") },
                { "b", new Param(233) },
                { "c", new Param(new DataTable
                        {
                            Columns = { "a","b","c" },
                            Rows = {
                                {1,1,1 },
                                {2,2,2 }
                            },
                        }
                    )
                }
            });
        }

        static void Test()
        {
            Console.InputEncoding = Tool.DefEncoding;
            Console.OutputEncoding = Tool.DefEncoding;
            //
            //Console.WriteLine("说说 說說");
            //Console.WriteLine(Tool.ReadLine());
            //Console.ReadLine();
            var bs_UTF8 = Encoding.UTF8.GetBytes("说說");
            var bs_Unicode = Encoding.Unicode.GetBytes("说說");
            var bs_ASCII = Encoding.ASCII.GetBytes("说說");
            var bs4_UTF32 = Encoding.UTF32.GetBytes("说說");
        }

        static void JsonTest()
        {
            var d = new Dictionary<string, Param>
            {
                { "a", new Param("说说 說說\n") },
                { "b", new Param(233) },
                { "c", new Param(new DataTable
                        {
                            Columns = { "a","b","c" },
                            Rows = {
                                {1,1,1 },
                                {2,2,2 }
                            },
                        }
                    )
                }
            };
            var r = new RequestData("q", "a", d);
            var s = JsonConvert.SerializeObject(r);

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(s);
            Console.WriteLine();

            var d2 = JsonConvert.DeserializeObject<RequestData>(s);
            Console.WriteLine(d2);
        }
    }
}
