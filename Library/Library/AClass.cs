using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public delegate void LogMsgEventHandler(string call, string text);

    public abstract class AClass
    {
        #region 필드

        protected bool _LogEnabled = true;

        #endregion

        #region 속성

        public bool LogEnabled
        {
            get
            {
                return _LogEnabled;
            }
            set
            {
                _LogEnabled = value;
            }
        }

        #endregion

        #region 메서드

        protected virtual void LogWrite(string call, string text)
        {
            if (_LogEnabled)
            {
                if (LogMsgEvent != null)
                {
                    LogMsgEvent(call, text);
                }
            }
        }

        public virtual void Dispose()
        {
            if (LogMsgEvent != null)
            {
                foreach (Delegate del in LogMsgEvent.GetInvocationList())
                {
                    LogMsgEvent -= (LogMsgEventHandler)del;
                }
            }
        }

        #endregion

        #region 이벤트

        public event LogMsgEventHandler LogMsgEvent;

        #endregion
    }
}
