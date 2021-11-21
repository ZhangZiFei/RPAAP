using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RPAAP
{
    /// <summary>
    /// 响应数据
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ResponseData
    {
        /// <summary>
        /// 输入参数
        /// </summary>
        public Dictionary<string, Param> OutputParams => outputParams;

        /// <summary>
        /// 版本号
        /// </summary>
        public Version Version => version;

        /// <param name="outputParams">输出参数</param>
        public ResponseData(Dictionary<string, Param> outputParams)
        {
            this.outputParams = outputParams;
        }

        [JsonProperty]
        private readonly Version version = Tool.Version;

        [JsonProperty]
        private readonly Dictionary<string, Param> outputParams;
    }
}