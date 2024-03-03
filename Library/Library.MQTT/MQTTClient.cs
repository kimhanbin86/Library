using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;

namespace Library.MQTT
{
    public struct MQTTClientMessage
    {
        public string Topic;
        public int Length;
        public byte[] Payload;
        public string Message;
    }

    public class MQTTClient : ADevice
    {
        public delegate void MessageReceivedEventHandler(MQTTClientMessage message);

        #region 필드

        private IManagedMqttClient _MqttClient = null;

        private bool _IsIPOnly = false;

        private string _IP = "127.0.0.1";
        private int _Port = 5200;
        private string _ClientId = "ClientId";

        private int _Timeout = 1000;

        private List<string> _SubscribeList = null;

        #endregion

        #region 속성

        public bool IsStarted
        {
            get
            {
                if (_MqttClient != null)
                {
                    return _MqttClient.IsStarted;
                }
                return false;
            }
        }
        public bool IsConnected
        {
            get
            {
                if (_MqttClient != null)
                {
                    return _MqttClient.IsConnected;
                }
                return false;
            }
        }

        public bool IsIPOnly
        {
            get
            {
                return _IsIPOnly;
            }
            set
            {
                _IsIPOnly = value;
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
        public string ClientId
        {
            get
            {
                return _ClientId;
            }
            set
            {
                _ClientId = value;
            }
        }

        public int Timeout
        {
            get
            {
                return _Timeout;
            }
            set
            {
                _Timeout = value;
            }
        }

        #endregion

        #region 메서드

        public MQTTClient()
        {
            _SubscribeList = new List<string>();
        }

        public override void Dispose()
        {
            Disconnect();

            if (MessageReceivedEvent != null)
            {
                foreach (Delegate del in MessageReceivedEvent.GetInvocationList())
                {
                    MessageReceivedEvent -= (MessageReceivedEventHandler)del;
                }
            }

            base.Dispose();
        }

        #region Disconnect, Connect

        public void Disconnect()
        {
            if (_MqttClient != null)
            {
                if (_SubscribeList.Count > 0)
                {
                    Unsubscribe();
                }

                _MqttClient.StopAsync();
                _MqttClient.Dispose();
                _MqttClient = null;

                LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Disconnect OK ({0})", _ClientId));
            }
        }

        public async Task<bool> Connect()
        {
            try
            {
                if (_MqttClient == null)
                {
                    _MqttClient = new MqttFactory().CreateManagedMqttClient();

                    _MqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnMessageReceived);

                    #region ManagedMqttClientOptions

                    ManagedMqttClientOptions options = new ManagedMqttClientOptions();

                    if (_IsIPOnly)
                    {
                        options.ClientOptions = new MqttClientOptions()
                        {
                            ClientId = _ClientId,

                            ChannelOptions = new MqttClientTcpOptions
                            {
                                Server = _IP,
                            }
                        };
                    }
                    else
                    {
                        options.ClientOptions = new MqttClientOptions()
                        {
                            ClientId = _ClientId,

                            ChannelOptions = new MqttClientTcpOptions
                            {
                                Server = _IP,
                                Port = _Port,
                            }
                        };
                    }

                    options.AutoReconnectDelay = TimeSpan.FromSeconds(1);

                    #endregion

                    Task task = _MqttClient.StartAsync(options);

                    if (await Task.WhenAny(task, Task.Delay(_Timeout)) == task)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWrite("Connect", Utility.GetString(ex));
            }

            LogWrite("Connect", string.Format("Connect {0} ({1})", IsConnected ? "OK" : "NG", _ClientId));

            if (IsConnected == false)
            {
                Disconnect();
            }

            return IsConnected;
        }

        #endregion

        private void OnMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            #region Message

            MQTTClientMessage message = new MQTTClientMessage();

            message.Topic = e.ApplicationMessage.Topic;
            message.Length = e.ApplicationMessage.Payload.Length;
            message.Payload = new byte[message.Length];
            Array.Copy(e.ApplicationMessage.Payload, message.Payload, message.Length);
            message.Message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

            #endregion

            if (MessageReceivedEvent != null)
            {
                MessageReceivedEvent(message);
            }

            LogWrite(MethodBase.GetCurrentMethod().Name, string.Format("Topic=[{0}], Len=[{1}], Message=[{2}]", message.Topic, message.Length, message.Message));
        }

        public string[] GetSubscribeList()
        {
            return _SubscribeList.ToArray();
        }

        public async Task<bool> Publish(string topic, string message)
        {
            bool result = false;
            try
            {
                Task task = _MqttClient.PublishAsync(builder => builder.WithTopic(topic).WithPayload(message));

                if (await Task.WhenAny(task, Task.Delay(_Timeout)) == task)
                {
                    LogWrite("Publish", string.Format("Topic=[{0}], Message=[{1}]", topic, message));

                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogWrite("Publish", Utility.GetString(ex));
            }
            return result;
        }

        public async Task<bool> Subscribe(string topic)
        {
            bool result = false;
            try
            {
                Task task = _MqttClient.SubscribeAsync(new MqttTopicFilter { Topic = topic, QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce });

                if (await Task.WhenAny(task, Task.Delay(_Timeout)) == task)
                {
                    _SubscribeList.Add(topic);

                    LogWrite("Subscribe", string.Format("Subscribe Topic=[{0}]", topic));

                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogWrite("Subscribe", Utility.GetString(ex));
            }
            return result;
        }

        private void Unsubscribe()
        {
            try
            {
                _MqttClient.UnsubscribeAsync(GetSubscribeList());

                _SubscribeList.Clear();
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
        }

        #endregion

        #region 이벤트

        public event MessageReceivedEventHandler MessageReceivedEvent;

        #endregion
    }
}
