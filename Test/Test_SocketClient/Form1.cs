using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;

using Library;
using Library.Log;
using Library.Sockets;

namespace Test_SocketClient
{
    public partial class Form1 : Form
    {
        private IRobot _Robot = null;

        private Timer _Timer = null;
        private void Tick(object sender, EventArgs e)
        {
            _Timer?.Stop();
            try
            {
                if (_Robot != null)
                {
                    lbl_Connected.BackColor = _Robot.IsConnected ? Color.Lime : Color.Red;
                }
                else
                {
                    lbl_Connected.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                Log.Write(MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                _Timer?.Start();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Dispose();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Timer

            if (_Timer != null)
            {
                if (_Timer.Enabled)
                {
                    _Timer.Stop();
                }
                _Timer.Dispose();
                _Timer = null;
            }

            #endregion

            btn_Disconnect_Click(null, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Log.MsgEvent += new MsgEventHandler(Log_MsgEvent);

            #region ComboBox

            cb_ClientType.SelectedIndex = 1;

            cb_RobotControl.Items.AddRange(Enum.GetNames(typeof(e_RobotControl)));
            cb_RobotControl.SelectedIndex = 0;

            cb_RobotCommand.Items.AddRange(Enum.GetNames(typeof(e_RobotCommand)));
            cb_RobotCommand.SelectedIndex = 0;

            cb_Door.Items.AddRange(Enum.GetNames(typeof(e_Door)));
            cb_Door.SelectedIndex = 0;

            cb_Cup.Items.AddRange(Enum.GetNames(typeof(e_ComboBox_Cup)));
            cb_Cup.SelectedIndex = 0;

            #endregion

            #region Timer

            _Timer = new Timer();
            _Timer.Tick += new EventHandler(Tick);
            _Timer.Interval = 100;
            _Timer.Start();

            #endregion
        }

        private void Log_MsgEvent(Msg msg)
        {
            logListView1.AddListViewItem(msg);
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (_Robot != null)
            {
                _Robot.Dispose();
                _Robot = null;
            }
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (_Robot == null)
            {
                _Robot = new CRobot_YASKAWA();

                _Robot.LogMsgEvent += new LogMsgEventHandler(Robot_LogMsgEvent);

                _Robot.Device = txt_Device.Text;

                _Robot.IP = txt_IP.Text;
                _Robot.Port = Convert.ToInt32(txt_Port.Text);
                _Robot.ConnectTimeout = Convert.ToInt32(txt_ConnectTimeout.Text);
                _Robot.ReceiveTimeout = Convert.ToInt32(txt_ReceiveTimeout.Text);
                _Robot.ReceiveBufferSize = Convert.ToInt32(txt_ReceiveBufferSize.Text);
                _Robot.SendTimeout = Convert.ToInt32(txt_SendTimeout.Text);
                _Robot.SendBufferSize = Convert.ToInt32(txt_SendBufferSize.Text);
                switch (cb_ClientType.Text)
                {
                    case "Tcp": _Robot.ClientType = System.Net.Sockets.ProtocolType.Tcp; break;
                    case "Udp": _Robot.ClientType = System.Net.Sockets.ProtocolType.Udp; break;
                }

                _Robot.Connect();
            }
        }

        private void Robot_LogMsgEvent(string call, string text)
        {
            Log.Write(call, text);
        }

        private void btn_GetStatus_Click(object sender, EventArgs e)
        {
            if (_Robot != null)
            {
                byte[] bytes = null;

                btn_GetStatus.BackColor = _Robot.GetStatus(ref bytes) ? Color.Lime : Color.Red;
            }
        }

        private void btn_RobotControl_Click(object sender, EventArgs e)
        {
            if (_Robot != null)
            {
                e_RobotControl control = e_RobotControl.Clear;
                switch (cb_RobotControl.Text)
                {
                    case "Clear": control = e_RobotControl.Clear; break;
                    case "Play": control = e_RobotControl.Play; break;
                    case "Hold": control = e_RobotControl.Hold; break;
                    case "Call_Master_Job": control = e_RobotControl.Call_Master_Job; break;
                    case "Error_Reset": control = e_RobotControl.Error_Reset; break;
                    case "Servo_On": control = e_RobotControl.Servo_On; break;
                    case "Servo_Off": control = e_RobotControl.Servo_Off; break;
                }

                btn_RobotControl.BackColor = _Robot.RobotControl(control) ? Color.Lime : Color.Red;
            }
        }

        private void btn_RobotCommand_Click(object sender, EventArgs e)
        {
            if (_Robot != null)
            {
                e_RobotCommand command = e_RobotCommand.Clear;
                switch (cb_RobotCommand.Text)
                {
                    case "Clear": command = e_RobotCommand.Clear; break;
                    case "Make_Coffee_Start": command = e_RobotCommand.Make_Coffee_Start; break;
                    case "Ice_Complete": command = e_RobotCommand.Ice_Complete; break;
                    case "Make_Coffee_Finish": command = e_RobotCommand.Make_Coffee_Finish; break;
                    case "Syrup_Complete": command = e_RobotCommand.Syrup_Complete; break;
                    case "Door": command = e_RobotCommand.Door; break;
                }

                bool syrupUsed = chk_syrupUsed.Checked;

                e_Door door = e_Door.Unused;
                switch (cb_Door.Text)
                {
                    case "Unused": door = e_Door.Unused; break;
                    case "Door_1": door = e_Door.Door_1; break;
                    case "Door_2": door = e_Door.Door_2; break;
                    case "Door_3": door = e_Door.Door_3; break;
                }

                string productCode = txt_productCode.Text;

                e_ComboBox_Cup cup = e_ComboBox_Cup.Paper;
                switch (cb_Cup.Text)
                {
                    case "Paper": cup = e_ComboBox_Cup.Paper; break;
                    case "Trans": cup = e_ComboBox_Cup.Trans; break;
                }

                bool capUsed = chk_capUsed.Checked;

                btn_RobotCommand.BackColor = _Robot.RobotCommand(command, syrupUsed, door, productCode, cup, capUsed) ? Color.Lime : Color.Red;
            }
        }
    }
}
