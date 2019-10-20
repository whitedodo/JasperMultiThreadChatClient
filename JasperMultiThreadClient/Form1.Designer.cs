namespace JasperMultiThreadClient
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
            this.components = new System.ComponentModel.Container();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.lblNickname = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessages.Location = new System.Drawing.Point(12, 80);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(557, 223);
            this.txtMessages.TabIndex = 2;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(13, 55);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(38, 12);
            this.lblServerStatus.TabIndex = 2;
            this.lblServerStatus.Text = "label1";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(12, 322);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(459, 21);
            this.txtSend.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(477, 321);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "보내기(Send)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(375, 54);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(96, 12);
            this.lblNickname.TabIndex = 5;
            this.lblNickname.Text = "별명(Nickname)";
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(475, 50);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(94, 21);
            this.txtNickname.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 354);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.txtMessages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.TextBox txtNickname;
    }
}

