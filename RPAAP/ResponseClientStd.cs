using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAAP
{
    /// <summary>
    /// RPA Action 标准输入输出 响应端
    /// </summary>
    class ResponseClientStd : ResponseClient
    {
        public ResponseClientStd()
            : base()
        {

        }

        private const int READLINE_BUFFER_SIZE = 10000000;

        protected override RequestData Request()
        {
            //string s = Tool.ReadLine(READLINE_BUFFER_SIZE);
            string s =Console.ReadLine();

            if (s.Length == 0)
            {
                Console.WriteLine("EXIT");
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<RequestData>(s);
            }
        }

        protected override ResponseData RunAction(RequestData requestData)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            return new ResponseData(new Dictionary<string, Param>() {
                { "ObjectName", new Param(requestData.ObjectName)},
                { "Action", new Param(requestData.Action)},
                { "test", new Param("说说 說說")},
                { "a", new Param((string)requestData.InputParams["a"].Value)}
            });
        }

        protected override void Response(ResponseData responseData)
        {
            Console.WriteLine(JsonConvert.SerializeObject(responseData));
        }

        protected override void BeforeCreate()
        {
            base.BeforeCreate();

            Console.InputEncoding = Tool.DefEncoding;
            Console.OutputEncoding = Tool.DefEncoding;
        }
    }
}
