using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Reflection;

namespace Library.SerialPorts
{
    public class RS232 : ASerialPort
    {
        public override void Dispose()
        {
            Close();

            base.Dispose();
        }

        #region Close, Open

        public virtual void Close()
        {
            if (_SerialPort != null)
            {
                _SerialPort.Close();
                _SerialPort.Dispose();
                _SerialPort = null;

                LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Close OK ({0})", _PortName));
            }
        }

        public virtual bool Open()
        {
            try
            {
                if (_SerialPort == null)
                {
                    _SerialPort = new SerialPort(_PortName, _BaudRate, _Parity, _DataBits, _StopBits);

                    _SerialPort.ReadBufferSize = _ReadBufferSize;
                    _SerialPort.WriteBufferSize = _WriteBufferSize;

                    _SerialPort.Open();

                    if (IsOpen)
                    {
                        _SerialPort.ReadTimeout = _ReadTimeout;
                        _SerialPort.WriteTimeout = _WriteTimeout;

                        _ReadBuffer = new byte[_ReadBufferSize];
                    }
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }

            LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Open {0} ({1})", IsOpen ? "OK" : "NG", _PortName));

            //if (IsOpen == false)
            //{
            //    Close();
            //}

            return IsOpen;
        }

        #endregion

        #region Read

        /// <summary>
        /// Internal Read
        /// </summary>
        public bool Read(ref byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                int count = _SerialPort.Read(_ReadBuffer, 0, _ReadBuffer.Length);

                if (result = count > 0)
                {
                    bytes = new byte[count];

                    Array.Copy(_ReadBuffer, bytes, count);
                }

                if (result && logEnabled)
                {
                    LogWrite(string.Format("{0}::{1}", call, MethodBase.GetCurrentMethod().Name), Utility.GetCommString(bytes));
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        public bool Read(ref string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                byte[] bytes = null;

                if (result = Read(ref bytes, call, logEnabled))
                {
                    str = Encoding.Default.GetString(bytes);
                }

                if (result && logEnabled)
                {
                    LogWrite(string.Format("{0}::{1}", call, MethodBase.GetCurrentMethod().Name), Utility.GetCommString(str));
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        #endregion

        #region Write

        /// <summary>
        /// Internal Write
        /// </summary>
        public bool Write(byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                _SerialPort.Write(bytes, 0, bytes.Length);

                result = true;

                if (result && logEnabled)
                {
                    LogWrite(string.Format("{0}::{1}", call, MethodBase.GetCurrentMethod().Name), Utility.GetCommString(bytes));
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        public bool Write(string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = Write(Encoding.Default.GetBytes(str), call, logEnabled);

                if (result && logEnabled)
                {
                    LogWrite(string.Format("{0}::{1}", call, MethodBase.GetCurrentMethod().Name), Utility.GetCommString(str));
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        #endregion
    }
}
