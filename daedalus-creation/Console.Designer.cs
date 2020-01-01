namespace daedalus_creation
{
    partial class Console_Form
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
            this.txt_cmd = new System.Windows.Forms.TextBox();
            this.rtxt_log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_cmd
            // 
            this.txt_cmd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_cmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cmd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_cmd.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cmd.ForeColor = System.Drawing.Color.White;
            this.txt_cmd.Location = new System.Drawing.Point(0, 245);
            this.txt_cmd.Name = "txt_cmd";
            this.txt_cmd.Size = new System.Drawing.Size(584, 25);
            this.txt_cmd.TabIndex = 2;
            // 
            // rtxt_log
            // 
            this.rtxt_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtxt_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxt_log.BulletIndent = 1;
            this.rtxt_log.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtxt_log.ForeColor = System.Drawing.Color.White;
            this.rtxt_log.Location = new System.Drawing.Point(0, 0);
            this.rtxt_log.Name = "rtxt_log";
            this.rtxt_log.ReadOnly = true;
            this.rtxt_log.Size = new System.Drawing.Size(584, 220);
            this.rtxt_log.TabIndex = 3;
            this.rtxt_log.Text = "";
            // 
            // Console_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(584, 270);
            this.Controls.Add(this.txt_cmd);
            this.Controls.Add(this.rtxt_log);
            this.Name = "Console_Form";
            this.Text = "Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cmd;
        private System.Windows.Forms.RichTextBox rtxt_log;
    }
}