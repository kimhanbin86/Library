using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_SocketClient
{
    #region GlobalVariable

    public enum e_Door
    {
        Unused,
        Door_1,
        Door_2,
        Door_3,
    }

    public enum e_ComboBox_Cup
    {
        Paper, // D4B7_Cup_1, D4B5_Cap_1 0=True / 1=False
        Trans, // D4B6_Cup_2, D4B4_Cap_2
    }

    #endregion

    #region enum

    public enum e_RobotControl
    {
        Clear = 0x00,
        Play = 0x01,
        Hold = 0x02,
        Call_Master_Job = 0x04, // 두산 Initialize와 겹치는데 의미 확인 필요
                                //Initialize = 0x04, // 두산 Initialize와 겹치는데 의미 확인 필요
        Error_Reset = 0x08,
        Servo_On = 0x10,
        Servo_Off = 0x20, // 두산에는 없는 명령
    }

    public enum e_RobotCommand
    {
        Clear,
        Make_Coffee_Start,
        Ice_Complete,
        Make_Coffee_Finish,
        Syrup_Complete,
        Door,
    }

    #endregion

    public interface IRobot
    {
        #region AClass

        event Library.LogMsgEventHandler LogMsgEvent;

        #endregion

        #region ADevice

        string Device { get; set; }

        #endregion

        #region ASocketClient

        bool IsConnected { get; }

        string IP { get; set; }
        int Port { get; set; }
        int ConnectTimeout { get; set; }

        int ReceiveTimeout { get; set; }
        int ReceiveBufferSize { get; set; }

        int SendTimeout { get; set; }
        int SendBufferSize { get; set; }

        System.Net.Sockets.ProtocolType ClientType { get; set; }

        #endregion

        #region SocketClient

        void Dispose();

        void Disconnect();

        bool Connect();

        #endregion

        bool GetStatus(ref byte[] bytes);

        bool RobotControl(e_RobotControl control);

        bool RobotCommand(e_RobotCommand command, bool syrupUsed, e_Door door, string productCode, e_ComboBox_Cup cup, bool capUsed);
    }
}
