namespace TaskCentralFormsApp
{
    partial class addMemberForm
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
            comboUser = new ComboBox();
            label1 = new Label();
            btnAdd = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // comboUser
            // 
            comboUser.FormattingEnabled = true;
            comboUser.Location = new Point(277, 182);
            comboUser.Name = "comboUser";
            comboUser.Size = new Size(248, 23);
            comboUser.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(277, 154);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 13;
            label1.Text = "User";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.HotTrack;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.Control;
            btnAdd.Location = new Point(277, 220);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 41);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.HotTrack;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.ForeColor = SystemColors.Control;
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 32);
            btnBack.TabIndex = 24;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // addMemberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(comboUser);
            Name = "addMemberForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addMemberForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboUser;
        private Label label1;
        private Button btnAdd;
        private Button btnBack;
    }
}