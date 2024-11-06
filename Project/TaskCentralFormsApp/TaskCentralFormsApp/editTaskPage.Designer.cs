namespace TaskCentralFormsApp
{
    partial class editTaskPage
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
            label5 = new Label();
            comboMember = new ComboBox();
            label4 = new Label();
            inputDeadline = new DateTimePicker();
            label3 = new Label();
            comboStatus = new ComboBox();
            inputDescription = new RichTextBox();
            btnEdit = new Button();
            label2 = new Label();
            label1 = new Label();
            inputTaskName = new TextBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(291, 311);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 32;
            label5.Text = "Member";
            // 
            // comboMember
            // 
            comboMember.FormattingEnabled = true;
            comboMember.Items.AddRange(new object[] { "Pending", "Completed" });
            comboMember.Location = new Point(292, 339);
            comboMember.Name = "comboMember";
            comboMember.Size = new Size(217, 23);
            comboMember.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(293, 248);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 30;
            label4.Text = "Deadline";
            // 
            // inputDeadline
            // 
            inputDeadline.Location = new Point(293, 276);
            inputDeadline.Name = "inputDeadline";
            inputDeadline.Size = new Size(217, 23);
            inputDeadline.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(292, 184);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 28;
            label3.Text = "Status";
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(293, 212);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(217, 23);
            comboStatus.TabIndex = 27;
            // 
            // inputDescription
            // 
            inputDescription.Location = new Point(292, 126);
            inputDescription.Name = "inputDescription";
            inputDescription.Size = new Size(218, 48);
            inputDescription.TabIndex = 26;
            inputDescription.Text = "";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(291, 379);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(106, 41);
            btnEdit.TabIndex = 25;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(292, 98);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 24;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(292, 31);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 23;
            label1.Text = "Task Name";
            // 
            // inputTaskName
            // 
            inputTaskName.Location = new Point(292, 59);
            inputTaskName.Name = "inputTaskName";
            inputTaskName.Size = new Size(218, 23);
            inputTaskName.TabIndex = 22;
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
            btnBack.TabIndex = 33;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // editTaskPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(label5);
            Controls.Add(comboMember);
            Controls.Add(label4);
            Controls.Add(inputDeadline);
            Controls.Add(label3);
            Controls.Add(comboStatus);
            Controls.Add(inputDescription);
            Controls.Add(btnEdit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(inputTaskName);
            Name = "editTaskPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "editTaskPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ComboBox comboMember;
        private Label label4;
        private DateTimePicker inputDeadline;
        private Label label3;
        private ComboBox comboStatus;
        private RichTextBox inputDescription;
        private Button btnEdit;
        private Label label2;
        private Label label1;
        private TextBox inputTaskName;
        private Button btnBack;
    }
}