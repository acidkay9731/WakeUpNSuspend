namespace WakeUpANDSuspend
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.nudWakeUpTime = new System.Windows.Forms.NumericUpDown();
            this.nudWakeUpMin = new System.Windows.Forms.NumericUpDown();
            this.nudSuspendMin = new System.Windows.Forms.NumericUpDown();
            this.nudSuspendTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetTimer = new System.Windows.Forms.Button();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSuspend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSuspendMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSuspendTime)).BeginInit();
            this.contextMenuStripNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wake Up At:";
            // 
            // nudWakeUpTime
            // 
            this.nudWakeUpTime.Location = new System.Drawing.Point(89, 10);
            this.nudWakeUpTime.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudWakeUpTime.Name = "nudWakeUpTime";
            this.nudWakeUpTime.Size = new System.Drawing.Size(38, 21);
            this.nudWakeUpTime.TabIndex = 1;
            // 
            // nudWakeUpMin
            // 
            this.nudWakeUpMin.Location = new System.Drawing.Point(133, 10);
            this.nudWakeUpMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudWakeUpMin.Name = "nudWakeUpMin";
            this.nudWakeUpMin.Size = new System.Drawing.Size(38, 21);
            this.nudWakeUpMin.TabIndex = 2;
            // 
            // nudSuspendMin
            // 
            this.nudSuspendMin.Location = new System.Drawing.Point(133, 37);
            this.nudSuspendMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudSuspendMin.Name = "nudSuspendMin";
            this.nudSuspendMin.Size = new System.Drawing.Size(38, 21);
            this.nudSuspendMin.TabIndex = 5;
            // 
            // nudSuspendTime
            // 
            this.nudSuspendTime.Location = new System.Drawing.Point(89, 37);
            this.nudSuspendTime.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudSuspendTime.Name = "nudSuspendTime";
            this.nudSuspendTime.Size = new System.Drawing.Size(38, 21);
            this.nudSuspendTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Suspend At:";
            // 
            // btnSetTimer
            // 
            this.btnSetTimer.Location = new System.Drawing.Point(12, 61);
            this.btnSetTimer.Name = "btnSetTimer";
            this.btnSetTimer.Size = new System.Drawing.Size(72, 23);
            this.btnSetTimer.TabIndex = 6;
            this.btnSetTimer.Text = "SetTimer";
            this.btnSetTimer.UseVisualStyleBackColor = true;
            this.btnSetTimer.Click += new System.EventHandler(this.btnSetTimer_Click);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 10000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiClose});
            this.contextMenuStripNotify.Name = "contextMenuStrip1";
            this.contextMenuStripNotify.Size = new System.Drawing.Size(99, 48);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(98, 22);
            this.tsmiShow.Text = "보기";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(98, 22);
            this.tsmiClose.Text = "종료";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "WakeUp N Suspend";
            this.notifyIconMain.Visible = true;
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(99, 61);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(72, 23);
            this.btnSuspend.TabIndex = 7;
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 90);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnSetTimer);
            this.Controls.Add(this.nudSuspendMin);
            this.Controls.Add(this.nudSuspendTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudWakeUpMin);
            this.Controls.Add(this.nudWakeUpTime);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.Text = "WakeUp N Suspend";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSuspendMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSuspendTime)).EndInit();
            this.contextMenuStripNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudWakeUpTime;
        private System.Windows.Forms.NumericUpDown nudWakeUpMin;
        private System.Windows.Forms.NumericUpDown nudSuspendMin;
        private System.Windows.Forms.NumericUpDown nudSuspendTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetTimer;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Button btnSuspend;
    }
}

