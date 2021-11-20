using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAAP
{
    public static class Tool
    {
        public static Encoding DefEncoding = Encoding.Unicode;//Default;//

        /// <summary>
        /// 转换字符串编码
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="originalEncode">原编码</param>
        /// <param name="targetEncode">目标编码</param>
        /// <returns>转换编码后的字符串</returns>
        public static string TransferStr(this string str, Encoding originalEncode, Encoding targetEncode)
        {
            byte[] unicodeBytes = originalEncode.GetBytes(str);
            byte[] asciiBytes = Encoding.Convert(originalEncode, targetEncode, unicodeBytes);
            char[] asciiChars = new char[targetEncode.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            targetEncode.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string result = new string(asciiChars);
            return result;
        }

        /// <summary>
        /// 从标准输入输出中读取一行
        /// 查考链接 https://xiu2.net/it/details/60f105837919366004f7232b
        /// </summary>
        /// <param name="READLINE_BUFFER_SIZE">缓冲区大小</param>
        /// <returns></returns>
        public static string ReadLine(int READLINE_BUFFER_SIZE = 1000)
        {
            Stream inputStream = Console.OpenStandardInput(READLINE_BUFFER_SIZE);
            byte[] bytes = new byte[READLINE_BUFFER_SIZE];
            int outputLength = inputStream.Read(bytes, 0, READLINE_BUFFER_SIZE);

            for (int i = outputLength - 1; i >= 0; --i)
            {
                if (bytes[i].Equals((byte)'\r') || bytes[i].Equals((byte)'\n'))
                {
                    --outputLength;
                }
                else
                {
                    break;
                }
            }

            char[] chars = Console.InputEncoding.GetChars(bytes, 0, outputLength);
            return new string(chars);
        }
    }
}
