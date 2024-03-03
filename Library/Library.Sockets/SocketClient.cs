using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace Library.Sockets
{
    public class SocketClient : ASocketClient
    {
        public override void Dispose()
        {
            Disconnect();

            base.Dispose();
        }

        #region Disconnect, Connect

        public virtual void Disconnect()
        {
            if (_Client != null)
            {
                _Client.Close();
                _Client.Dispose();
                _Client = null;

                LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Disconnect OK ({0}:{1})", _IP, _Port));
            }
        }

        public virtual bool Connect()
        {
            try
            {
                if (_Client == null)
                {
                    switch (_ClientType)
                    {
                        case ProtocolType.Tcp:
                            _Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            break;


                        case ProtocolType.Udp:
                            _Client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                            _ServerEP = new IPEndPoint(IPAddress.Parse(_IP), _Port);
                            break;
                    }

                    _Client.ReceiveBufferSize = _ReceiveBufferSize;
                    _Client.SendBufferSize = _SendBufferSize;

                    IAsyncResult ar = _Client.BeginConnect(IPAddress.Parse(_IP), _Port, null, null);

                    if (ar.AsyncWaitHandle.WaitOne(_ConnectTimeout, false))
                    {
                        if (_Client != null)
                        {
                            _Client.EndConnect(ar);

                            _Client.ReceiveTimeout = _ReceiveTimeout;
                            _Client.SendTimeout = _SendTimeout;

                            _ReceiveBuffer = new byte[_ReceiveBufferSize];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }

            LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Connect {0} ({1}:{2})", IsConnected ? "OK" : "NG", _IP, _Port));

            //if (IsConnected == false)
            //{
            //    Disconnect();
            //}

            return IsConnected;
        }

        #endregion

        #region Receive

        /// <summary>
        /// Internal Receive
        /// </summary>
        public bool Receive(ref byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                int count = _Client.Receive(_ReceiveBuffer, 0, _ReceiveBuffer.Length, SocketFlags.None);

                if (result = count > 0)
                {
                    bytes = new byte[count];

                    Array.Copy(_ReceiveBuffer, bytes, count);
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

        public bool Receive(ref string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                byte[] bytes = null;

                if (result = Receive(ref bytes, call, logEnabled))
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

        #region ReceiveFrom

        /// <summary>
        /// Internal ReceiveFrom
        /// </summary>
        public bool ReceiveFrom(ref byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint remoteEP = (EndPoint)sender;

                int count = _Client.ReceiveFrom(_ReceiveBuffer, 0, _ReceiveBuffer.Length, SocketFlags.None, ref remoteEP);

                if (result = count > 0)
                {
                    bytes = new byte[count];

                    Array.Copy(_ReceiveBuffer, bytes, count);
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

        public bool ReceiveFrom(ref string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                byte[] bytes = null;

                if (result = ReceiveFrom(ref bytes, call, logEnabled))
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

        #region Send

        /// <summary>
        /// Internal Send
        /// </summary>
        public bool Send(byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = _Client.Send(bytes, 0, bytes.Length, SocketFlags.None) == bytes.Length;

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

        public bool Send(string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = Send(Encoding.Default.GetBytes(str), call, logEnabled);

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

        #region SendTo

        /// <summary>
        /// Internal SendTo
        /// </summary>
        public bool SendTo(byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = _Client.SendTo(bytes, 0, bytes.Length, SocketFlags.None, _ServerEP) == bytes.Length;

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

        public bool SendTo(string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = SendTo(Encoding.Default.GetBytes(str), call, logEnabled);

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
