namespace TaskCentralFormsApp
{
    partial class LoginPage
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
            inputEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            InputPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // inputEmail
            // 
            inputEmail.Location = new Point(291, 123);
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new Size(218, 23);
            inputEmail.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(291, 95);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(291, 165);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // InputPassword
            // 
            InputPassword.Location = new Point(291, 193);
            InputPassword.Name = "InputPassword";
            InputPassword.PasswordChar = '*';
            InputPassword.Size = new Size(218, 23);
            InputPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.HotTrack;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(291, 236);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(106, 41);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(InputPassword);
            Controls.Add(label1);
            Controls.Add(inputEmail);
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputEmail;
        private Label label1;
        private Label label2;
        private TextBox InputPassword;
        private Button btnLogin;
    }
}