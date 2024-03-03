using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class ADevice : AClass
    {
        #region 필드

        protected string _Device = "Device";

        #endregion

        #region 속성

        public string Device
        {
            get
            {
                return _Device;
            }
            set
            {
                _Device = value;
            }
        }

        #endregion

        #region 메서드

        protected override void LogWrite(string call, string text)
        {
            text = text.Replace("\r", "(CR)");
            text = text.Replace("\n", "(LF)");

            base.LogWrite(string.Format("{0}::{1}", _Device, call), text);
        }

        #endregion
    }
}
