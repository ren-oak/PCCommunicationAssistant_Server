namespace TCPServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.serverport = new System.Windows.Forms.TextBox();
            this.showinfo = new System.Windows.Forms.RichTextBox();
            this.startService = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.userList = new System.Windows.Forms.ListBox();
            this.butExit = new System.Windows.Forms.Button();
            this.serCle = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号：";
            // 
            // serverport
            // 
            this.serverport.Location = new System.Drawing.Point(62, 40);
            this.serverport.Name = "serverport";
            this.serverport.Size = new System.Drawing.Size(54, 21);
            this.serverport.TabIndex = 1;
            this.serverport.Text = "5678";
            // 
            // showinfo
            // 
            this.showinfo.Location = new System.Drawing.Point(12, 65);
            this.showinfo.Name = "showinfo";
            this.showinfo.Size = new System.Drawing.Size(270, 266);
            this.showinfo.TabIndex = 2;
            this.showinfo.Text = "";
            // 
            // startService
            // 
            this.startService.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startService.Location = new System.Drawing.Point(12, 0);
            this.startService.Name = "startService";
            this.startService.Size = new System.Drawing.Size(121, 34);
            this.startService.TabIndex = 3;
            this.startService.Text = "开始服务";
            this.startService.UseVisualStyleBackColor = true;
            this.startService.Click += new System.EventHandler(this.startService_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(287, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuBar
            // 
            this.statuBar.Name = "statuBar";
            this.statuBar.Size = new System.Drawing.Size(72, 17);
            this.statuBar.Text = "未启动服务";
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.ItemHeight = 12;
            this.userList.Location = new System.Drawing.Point(122, 47);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(11, 4);
            this.userList.TabIndex = 7;
            // 
            // butExit
            // 
            this.butExit.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butExit.Location = new System.Drawing.Point(189, 337);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(93, 25);
            this.butExit.TabIndex = 11;
            this.butExit.Text = "退出\r\n";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // serCle
            // 
            this.serCle.Location = new System.Drawing.Point(14, 337);
            this.serCle.Name = "serCle";
            this.serCle.Size = new System.Drawing.Size(91, 25);
            this.serCle.TabIndex = 14;
            this.serCle.Text = "清空";
            this.serCle.UseVisualStyleBackColor = true;
            this.serCle.Click += new System.EventHandler(this.serCle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 391);
            this.Controls.Add(this.serCle);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startService);
            this.Controls.Add(this.showinfo);
            this.Controls.Add(this.serverport);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverport;
        private System.Windows.Forms.RichTextBox showinfo;
        private System.Windows.Forms.Button startService;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statuBar;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button serCle;
    }
}

