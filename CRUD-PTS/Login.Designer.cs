namespace CRUD_PTS
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
            panel1 = new Panel();
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 110);
            panel1.TabIndex = 0;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(38, 146);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(162, 27);
            txtUser.TabIndex = 1;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(38, 209);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(162, 27);
            txtPass.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(38, 247);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(65, 35);
            label1.Name = "label1";
            label1.Size = new Size(109, 40);
            label1.TabIndex = 4;
            label1.Text = "Admin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 123);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 4;
            label2.Text = "Username :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 186);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 5;
            label3.Text = "Password :";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 301);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(panel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}