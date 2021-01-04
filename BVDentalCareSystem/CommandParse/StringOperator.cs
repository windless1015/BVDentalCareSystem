using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVDentalCareSystem.CommandParse
{
    class StringOperator
    {
        //string到byte[]转化函数，格式为 "00 01 00 01 00 01 00 00" 转为 01010100 8位的byte[]
        public static byte[] ConvertStringToByteArray(string text)
        {
            byte[] tmpBytes = new byte[8];
            int j = 0;
            for (int i = 0; i < text.Length; i += 3)
            {
                tmpBytes[j] = Convert.ToByte(text.Substring(i, 2), 16);
                j++;
            }
            return tmpBytes;
        }

        //string到byte[]转化函数，格式为 "0001000100010000" 转为 01010100 8位的byte[]
        public static byte[] ConvertStringToByteArray2(string text)
        {
            byte[] tmpBytes = new byte[8];
            int j = 0;
            for (int i = 0; i < text.Length; i += 2)
            {
                tmpBytes[j] = Convert.ToByte(text.Substring(i, 2), 16);
                j++;
            }
            return tmpBytes;
        }

        //string到byte[]转化函数, 格式为"01000100" 转化为01000100的8位byte[]
        public static byte[] ConvertStringToHEXByte(string text)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            byte[] tmpBytes = enc.GetBytes(text);
            for (int i = 0; i < text.Length; i++)
            {
                tmpBytes[i] = Convert.ToByte(text.Substring(i, 1), 16);
            }
            return tmpBytes;
        }

        //01000100的8位byte[]转化为 " 0001000000010000"的string字符串
        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        //01000100的8位byte[]转化为 " 0001000000010000"的string字符串
        public static string ByteArrayToString2(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        //01000100的8位byte[]转化为 "01000100"的string字符串
        public static string ByteArrayToString3(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length);
            foreach (byte b in ba)
                hex.AppendFormat("{0:X1}", b);  //X1表示十六进制格式（大写），域宽1位
            return hex.ToString();
        }


        public static StringBuilder GetHexString(byte[] data, int offset, int length)
        {
            StringBuilder sb = new StringBuilder(length * 3);
            for (int i = offset; i < (offset + length); i++)
            {
                sb.Append(data[i].ToString("X2") + " ");  // 01 00 00 00 00 00 00 00   增加了一个空格
                //sb.Append(data[i].ToString("X2")); //0100000000000000
            }
            sb.Remove(sb.Length - 1, 1);//把最后一个空格去掉
            return sb;
        }


        //参考https://blog.csdn.net/ALLsharps/article/details/6996565
        public static int SearchFromBytes(ref byte[] searched, ref byte[] find, int start = 0)
        {
            bool matched = false;
            int end = find.Length - 1;
            int skip = 0;
            for (int index = start; index <= searched.Length - find.Length; ++index)
            {
                matched = true;
                if (find[0] != searched[index] || find[end] != searched[index + end]) continue;
                else skip++;
                if (end > 10)
                    if (find[skip] != searched[index + skip] || find[end - skip] != searched[index + end - skip])
                        continue;
                    else skip++;
                for (int subIndex = skip; subIndex < find.Length - skip; ++subIndex)
                {
                    if (find[subIndex] != searched[index + subIndex])
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched)
                {
                    return index;
                }
            }
            return -1;
        }

        //这个只是测试函数
        public static void TestByteToStringFuns()
        {
            byte[] t = new byte[8];
            t[0] = 1;
            string sss = GetHexString(t, 0, 8).ToString();  // 01 00 00 00 00 00 00 00
            string aaa = ByteArrayToString(t); // 0100000000000000
            string bbb = ByteArrayToString2(t); //0100000000000000
        }



        static public bool CompareByteArraysEqual(ref byte[] b1, ref byte[] b2)
        {
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }

        //判断前两个字节
        static public bool CompareFirstEightBytes(byte[] b1, ref byte[] b2)
        {
            if (b1 == null || b2 == null)
                return false;
            //if (b1.Length != b2.Length) 
            //    return false;
            for (int i = 0; i < 8; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }

        public static List<byte[]> SplitByteArray(ref byte[] givenBytes)
        {
            //需要分割的字符串的数量为 splitBytePos 的length + 1
            List<byte[]> result = new List<byte[]>();
            for (int offset = 0; offset < givenBytes.Length; offset = offset + 8)
            {
                byte[] buffer = new byte[8];
                Buffer.BlockCopy(givenBytes, offset, buffer, 0, 8);
                result.Add(buffer);

            }

            return result;
        }

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        public static string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        public static byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

    }
}
