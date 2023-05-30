
namespace test1
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.passtext = new System.Windows.Forms.TextBox();
            this.Logintext = new System.Windows.Forms.TextBox();
            this.Butlog = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.passtext);
            this.panel1.Controls.Add(this.Logintext);
            this.panel1.Controls.Add(this.Butlog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 146);
            this.panel1.TabIndex = 0;
            // 
            // passtext
            // 
            this.passtext.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.passtext.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passtext.ForeColor = System.Drawing.Color.White;
            this.passtext.Location = new System.Drawing.Point(210, 34);
            this.passtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passtext.Name = "passtext";
            this.passtext.Size = new System.Drawing.Size(148, 38);
            this.passtext.TabIndex = 3;
            this.passtext.Tag = "";
            this.passtext.Text = "Password";
            this.passtext.Enter += new System.EventHandler(this.passtext_Enter);
            this.passtext.Leave += new System.EventHandler(this.passtext_Leave);
            // 
            // Logintext
            // 
            this.Logintext.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Logintext.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logintext.ForeColor = System.Drawing.Color.White;
            this.Logintext.Location = new System.Drawing.Point(9, 34);
            this.Logintext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Logintext.Multiline = true;
            this.Logintext.Name = "Logintext";
            this.Logintext.Size = new System.Drawing.Size(149, 36);
            this.Logintext.TabIndex = 2;
            this.Logintext.Text = "Login";
            this.Logintext.Enter += new System.EventHandler(this.Logintext_Enter);
            this.Logintext.Leave += new System.EventHandler(this.Logintext_Leave);
            // 
            // Butlog
            // 
            this.Butlog.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Butlog.ForeColor = System.Drawing.Color.Gold;
            this.Butlog.Location = new System.Drawing.Point(144, 75);
            this.Butlog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Butlog.Name = "Butlog";
            this.Butlog.Size = new System.Drawing.Size(78, 39);
            this.Butlog.TabIndex = 1;
            this.Butlog.Text = "войти";
            this.Butlog.UseMnemonic = false;
            this.Butlog.UseVisualStyleBackColor = false;
            this.Butlog.Click += new System.EventHandler(this.Butlog_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 146);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Butlog;
        private System.Windows.Forms.TextBox Logintext;
        private System.Windows.Forms.TextBox passtext;
    }
}