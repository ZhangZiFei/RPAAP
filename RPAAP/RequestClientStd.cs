using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPAAP
{
    /// <summary>
    /// RPA Action 标准输入输出 请求端
    /// </summary>
    class RequestClientStd : RequestClient
    {
        public RequestClientStd(string processPath)
        {
            Console.InputEncoding = Tool.DefEncoding;
            Console.OutputEncoding = Tool.DefEncoding;
            Process = new Process()
            {
                StartInfo = new ProcessStartInfo(processPath)
                {
                    UseShellExecute = true,//不使用系統shell啟動
                    RedirectStandardInput = true,//接受調用持續的輸入
                    RedirectStandardOutput = true,//調用程序可獲取輸出
                    RedirectStandardError = true,//重定向標準錯誤輸出
                    CreateNoWindow = true//不使用window窗口打開
                }
            };
            Process.StartInfo.StandardOutputEncoding = Tool.DefEncoding;
            Process.StartInfo.StandardErrorEncoding = Tool.DefEncoding;
            Process.StartInfo.UseShellExecute = false;
            Process.Start();
        }

        ~RequestClientStd()
        {
            Process.Dispose();
            Process.Close();
        }

        protected override ResponseData Request(RequestData requestData)
        {
            var s = JsonConvert.SerializeObject(requestData);
            Console.WriteLine("------------------Request---------requestData--------------");
            Console.WriteLine(s);
            Process.StandardInput.WriteLine(s);
            var s2 = Process.StandardOutput.ReadLine();
            return JsonConvert.DeserializeObject<ResponseData>(s2);
        }

        private readonly Process Process;
    }
}
