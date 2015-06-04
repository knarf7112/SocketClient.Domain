namespace UI_SocketClient
{
    partial class UI_SocketClient
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RunAutoload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.STORE_NO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.REG_ID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.READER_ID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AL2POS_SN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AL2POS_RC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AL_AMT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.POS_FLG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MERC_FLG = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ICC_NO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.COM_TYPE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RunQuery = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GpConnect = new System.Windows.Forms.GroupBox();
            this.ConnectStatus = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.ConnectPort = new System.Windows.Forms.TextBox();
            this.ConnectIP = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.GpConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(8, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(535, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RunAutoload);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(527, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "自動加值";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RunAutoload
            // 
            this.RunAutoload.Location = new System.Drawing.Point(429, 16);
            this.RunAutoload.Name = "RunAutoload";
            this.RunAutoload.Size = new System.Drawing.Size(73, 38);
            this.RunAutoload.TabIndex = 1;
            this.RunAutoload.Text = "執行";
            this.RunAutoload.UseVisualStyleBackColor = true;
            this.RunAutoload.Click += new System.EventHandler(this.RunAutoload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.STORE_NO);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.REG_ID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.READER_ID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.AL2POS_SN);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.AL2POS_RC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.AL_AMT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.POS_FLG);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.MERC_FLG);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ICC_NO);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.COM_TYPE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autoload";
            // 
            // STORE_NO
            // 
            this.STORE_NO.Location = new System.Drawing.Point(126, 356);
            this.STORE_NO.Name = "STORE_NO";
            this.STORE_NO.Size = new System.Drawing.Size(238, 29);
            this.STORE_NO.TabIndex = 19;
            this.STORE_NO.Text = "000251";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 359);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(94, 21);
            this.label10.TabIndex = 18;
            this.label10.Text = "STORE_NO";
            // 
            // REG_ID
            // 
            this.REG_ID.Location = new System.Drawing.Point(126, 321);
            this.REG_ID.Name = "REG_ID";
            this.REG_ID.Size = new System.Drawing.Size(238, 29);
            this.REG_ID.TabIndex = 17;
            this.REG_ID.Text = "01";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 324);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(66, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "REG_ID";
            // 
            // READER_ID
            // 
            this.READER_ID.Location = new System.Drawing.Point(126, 286);
            this.READER_ID.Name = "READER_ID";
            this.READER_ID.Size = new System.Drawing.Size(238, 29);
            this.READER_ID.TabIndex = 15;
            this.READER_ID.Text = "8604042B6A9F2980";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 289);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "READER_ID";
            // 
            // AL2POS_SN
            // 
            this.AL2POS_SN.Location = new System.Drawing.Point(126, 251);
            this.AL2POS_SN.Name = "AL2POS_SN";
            this.AL2POS_SN.ReadOnly = true;
            this.AL2POS_SN.Size = new System.Drawing.Size(238, 29);
            this.AL2POS_SN.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 254);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(101, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "AL2POS_SN";
            // 
            // AL2POS_RC
            // 
            this.AL2POS_RC.Location = new System.Drawing.Point(126, 216);
            this.AL2POS_RC.Name = "AL2POS_RC";
            this.AL2POS_RC.ReadOnly = true;
            this.AL2POS_RC.Size = new System.Drawing.Size(238, 29);
            this.AL2POS_RC.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 219);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(101, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "AL2POS_RC";
            // 
            // AL_AMT
            // 
            this.AL_AMT.Location = new System.Drawing.Point(126, 181);
            this.AL_AMT.Name = "AL_AMT";
            this.AL_AMT.Size = new System.Drawing.Size(238, 29);
            this.AL_AMT.TabIndex = 9;
            this.AL_AMT.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 184);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "AL_AMT";
            // 
            // POS_FLG
            // 
            this.POS_FLG.Location = new System.Drawing.Point(126, 146);
            this.POS_FLG.Name = "POS_FLG";
            this.POS_FLG.Size = new System.Drawing.Size(238, 29);
            this.POS_FLG.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 149);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "POS_FLG";
            // 
            // MERC_FLG
            // 
            this.MERC_FLG.Location = new System.Drawing.Point(126, 111);
            this.MERC_FLG.Name = "MERC_FLG";
            this.MERC_FLG.Size = new System.Drawing.Size(238, 29);
            this.MERC_FLG.TabIndex = 5;
            this.MERC_FLG.Text = "SET";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 114);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "MERC_FLG";
            // 
            // ICC_NO
            // 
            this.ICC_NO.Location = new System.Drawing.Point(126, 76);
            this.ICC_NO.Name = "ICC_NO";
            this.ICC_NO.Size = new System.Drawing.Size(238, 29);
            this.ICC_NO.TabIndex = 3;
            this.ICC_NO.Text = "0417149984000007";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 79);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "ICC_NO";
            // 
            // COM_TYPE
            // 
            this.COM_TYPE.Location = new System.Drawing.Point(126, 41);
            this.COM_TYPE.Name = "COM_TYPE";
            this.COM_TYPE.Size = new System.Drawing.Size(238, 29);
            this.COM_TYPE.TabIndex = 1;
            this.COM_TYPE.Text = "0731";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM_TYPE";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RunQuery);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(527, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查詢";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RunQuery
            // 
            this.RunQuery.Location = new System.Drawing.Point(407, 19);
            this.RunQuery.Name = "RunQuery";
            this.RunQuery.Size = new System.Drawing.Size(82, 34);
            this.RunQuery.TabIndex = 3;
            this.RunQuery.Text = "執行";
            this.RunQuery.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 430);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 356);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 29);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "000251";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 359);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(94, 21);
            this.label11.TabIndex = 18;
            this.label11.Text = "STORE_NO";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 321);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(238, 29);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "01";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 324);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(66, 21);
            this.label12.TabIndex = 16;
            this.label12.Text = "REG_ID";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(126, 286);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(238, 29);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "8604042B6A9F2980";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 289);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(98, 21);
            this.label13.TabIndex = 14;
            this.label13.Text = "READER_ID";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(126, 251);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(238, 29);
            this.textBox4.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 254);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(101, 21);
            this.label14.TabIndex = 12;
            this.label14.Text = "AL2POS_SN";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(126, 216);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(238, 29);
            this.textBox5.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 219);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label15.Size = new System.Drawing.Size(101, 21);
            this.label15.TabIndex = 10;
            this.label15.Text = "AL2POS_RC";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(126, 181);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(238, 29);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "1000";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 184);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label16.Size = new System.Drawing.Size(74, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "AL_AMT";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(126, 146);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(238, 29);
            this.textBox7.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 149);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(78, 21);
            this.label17.TabIndex = 6;
            this.label17.Text = "POS_FLG";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(126, 111);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(238, 29);
            this.textBox8.TabIndex = 5;
            this.textBox8.Text = "SET";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 114);
            this.label18.Name = "label18";
            this.label18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label18.Size = new System.Drawing.Size(93, 21);
            this.label18.TabIndex = 4;
            this.label18.Text = "MERC_FLG";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(126, 76);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(238, 29);
            this.textBox9.TabIndex = 3;
            this.textBox9.Text = "0417149984000007";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 79);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label19.Size = new System.Drawing.Size(70, 21);
            this.label19.TabIndex = 2;
            this.label19.Text = "ICC_NO";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(126, 41);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(238, 29);
            this.textBox10.TabIndex = 1;
            this.textBox10.Text = "0731";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 44);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label20.Size = new System.Drawing.Size(95, 21);
            this.label20.TabIndex = 0;
            this.label20.Text = "COM_TYPE";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(527, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Txlog";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(555, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel1.Text = "System Time";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // GpConnect
            // 
            this.GpConnect.Controls.Add(this.ConnectStatus);
            this.GpConnect.Controls.Add(this.Connect);
            this.GpConnect.Controls.Add(this.ConnectPort);
            this.GpConnect.Controls.Add(this.ConnectIP);
            this.GpConnect.Controls.Add(this.label22);
            this.GpConnect.Controls.Add(this.label21);
            this.GpConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.GpConnect.Location = new System.Drawing.Point(0, 0);
            this.GpConnect.Name = "GpConnect";
            this.GpConnect.Size = new System.Drawing.Size(555, 53);
            this.GpConnect.TabIndex = 5;
            this.GpConnect.TabStop = false;
            this.GpConnect.Text = "Connect";
            // 
            // ConnectStatus
            // 
            this.ConnectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectStatus.AutoSize = true;
            this.ConnectStatus.Location = new System.Drawing.Point(367, 22);
            this.ConnectStatus.Name = "ConnectStatus";
            this.ConnectStatus.Size = new System.Drawing.Size(53, 12);
            this.ConnectStatus.TabIndex = 5;
            this.ConnectStatus.Text = "連線狀態";
            // 
            // Connect
            // 
            this.Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Connect.Location = new System.Drawing.Point(286, 17);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 4;
            this.Connect.Text = "連線";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ConnectPort
            // 
            this.ConnectPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectPort.Location = new System.Drawing.Point(206, 17);
            this.ConnectPort.Name = "ConnectPort";
            this.ConnectPort.Size = new System.Drawing.Size(74, 22);
            this.ConnectPort.TabIndex = 3;
            this.ConnectPort.Text = "6101";
            // 
            // ConnectIP
            // 
            this.ConnectIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectIP.Location = new System.Drawing.Point(51, 17);
            this.ConnectIP.Name = "ConnectIP";
            this.ConnectIP.Size = new System.Drawing.Size(100, 22);
            this.ConnectIP.TabIndex = 2;
            this.ConnectIP.Text = "10.27.68.155";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(176, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 12);
            this.label22.TabIndex = 1;
            this.label22.Text = "Port";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "連結IP";
            // 
            // UI_SocketClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 557);
            this.Controls.Add(this.GpConnect);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "UI_SocketClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SocketClient";
            this.Load += new System.EventHandler(this.SocketClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.GpConnect.ResumeLayout(false);
            this.GpConnect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AL_AMT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox POS_FLG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MERC_FLG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ICC_NO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox COM_TYPE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox STORE_NO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox REG_ID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox READER_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AL2POS_SN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AL2POS_RC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button RunAutoload;
        private System.Windows.Forms.Button RunQuery;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox GpConnect;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox ConnectPort;
        private System.Windows.Forms.TextBox ConnectIP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label ConnectStatus;
    }
}

