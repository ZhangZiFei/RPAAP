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
            new ResponseClientStdTest();//RequestClientStdTest();//
            //JsonTest();
            //Test();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:删除未使用的私有成员", Justification = "<挂起>")]
        static void RequestClientStdTest()
        {
            var p = Tool.R.Request("a", "b", new Dictionary<string, Param>
            {
                { "a", new Param("说說发發\na") }
            });
            Console.WriteLine(p["a"].Value);
            Console.ReadLine();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:删除未使用的私有成员", Justification = "<挂起>")]
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

    class ResponseClientStdTest : ResponseClientStd
    {
        protected override ResponseData RunAction(RequestData requestData)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            throw new Exception("说说 說說");
            //return new ResponseData(new Dictionary<string, Param>() {
            //    { "ObjectName", new Param(requestData.ObjectName)},
            //    { "Action", new Param(requestData.Action)},
            //    { "test", new Param("说说 說說")},
            //    { "a", new Param((string)requestData.InputParams["a"].Value)}
            //});
        }
    }
}
