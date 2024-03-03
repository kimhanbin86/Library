using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace Library.Sockets
{
    public abstract class ASocketClient : ADevice
    {
        #region 필드

        protected Socket _Client = null;

        protected string _IP = "127.0.0.1";
        protected int _Port = 5200;
        protected int _ConnectTimeout = 1000;

        protected int _ReceiveTimeout = 1000;
        protected int _ReceiveBufferSize = 8192;
        protected byte[] _ReceiveBuffer = null;

        protected int _SendTimeout = 1000;
        protected int _SendBufferSize = 8192;

        protected ProtocolType _ClientType = ProtocolType.Tcp;
        protected IPEndPoint _ServerEP = null;

        #endregion

        #region 속성

        public bool IsConnected
        {
            get
            {
                if (_Client != null)
                {
                    if (_Client.Connected)
                    {
                        return _Client.IsConnected();
                    }
                }
                return false;
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
        public int ConnectTimeout
        {
            get
            {
                return _ConnectTimeout;
            }
            set
            {
                _ConnectTimeout = value;
            }
        }

        public int ReceiveTimeout
        {
            get
            {
                return _ReceiveTimeout;
            }
            set
            {
                _ReceiveTimeout = value;
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

        public ProtocolType ClientType
        {
            get
            {
                return _ClientType;
            }
            set
            {
                _ClientType = value;
            }
        }

        #endregion
    }
}
