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
using Library.MQTT;

namespace Test_MQTTClient
{
    public partial class Form1 : Form
    {
        private MQTTClient _MQTTClient = null;

        private Timer _Timer = null;
        private void Tick(object sender, EventArgs e)
        {
            _Timer?.Stop();
            try
            {
                if (_MQTTClient != null)
                {
                    if (_MQTTClient.IsConnected)
                    {
                        lbl_Status.BackColor = Color.Lime;
                    }
                    else if (_MQTTClient.IsStarted)
                    {
                        lbl_Status.BackColor = Color.Yellow;
                    }
                    else
                    {
                        lbl_Status.BackColor = Color.Gray;
                    }
                }
                else
                {
                    lbl_Status.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                Log.Write(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
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
            if (_Timer != null)
            {
                if (_Timer.Enabled)
                {
                    _Timer.Stop();
                }

                _Timer.Dispose();
                _Timer = null;
            }

            btn_Disconnect_Click(null, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Log.MsgEvent += new MsgEventHandler(Log_MsgEvent);

            _Timer = new Timer();
            _Timer.Tick += new EventHandler(Tick);
            _Timer.Interval = 100;
            _Timer.Start();
        }

        private void Log_MsgEvent(Msg msg)
        {
            logListView1.AddListViewItem(msg);
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (_MQTTClient == null)
            {
                _MQTTClient = new MQTTClient();

                _MQTTClient.LogMsgEvent += new LogMsgEventHandler(_MQTTClient_LogMsgEvent);

                _MQTTClient.Device = "MQTTClient";

                _MQTTClient.MessageReceivedEvent += new MQTTClient.MessageReceivedEventHandler(_MQTTClient_MessageReceivedEvent);

                _MQTTClient.IsIPOnly = true;

                _MQTTClient.IP = txt_IP.Text;
                _MQTTClient.Port = Convert.ToInt32(txt_Port.Text);
                _MQTTClient.ClientId = txt_ClientId.Text;

                _MQTTClient.Timeout = 1000;

                _MQTTClient.Connect();
            }
        }
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (_MQTTClient != null)
            {
                _MQTTClient.Disconnect();
                _MQTTClient.Dispose();
                _MQTTClient = null;

                listBox1.Items.Clear();
            }
        }

        private void _MQTTClient_LogMsgEvent(string call, string text)
        {
            Log.Write(call, text);
        }

        private void _MQTTClient_MessageReceivedEvent(MQTTClientMessage message)
        {
        }

        private void btn_Publish_Click(object sender, EventArgs e)
        {
            if (_MQTTClient != null)
            {
                _MQTTClient.Publish(txt_PublishTopic.Text, txt_PublishPayload.Text);
            }
        }

        private void btn_Subscribe_Click(object sender, EventArgs e)
        {
            if (_MQTTClient != null)
            {
                if (_MQTTClient.Subscribe(txt_SubscribeTopic.Text).Result)
                {
                    listBox1.Items.Clear();

                    listBox1.Items.AddRange(_MQTTClient.GetSubscribeList());
                }
            }
        }
    }
}
