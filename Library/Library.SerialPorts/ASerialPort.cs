using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;

namespace Library.SerialPorts
{
    public abstract class ASerialPort : ADevice
    {
        #region 필드

        public SerialPort _SerialPort = null;

        protected string _PortName = "COM1";
        protected int _BaudRate = 9600;
        protected Parity _Parity = Parity.None;
        protected int _DataBits = 8;
        protected StopBits _StopBits = StopBits.One;

        protected int _ReadTimeout = 1000;
        protected int _ReadBufferSize = 4096;
        protected byte[] _ReadBuffer = null;

        protected int _WriteTimeout = 1000;
        protected int _WriteBufferSize = 2048;

        #endregion

        #region 속성

        public bool IsOpen
        {
            get
            {
                if (_SerialPort != null)
                {
                    return _SerialPort.IsOpen;
                }
                return false;
            }
        }

        public string PortName
        {
            get
            {
                return _PortName;
            }
            set
            {
                _PortName = value;
            }
        }
        public int BaudRate
        {
            get
            {
                return _BaudRate;
            }
            set
            {
                _BaudRate = value;
            }
        }
        public Parity Parity
        {
            get
            {
                return _Parity;
            }
            set
            {
                _Parity = value;
            }
        }
        public int DataBits
        {
            get
            {
                return _DataBits;
            }
            set
            {
                _DataBits = value;
            }
        }
        public StopBits StopBits
        {
            get
            {
                return _StopBits;
            }
            set
            {
                _StopBits = value;
            }
        }

        public int ReadTimeout
        {
            get
            {
                return _ReadTimeout;
            }
            set
            {
                _ReadTimeout = value;
            }
        }
        public int ReadBufferSize
        {
            get
            {
                return _ReadBufferSize;
            }
            set
            {
                _ReadBufferSize = value;
            }
        }

        public int WriteTimeout
        {
            get
            {
                return _WriteTimeout;
            }
            set
            {
                _WriteTimeout = value;
            }
        }
        public int WriteBufferSize
        {
            get
            {
                return _WriteBufferSize;
            }
            set
            {
                _WriteBufferSize = value;
            }
        }

        public int BytesToRead
        {
            get
            {
                if (_SerialPort != null)
                {
                    return _SerialPort.BytesToRead;
                }
                return 0;
            }
        }

        #endregion
    }
}
