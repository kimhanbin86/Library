namespace Test_MQTTClient
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
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ClientId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.txt_PublishTopic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PublishPayload = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Publish = new System.Windows.Forms.Button();
            this.btn_Subscribe = new System.Windows.Forms.Button();
            this.txt_SubscribeTopic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk_IsIPOnly = new System.Windows.Forms.CheckBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.logListView1.Location = new System.Drawing.Point(0, 361);
            this.logListView1.MultiSelect = false;
            this.logListView1.Name = "logListView1";
            this.logListView1.Size = new System.Drawing.Size(784, 200);
            this.logListView1.TabIndex = 0;
            this.logListView1.TabStop = false;
            this.logListView1.UseCompatibleStateImageBehavior = false;
            this.logListView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(126, 21);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(200, 22);
            this.txt_IP.TabIndex = 2;
            this.txt_IP.Text = "211.171.250.243";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(126, 49);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 22);
            this.txt_Port.TabIndex = 4;
            this.txt_Port.Text = "4999";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ClientId
            // 
            this.txt_ClientId.Location = new System.Drawing.Point(126, 77);
            this.txt_ClientId.Name = "txt_ClientId";
            this.txt_ClientId.Size = new System.Drawing.Size(200, 22);
            this.txt_ClientId.TabIndex = 6;
            this.txt_ClientId.Text = "Test_MQTTClient";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "ClientId";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(126, 105);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 22);
            this.btn_Connect.TabIndex = 7;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(226, 105);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(100, 22);
            this.btn_Disconnect.TabIndex = 8;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // txt_PublishTopic
            // 
            this.txt_PublishTopic.Location = new System.Drawing.Point(126, 161);
            this.txt_PublishTopic.Name = "txt_PublishTopic";
            this.txt_PublishTopic.Size = new System.Drawing.Size(200, 22);
            this.txt_PublishTopic.TabIndex = 10;
            this.txt_PublishTopic.Text = "/Req_DeliveryRobotStatus";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Publish topic";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_PublishPayload
            // 
            this.txt_PublishPayload.Location = new System.Drawing.Point(126, 189);
            this.txt_PublishPayload.Name = "txt_PublishPayload";
            this.txt_PublishPayload.Size = new System.Drawing.Size(200, 22);
            this.txt_PublishPayload.TabIndex = 12;
            this.txt_PublishPayload.Text = "STX|1|ETX";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "payload";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Publish
            // 
            this.btn_Publish.Location = new System.Drawing.Point(126, 217);
            this.btn_Publish.Name = "btn_Publish";
            this.btn_Publish.Size = new System.Drawing.Size(100, 22);
            this.btn_Publish.TabIndex = 13;
            this.btn_Publish.Text = "Publish";
            this.btn_Publish.UseVisualStyleBackColor = true;
            this.btn_Publish.Click += new System.EventHandler(this.btn_Publish_Click);
            // 
            // btn_Subscribe
            // 
            this.btn_Subscribe.Location = new System.Drawing.Point(544, 217);
            this.btn_Subscribe.Name = "btn_Subscribe";
            this.btn_Subscribe.Size = new System.Drawing.Size(100, 22);
            this.btn_Subscribe.TabIndex = 18;
            this.btn_Subscribe.Text = "Subscribe";
            this.btn_Subscribe.UseVisualStyleBackColor = true;
            this.btn_Subscribe.Click += new System.EventHandler(this.btn_Subscribe_Click);
            // 
            // txt_SubscribeTopic
            // 
            this.txt_SubscribeTopic.Location = new System.Drawing.Point(544, 161);
            this.txt_SubscribeTopic.Name = "txt_SubscribeTopic";
            this.txt_SubscribeTopic.Size = new System.Drawing.Size(200, 22);
            this.txt_SubscribeTopic.TabIndex = 15;
            this.txt_SubscribeTopic.Text = "/Ack_DeliveryRobotStatus";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(438, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Subscribe topic";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_IsIPOnly
            // 
            this.chk_IsIPOnly.AutoSize = true;
            this.chk_IsIPOnly.Checked = true;
            this.chk_IsIPOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IsIPOnly.Location = new System.Drawing.Point(332, 23);
            this.chk_IsIPOnly.Name = "chk_IsIPOnly";
            this.chk_IsIPOnly.Size = new System.Drawing.Size(65, 18);
            this.chk_IsIPOnly.TabIndex = 19;
            this.chk_IsIPOnly.Text = "IP Only";
            this.chk_IsIPOnly.UseVisualStyleBackColor = true;
            // 
            // lbl_Status
            // 
            this.lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Status.Location = new System.Drawing.Point(423, 20);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(100, 22);
            this.lbl_Status.TabIndex = 20;
            this.lbl_Status.Text = "Status";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(544, 245);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 102);
            this.listBox1.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.chk_IsIPOnly);
            this.Controls.Add(this.btn_Subscribe);
            this.Controls.Add(this.txt_SubscribeTopic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Publish);
            this.Controls.Add(this.txt_PublishPayload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_PublishTopic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.txt_ClientId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_IP);
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
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ClientId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.TextBox txt_PublishTopic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_PublishPayload;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Publish;
        private System.Windows.Forms.Button btn_Subscribe;
        private System.Windows.Forms.TextBox txt_SubscribeTopic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chk_IsIPOnly;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ListBox listBox1;
    }
}

