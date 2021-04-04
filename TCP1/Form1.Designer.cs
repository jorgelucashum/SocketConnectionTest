
namespace TCP1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btncConnect = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(67, 26);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(326, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1:9000";
            // 
            // btncConnect
            // 
            this.btncConnect.Location = new System.Drawing.Point(318, 216);
            this.btncConnect.Name = "btncConnect";
            this.btncConnect.Size = new System.Drawing.Size(75, 23);
            this.btncConnect.TabIndex = 1;
            this.btncConnect.Text = "Conectar";
            this.btncConnect.UseVisualStyleBackColor = true;
            this.btncConnect.Click += new System.EventHandler(this.btncConnect_Click);
            // 
            // txtServer
            // 
            this.txtServer.AutoSize = true;
            this.txtServer.Location = new System.Drawing.Point(12, 29);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(49, 13);
            this.txtServer.TabIndex = 2;
            this.txtServer.Text = "Servidor:";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(67, 52);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(326, 112);
            this.txtInfo.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(67, 170);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(326, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // txtMsg
            // 
            this.txtMsg.AutoSize = true;
            this.txtMsg.Location = new System.Drawing.Point(-1, 173);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(62, 13);
            this.txtMsg.TabIndex = 2;
            this.txtMsg.Text = "Mensagem:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(237, 216);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 251);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btncConnect);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtIP);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btncConnect;
        private System.Windows.Forms.Label txtServer;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label txtMsg;
        private System.Windows.Forms.Button btnSend;
    }
}

