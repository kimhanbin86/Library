using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Library
{
    public static class Utility
    {
        #region Convert

        public static byte ConvertBinaryToByte(string value)
        {
            byte result = byte.MinValue;
            try
            {
                result = ConvertHexToByte(ConvertBinaryToHex(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string ConvertBinaryToHex(string value)
        {
            string result = string.Empty;
            try
            {
                result = Convert.ToInt32(value, 2).ToString("X");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string ConvertByteToHex(byte[] value, int startIndex, int length)
        {
            string result = string.Empty;
            try
            {
                result = BitConverter.ToString(value, startIndex, length).Replace("-", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string ConvertDecimalToBinary(int value)
        {
            string result = string.Empty;
            try
            {
                result = Convert.ToString(value, 2).PadLeft(8, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string ConvertHexToASCII(string value)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < value.Length; i += 2)
                {
                    result += Convert.ToChar(Convert.ToInt32(value.Substring(i, 2), 16)).ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static byte ConvertHexToByte(string value)
        {
            byte result = byte.MinValue;
            try
            {
                result = Convert.ToByte(value, 16);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion

        public static string GetCommString(byte[] bytes)
        {
            string result = "[";
            try
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    result += string.Format("0x{0}", ConvertByteToHex(bytes, i, 1));

                    if (i < bytes.Length - 1)
                    {
                        result += " ";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result + "]";
        }
        public static string GetCommString(string value)
        {
            return string.Format("[{0}]", value);
        }

        public static string GetString(Exception ex)
        {
            return string.Format("try catch error (message=[{0}])", ex);
        }
        public static string GetString(object value)
        {
            return string.Format("{0}", value);
        }

        /// <summary>
        /// https://docs.microsoft.com/ko-kr/dotnet/api/system.net.networkinformation.ping?view=net-6.0
        /// </summary>
        /// <param name="IP">127.0.0.1</param>
        public static bool PingTest(string IP)
        {
            bool result = false;
            try
            {
                using (Ping pingSender = new Ping())
                {
                    #region PingOptions

                    PingOptions options = new PingOptions();

                    // Use the default Ttl value which is 128,
                    // but change the fragmentation behavior.
                    options.DontFragment = true;

                    #endregion

                    // Create a buffer of 32 bytes of data to be transmitted.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    PingReply reply = pingSender.Send(IPAddress.Parse(IP), timeout, buffer, options);

                    if (reply.Status == IPStatus.Success)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
