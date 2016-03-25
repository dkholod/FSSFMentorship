namespace SimpleEditor
{
    partial class MainForm
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.tbx_Text = new System.Windows.Forms.TextBox();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(293, 44);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(293, 85);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(75, 23);
            this.btn_Reload.TabIndex = 1;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // tbx_Text
            // 
            this.tbx_Text.Location = new System.Drawing.Point(12, 12);
            this.tbx_Text.Multiline = true;
            this.tbx_Text.Name = "tbx_Text";
            this.tbx_Text.Size = new System.Drawing.Size(275, 207);
            this.tbx_Text.TabIndex = 2;
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.Items.AddRange(new object[] {
            "Started"});
            this.lbxLog.Location = new System.Drawing.Point(395, 33);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(146, 186);
            this.lbxLog.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Commands log";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(294, 125);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 240);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.tbx_Text);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_Save);
            this.Name = "MainForm";
            this.Text = "Simple editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.TextBox tbx_Text;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearLog;
    }
}

