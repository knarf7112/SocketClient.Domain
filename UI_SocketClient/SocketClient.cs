using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
//using SocketService;
using ALCommon;
//
using SocketClient.Domain;
namespace UI_SocketClient
{
    public partial class UI_SocketClient : Form
    {

        private GenSocketClient<AL2POS_Domain> Client;

        private bool SocketConnected;
        public UI_SocketClient()
        {
            InitializeComponent();
            this.SocketConnected = false;
            //this.timer1.Enabled = true;
            this.timer1.Tick += timer1_Tick;
            //this.ConnectIP.Enter += ConnectIP_Enter;
            //this.ConnectPort.Enter += ConnectIP_Enter;
            //this.ConnectIP.Leave += ConnectIP_Leave;
            //this.ConnectPort.Leave += ConnectIP_Leave;
        }
        #region Event
        void ConnectIP_Leave(object sender, EventArgs e)
        {

            if (sender is TextBox && ((TextBox)sender).Text == String.Empty)
                ((TextBox)sender).Text = "請輸入" + ((TextBox)sender).Name.Substring(7);
        }

        void ConnectIP_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).Text = "";
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        #endregion
        private void Connect_Click(object sender, EventArgs e)
        {
            this.Connect.Enabled = false;
            //IP與Port不為空值
            if (this.ConnectIP.Text != String.Empty && this.ConnectPort.Text != String.Empty)
            {
                if (!this.SocketConnected)
                {
                    this.Client = new GenSocketClient<AL2POS_Domain>(this.ConnectIP.Text, Convert.ToInt32(this.ConnectPort.Text));
                    this.SocketConnected = this.Client.ConnectToServer();
                }
                else
                {
                    this.Client.Dispose();
                }
            }
            if (this.SocketConnected)
            {
                this.Connect.Enabled = true;
                this.ConnectStatus.Text = "連線中...";
                this.tabControl1.Enabled = true;
                this.Connect.Text = "斷線";
            }
            else
            {
                this.Connect.Enabled = true;
                this.tabControl1.Enabled = false;
                this.ConnectStatus.Text = "離線";
                this.Connect.Text = "連線";
            }
        }

        private void SocketClient_Load(object sender, EventArgs e)
        {
            //關閉表單
            this.tabControl1.Enabled = false;
        }

        private void RunAutoload_Click(object sender, EventArgs e)
        {
            this.RunAutoload.Enabled = false;
            AL2POS_Domain sendObj = this.SetObject(groupBox1);
            AL2POS_Domain receiveObj = this.Client.SendAndReceive(sendObj);
            
            if (receiveObj != null)
            {
                this.SetGroupBox(receiveObj, groupBox1);
                this.RunAutoload.Enabled = true;
            }
            else
            {
                MessageBox.Show("傳輸錯誤!");
            }
        }
        private void SetGroupBox(AL2POS_Domain obj,GroupBox g2)
        {
            foreach (Control c in g2.Controls)
            {
                if (c is TextBox)
                {
                    switch (c.Name)
                    {
                        case "COM_TYPE":
                            c.Text = obj.COM_TYPE;
                            break;
                        case "ICC_NO":
                            c.Text = obj.ICC_NO;
                            break;
                        case "MERC_FLG":
                            c.Text = obj.MERC_FLG;
                            break;
                        case "POS_FLG":
                            c.Text = obj.POS_FLG;
                            break;
                        case "AL_AMT":
                            c.Text = obj.AL_AMT.ToString();
                            break;
                        case "AL2POS_RC":
                            c.Text = obj.AL2POS_RC;
                            break;
                        case "AL2POS_SN":
                            c.Text = obj.AL2POS_SN;
                            break;
                        case "READER_ID":
                            c.Text = obj.READER_ID;
                            break;
                        case "REG_ID":
                            c.Text = obj.REG_ID;
                            break;
                        case "STORE_NO":
                            c.Text = obj.STORE_NO;
                            break;
                    }
                }
            }
        }
        private AL2POS_Domain SetObject(GroupBox g1)
        {
            AL2POS_Domain obj = new AL2POS_Domain();
            foreach (Control c in g1.Controls)
            {
                if (c is TextBox)
                {
                    switch (c.Name)
                    {
                        case "COM_TYPE":
                            obj.COM_TYPE = c.Text;
                            break;
                        case "ICC_NO":
                            obj.ICC_NO = c.Text;
                            break;
                        case "MERC_FLG":
                            obj.MERC_FLG = c.Text;
                            break;
                        case "POS_FLG":
                            obj.POS_FLG = c.Text;
                            break;
                        case "AL_AMT":
                            obj.AL_AMT = Convert.ToInt32(c.Text);
                            break;
                        case "AL2POS_RC":
                            obj.AL2POS_RC = c.Text;
                            break;
                        case "AL2POS_SN":
                            obj.AL2POS_SN = c.Text;
                            break;
                        case "READER_ID":
                            obj.READER_ID = c.Text;
                            break;
                        case "REG_ID":
                            obj.REG_ID = c.Text;
                            break;
                        case "STORE_NO":
                            obj.STORE_NO = c.Text;
                            break;
                    }
                }
            }
            return obj;
        }
    }
}
