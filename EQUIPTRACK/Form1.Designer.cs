namespace EQUIPTRACK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.IndianRed;
            txtUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtUsername.ForeColor = SystemColors.MenuBar;
            txtUsername.Location = new Point(337, 408);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(349, 29);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.IndianRed;
            txtPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtPassword.ForeColor = SystemColors.MenuBar;
            txtPassword.Location = new Point(337, 462);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(349, 29);
            txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Impact", 14.25F);
            label2.ForeColor = Color.LemonChiffon;
            label2.Location = new Point(337, 382);
            label2.Name = "label2";
            label2.Size = new Size(89, 23);
            label2.TabIndex = 3;
            label2.Text = "USERNAME";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 14.25F);
            label3.ForeColor = Color.LemonChiffon;
            label3.Location = new Point(337, 436);
            label3.Name = "label3";
            label3.Size = new Size(95, 23);
            label3.TabIndex = 4;
            label3.Text = "PASSWORD";
            // 
            // button2
            // 
            button2.BackColor = Color.Crimson;
            button2.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Info;
            button2.Location = new Point(414, 514);
            button2.Name = "button2";
            button2.Size = new Size(172, 84);
            button2.TabIndex = 6;
            button2.Text = "LOGIN";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1008, 786);
            Controls.Add(button2);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
        private Button button2;
    }
}
