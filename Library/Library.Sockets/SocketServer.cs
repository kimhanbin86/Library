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
    public class SocketServer : ADevice
    {
        private struct ClientInfo
        {
            public Socket _Client;

            public byte[] _ReceiveBuffer;

            public string _IP;
            public string _Port;
        }

        public delegate void RecvBytesEventHandler(int clientIndex, byte[] bytes);
        public delegate void RecvStringEventHandler(int clientIndex, string str);

        #region 필드

        private Socket _Server = null;

        private bool _IsOpen = false;

        private string _IP = "127.0.0.1";
        private int _Port = 5200;

        private List<ClientInfo> _ClientList = null;

        private int _ReceiveBufferSize = 8192;

        private int _SendTimeout = 1000;
        private int _SendBufferSize = 8192;

        #endregion

        #region 속성

        public bool IsOpen
        {
            get
            {
                return _IsOpen;
            }
        }

        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
            }
        }
        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        public int ReceiveBufferSize
        {
            get
            {
                return _ReceiveBufferSize;
            }
            set
            {
                _ReceiveBufferSize = value;
            }
        }

        public int SendTimeout
        {
            get
            {
                return _SendTimeout;
            }
            set
            {
                _SendTimeout = value;
            }
        }
        public int SendBufferSize
        {
            get
            {
                return _SendBufferSize;
            }
            set
            {
                _SendBufferSize = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                return _ClientList.Count > 0;
            }
        }

        #endregion

        #region 메서드

        public SocketServer()
        {
            _ClientList = new List<ClientInfo>();
        }

        public override void Dispose()
        {
            Close();

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

        #region Close, Open

        public virtual void Close()
        {
            Disconnect();

            if (_Server != null)
            {
                _Server.Close();
                _Server.Dispose();
                _Server = null;

                _IsOpen = false;

                LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Server Close OK ({0}:{1})", _IP, _Port));
            }
        }
        public void Disconnect()
        {
            if (_ClientList.Count > 0)
            {
                for (int i = _ClientList.Count - 1; i >= 0; i--)
                {
                    Disconnect(i);
                }

                _ClientList.Clear();
            }
        }
        public void Disconnect(int clientIndex)
        {
            try
            {
                if (CheckClientIndex(clientIndex))
                {
                    if (_ClientList[clientIndex]._Client != null)
                    {
                        _ClientList[clientIndex]._Client.Close();
                        _ClientList[clientIndex]._Client.Dispose();

                        LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Client({0}:{1}) Disconnect OK", _ClientList[clientIndex]._IP, _ClientList[clientIndex]._Port));
                    }

                    _ClientList.RemoveAt(clientIndex);
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
        }

        public virtual bool Open()
        {
            try
            {
                if (_Server == null)
                {
                    _Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    _Server.Bind(new IPEndPoint(IPAddress.Parse(_IP), _Port));
                    _Server.Listen((int)SocketOptionName.MaxConnections);

                    _Server.BeginAccept(AsyncCallback_Accept, _Server);

                    _IsOpen = true;
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }

            LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Server Open {0} ({1}:{2})", _IsOpen ? "OK" : "NG", _IP, _Port));

            //if (_IsOpen == false)
            //{
            //    Close();
            //}

            return _IsOpen;
        }

        #endregion

        #region Send

        /// <summary>
        /// Internal Send
        /// </summary>
        public bool Send(int clientIndex, byte[] bytes, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = _ClientList[clientIndex]._Client.Send(bytes, 0, bytes.Length, SocketFlags.None) == bytes.Length;

                if (result && logEnabled)
                {
                    LogWrite(string.Format("{0}::{1}", call, MethodBase.GetCurrentMethod().Name), string.Format("Client({0}:{1})={2}", _ClientList[clientIndex]._IP, _ClientList[clientIndex]._Port, Utility.GetCommString(bytes)));
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        public bool Send(int clientIndex, string str, string call = "Method", bool logEnabled = true)
        {
            bool result = false;
            try
            {
                result = Send(clientIndex, Encoding.Default.GetBytes(str), call, logEnabled);

                if (result && logEnabled)
                {
                    LogWrite(string.Format("{0}::{1}", call, MethodBase.GetCurrentMethod().Name), string.Format("Client({0}:{1})={2}", _ClientList[clientIndex]._IP, _ClientList[clientIndex]._Port, Utility.GetCommString(str)));
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

        private void AsyncCallback_Accept(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;

            try
            {
                Socket client = server.EndAccept(ar);

                AddClient(client);

                int clientIndex = _ClientList.Count - 1;

                client.BeginReceive(_ClientList[clientIndex]._ReceiveBuffer, 0, _ClientList[clientIndex]._ReceiveBuffer.Length, SocketFlags.None, AsyncCallback_Receive, client);

                LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Client({0}:{1}) Connect OK", _ClientList[clientIndex]._IP, _ClientList[clientIndex]._Port));

                server.BeginAccept(AsyncCallback_Accept, server);
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));

                Close();
            }
        }

        private void AsyncCallback_Receive(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;

            try
            {
                int count = client.EndReceive(ar);

                int clientIndex = GetClientIndex(client);

                if (count > 0)
                {
                    byte[] bytes = new byte[count];

                    Array.Copy(_ClientList[clientIndex]._ReceiveBuffer, bytes, count);

                    LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Client({0}:{1})={2}", _ClientList[clientIndex]._IP, _ClientList[clientIndex]._Port, Utility.GetCommString(bytes)));

                    if (RecvBytesEvent != null)
                    {
                        RecvBytesEvent(clientIndex, bytes);
                    }

                    string str = Encoding.Default.GetString(bytes);

                    LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Client({0}:{1})={2}", _ClientList[clientIndex]._IP, _ClientList[clientIndex]._Port, Utility.GetCommString(str)));

                    if (RecvStringEvent != null)
                    {
                        RecvStringEvent(clientIndex, str);
                    }

                    client.BeginReceive(_ClientList[clientIndex]._ReceiveBuffer, 0, _ClientList[clientIndex]._ReceiveBuffer.Length, SocketFlags.None, AsyncCallback_Receive, client);
                }
                else
                {
                    Disconnect(clientIndex);
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));

                Disconnect(GetClientIndex(client));
            }
        }

        #endregion

        #region Method

        private void AddClient(Socket client)
        {
            try
            {
                ClientInfo clientInfo = new ClientInfo();

                clientInfo._Client = client;

                clientInfo._Client.ReceiveBufferSize = _ReceiveBufferSize;
                clientInfo._Client.SendBufferSize = _SendBufferSize;

                clientInfo._Client.SendTimeout = _SendTimeout;

                clientInfo._ReceiveBuffer = new byte[_ReceiveBufferSize];

                clientInfo._IP   = GetClientIP  (client);
                clientInfo._Port = GetClientPort(client);

                _ClientList.Add(clientInfo);
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
        }

        private bool CheckClientIndex(int clientIndex)
        {
            return clientIndex >= 0 && clientIndex < _ClientList.Count;
        }

        private int GetClientIndex(Socket client)
        {
            int result = -1;
            try
            {
                if (_ClientList.Count > 0)
                {
                    for (int i = 0; i < _ClientList.Count; i++)
                    {
                        if (_ClientList[i]._IP   == GetClientIP  (client) &&
                            _ClientList[i]._Port == GetClientPort(client)
                           )
                        {
                            result = i;

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        private string GetClientIP(Socket client)
        {
            string result = string.Empty;
            try
            {
                result = client.RemoteEndPoint.ToString().Split(':')[0];
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }
        private string GetClientPort(Socket client)
        {
            string result = string.Empty;
            try
            {
                result = client.RemoteEndPoint.ToString().Split(':')[1];
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        #endregion

        #endregion

        #region 이벤트

        public event RecvBytesEventHandler RecvBytesEvent;
        public event RecvStringEventHandler RecvStringEvent;

        #endregion
    }
}
