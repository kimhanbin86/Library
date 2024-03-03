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
    public class SocketClientAsync : ASocketClient
    {
        public delegate void RecvBytesEventHandler(byte[] bytes);
        public delegate void RecvStringEventHandler(string str);

        public override void Dispose()
        {
            Disconnect();

            if (RecvBytesEvent != null)
            {
                foreach (Delegate del in RecvBytesEvent.GetInvocationList())
                {
                    RecvBytesEvent -= (RecvBytesEventHandler)del;
                }
            }

            if (RecvStringEvent != null)
            {
                foreach (Delegate del in RecvStringEvent.GetInvocationList())
                {
                    RecvStringEvent -= (RecvStringEventHandler)del;
                }
            }

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
                    _Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    _Client.ReceiveBufferSize = _ReceiveBufferSize;
                    _Client.SendBufferSize = _SendBufferSize;

                    IAsyncResult ar = _Client.BeginConnect(IPAddress.Parse(_IP), _Port, null, null);

                    if (ar.AsyncWaitHandle.WaitOne(_ConnectTimeout, false))
                    {
                        _Client.EndConnect(ar);

                        //_Client.ReceiveTimeout = _ReceiveTimeout;
                        _Client.SendTimeout = _SendTimeout;

                        _ReceiveBuffer = new byte[_ReceiveBufferSize];

                        _Client.BeginReceive(_ReceiveBuffer, 0, _ReceiveBuffer.Length, SocketFlags.None, AsyncCallback_Receive, _Client);
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

        #region AsyncCallback

        private void AsyncCallback_Receive(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;

            try
            {
                int count = socket.EndReceive(ar);

                if (count > 0)
                {
                    #region RecvBytesEvent

                    byte[] bytes = new byte[count];

                    Array.Copy(_ReceiveBuffer, bytes, count);

                    LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetCommString(bytes));

                    if (RecvBytesEvent != null)
                    {
                        RecvBytesEvent(bytes);
                    }

                    #endregion

                    #region RecvStringEvent

                    string str = Encoding.Default.GetString(bytes);

                    LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetCommString(str));

                    if (RecvStringEvent != null)
                    {
                        RecvStringEvent(str);
                    }

                    #endregion

                    socket.BeginReceive(_ReceiveBuffer, 0, _ReceiveBuffer.Length, SocketFlags.None, AsyncCallback_Receive, socket);
                }
                else
                {
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));

                Disconnect();
            }
        }

        #endregion

        #region 이벤트

        public event RecvBytesEventHandler RecvBytesEvent;
        public event RecvStringEventHandler RecvStringEvent;

        #endregion
    }
}
