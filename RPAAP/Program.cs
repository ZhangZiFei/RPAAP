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
            new ResponseClientStd();//RequestClientStdTest();//
            //JsonTest();
            //Test();
        }

        static void RequestClientStdTest()
        {
            var p = Tool.R.Request("a", "b", new Dictionary<string, Param>
            {
                { "a", new Param("说說发發\na") }
            });
            Console.WriteLine(p["a"].Value);
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
