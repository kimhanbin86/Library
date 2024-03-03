namespace Test_SocketClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.logListView1 = new Library.Log.LogListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Device = new System.Windows.Forms.TextBox();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ConnectTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ReceiveTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ReceiveBufferSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_SendTimeout = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SendBufferSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_ClientType = new System.Windows.Forms.ComboBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.lbl_Connected = new System.Windows.Forms.Label();
            this.btn_GetStatus = new System.Windows.Forms.Button();
            this.cb_RobotControl = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_RobotControl = new System.Windows.Forms.Button();
            this.cb_RobotCommand = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chk_syrupUsed = new System.Windows.Forms.CheckBox();
            this.cb_Door = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_productCode = new System.Windows.Forms.TextBox();
            this.cb_Cup = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chk_capUsed = new System.Windows.Forms.CheckBox();
            this.btn_RobotCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logListView1
            // 
            this.logListView1.BackColor = System.Drawing.Color.Black;
            this.logListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logListView1.ForeColor = System.Drawing.Color.Yellow;
            this.logListView1.FullRowSelect = true;
            this.logListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.logListView1.HideSelection = false;
            this.logListView1.Location = new System.Drawing.Point(0, 429);
            this.logListView1.MultiSelect = false;
            this.logListView1.Name = "logListView1";
            this.logListView1.Size = new System.Drawing.Size(1008, 300);
            this.logListView1.TabIndex = 0;
            this.logListView1.TabStop = false;
            this.logListView1.UseCompatibleStateImageBehavior = false;
            this.logListView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Device
            // 
            this.txt_Device.Location = new System.Drawing.Point(137, 9);
            this.txt_Device.Name = "txt_Device";
            this.txt_Device.Size = new System.Drawing.Size(121, 22);
            this.txt_Device.TabIndex = 2;
            this.txt_Device.Text = "YASKAWA";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(137, 65);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(121, 22);
            this.txt_IP.TabIndex = 4;
            this.txt_IP.Text = "192.168.0.10";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(137, 89);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(121, 22);
            this.txt_Port.TabIndex = 6;
            this.txt_Port.Text = "10040";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ConnectTimeout
            // 
            this.txt_ConnectTimeout.Location = new System.Drawing.Point(137, 113);
            this.txt_ConnectTimeout.Name = "txt_ConnectTimeout";
            this.txt_ConnectTimeout.Size = new System.Drawing.Size(121, 22);
            this.txt_ConnectTimeout.TabIndex = 8;
            this.txt_ConnectTimeout.Text = "1000";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "ConnectTimeout";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ReceiveTimeout
            // 
            this.txt_ReceiveTimeout.Location = new System.Drawing.Point(137, 137);
            this.txt_ReceiveTimeout.Name = "txt_ReceiveTimeout";
            this.txt_ReceiveTimeout.Size = new System.Drawing.Size(121, 22);
            this.txt_ReceiveTimeout.TabIndex = 10;
            this.txt_ReceiveTimeout.Text = "1000";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "ReceiveTimeout";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ReceiveBufferSize
            // 
            this.txt_ReceiveBufferSize.Location = new System.Drawing.Point(137, 161);
            this.txt_ReceiveBufferSize.Name = "txt_ReceiveBufferSize";
            this.txt_ReceiveBufferSize.Size = new System.Drawing.Size(121, 22);
            this.txt_ReceiveBufferSize.TabIndex = 12;
            this.txt_ReceiveBufferSize.Text = "8192";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "ReceiveBufferSize";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SendTimeout
            // 
            this.txt_SendTimeout.Location = new System.Drawing.Point(137, 185);
            this.txt_SendTimeout.Name = "txt_SendTimeout";
            this.txt_SendTimeout.Size = new System.Drawing.Size(121, 22);
            this.txt_SendTimeout.TabIndex = 14;
            this.txt_SendTimeout.Text = "1000";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 185);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "SendTimeout";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SendBufferSize
            // 
            this.txt_SendBufferSize.Location = new System.Drawing.Point(137, 209);
            this.txt_SendBufferSize.Name = "txt_SendBufferSize";
            this.txt_SendBufferSize.Size = new System.Drawing.Size(121, 22);
            this.txt_SendBufferSize.TabIndex = 16;
            this.txt_SendBufferSize.Text = "8192";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 209);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "SendBufferSize";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 233);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 22);
            this.label9.TabIndex = 17;
            this.label9.Text = "ClientType";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_ClientType
            // 
            this.cb_ClientType.FormattingEnabled = true;
            this.cb_ClientType.Items.AddRange(new object[] {
            "Tcp",
            "Udp"});
            this.cb_ClientType.Location = new System.Drawing.Point(137, 233);
            this.cb_ClientType.Name = "cb_ClientType";
            this.cb_ClientType.Size = new System.Drawing.Size(121, 22);
            this.cb_ClientType.TabIndex = 18;
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(62, 261);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(95, 45);
            this.btn_Disconnect.TabIndex = 19;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(163, 261);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(95, 45);
            this.btn_Connect.TabIndex = 20;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // lbl_Connected
            // 
            this.lbl_Connected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Connected.Location = new System.Drawing.Point(262, 261);
            this.lbl_Connected.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_Connected.Name = "lbl_Connected";
            this.lbl_Connected.Size = new System.Drawing.Size(95, 45);
            this.lbl_Connected.TabIndex = 21;
            this.lbl_Connected.Text = "Connected";
            this.lbl_Connected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GetStatus
            // 
            this.btn_GetStatus.Location = new System.Drawing.Point(462, 261);
            this.btn_GetStatus.Name = "btn_GetStatus";
            this.btn_GetStatus.Size = new System.Drawing.Size(95, 45);
            this.btn_GetStatus.TabIndex = 22;
            this.btn_GetStatus.Text = "GetStatus";
            this.btn_GetStatus.UseVisualStyleBackColor = true;
            this.btn_GetStatus.Click += new System.EventHandler(this.btn_GetStatus_Click);
            // 
            // cb_RobotControl
            // 
            this.cb_RobotControl.FormattingEnabled = true;
            this.cb_RobotControl.Location = new System.Drawing.Point(686, 9);
            this.cb_RobotControl.Name = "cb_RobotControl";
            this.cb_RobotControl.Size = new System.Drawing.Size(121, 22);
            this.cb_RobotControl.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(561, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 22);
            this.label10.TabIndex = 23;
            this.label10.Text = "RobotControl";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_RobotControl
            // 
            this.btn_RobotControl.Location = new System.Drawing.Point(712, 37);
            this.btn_RobotControl.Name = "btn_RobotControl";
            this.btn_RobotControl.Size = new System.Drawing.Size(95, 45);
            this.btn_RobotControl.TabIndex = 25;
            this.btn_RobotControl.Text = "Control";
            this.btn_RobotControl.UseVisualStyleBackColor = true;
            this.btn_RobotControl.Click += new System.EventHandler(this.btn_RobotControl_Click);
            // 
            // cb_RobotCommand
            // 
            this.cb_RobotCommand.FormattingEnabled = true;
            this.cb_RobotCommand.Location = new System.Drawing.Point(686, 116);
            this.cb_RobotCommand.Name = "cb_RobotCommand";
            this.cb_RobotCommand.Size = new System.Drawing.Size(121, 22);
            this.cb_RobotCommand.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(561, 116);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 22);
            this.label11.TabIndex = 26;
            this.label11.Text = "RobotCommand";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_syrupUsed
            // 
            this.chk_syrupUsed.AutoSize = true;
            this.chk_syrupUsed.Location = new System.Drawing.Point(686, 143);
            this.chk_syrupUsed.Name = "chk_syrupUsed";
            this.chk_syrupUsed.Size = new System.Drawing.Size(82, 18);
            this.chk_syrupUsed.TabIndex = 28;
            this.chk_syrupUsed.Text = "syrupUsed";
            this.chk_syrupUsed.UseVisualStyleBackColor = true;
            // 
            // cb_Door
            // 
            this.cb_Door.FormattingEnabled = true;
            this.cb_Door.Location = new System.Drawing.Point(686, 164);
            this.cb_Door.Name = "cb_Door";
            this.cb_Door.Size = new System.Drawing.Size(121, 22);
            this.cb_Door.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(561, 164);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 22);
            this.label12.TabIndex = 29;
            this.label12.Text = "Door";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(561, 188);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 22);
            this.label13.TabIndex = 31;
            this.label13.Text = "productCode";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_productCode
            // 
            this.txt_productCode.Location = new System.Drawing.Point(686, 188);
            this.txt_productCode.Name = "txt_productCode";
            this.txt_productCode.Size = new System.Drawing.Size(121, 22);
            this.txt_productCode.TabIndex = 32;
            this.txt_productCode.Text = "01";
            // 
            // cb_Cup
            // 
            this.cb_Cup.FormattingEnabled = true;
            this.cb_Cup.Location = new System.Drawing.Point(686, 212);
            this.cb_Cup.Name = "cb_Cup";
            this.cb_Cup.Size = new System.Drawing.Size(121, 22);
            this.cb_Cup.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(561, 212);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 22);
            this.label14.TabIndex = 33;
            this.label14.Text = "Cup";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_capUsed
            // 
            this.chk_capUsed.AutoSize = true;
            this.chk_capUsed.Location = new System.Drawing.Point(686, 239);
            this.chk_capUsed.Name = "chk_capUsed";
            this.chk_capUsed.Size = new System.Drawing.Size(72, 18);
            this.chk_capUsed.TabIndex = 36;
            this.chk_capUsed.Text = "capUsed";
            this.chk_capUsed.UseVisualStyleBackColor = true;
            // 
            // btn_RobotCommand
            // 
            this.btn_RobotCommand.Location = new System.Drawing.Point(712, 261);
            this.btn_RobotCommand.Name = "btn_RobotCommand";
            this.btn_RobotCommand.Size = new System.Drawing.Size(95, 45);
            this.btn_RobotCommand.TabIndex = 37;
            this.btn_RobotCommand.Text = "Command";
            this.btn_RobotCommand.UseVisualStyleBackColor = true;
            this.btn_RobotCommand.Click += new System.EventHandler(this.btn_RobotCommand_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btn_RobotCommand);
            this.Controls.Add(this.chk_capUsed);
            this.Controls.Add(this.cb_Cup);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_productCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_Door);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chk_syrupUsed);
            this.Controls.Add(this.cb_RobotCommand);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_RobotControl);
            this.Controls.Add(this.cb_RobotControl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_GetStatus);
            this.Controls.Add(this.lbl_Connected);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.cb_ClientType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_SendBufferSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_SendTimeout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_ReceiveBufferSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ReceiveTimeout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ConnectTimeout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Device);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logListView1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Library.Log.LogListView logListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Device;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ConnectTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ReceiveTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ReceiveBufferSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SendTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SendBufferSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_ClientType;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label lbl_Connected;
        private System.Windows.Forms.Button btn_GetStatus;
        private System.Windows.Forms.ComboBox cb_RobotControl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_RobotControl;
        private System.Windows.Forms.ComboBox cb_RobotCommand;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk_syrupUsed;
        private System.Windows.Forms.ComboBox cb_Door;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_productCode;
        private System.Windows.Forms.ComboBox cb_Cup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chk_capUsed;
        private System.Windows.Forms.Button btn_RobotCommand;
    }
}

