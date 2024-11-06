namespace TaskCentralFormsApp
{
    partial class createProjectPage
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
            btnCreate = new Button();
            label2 = new Label();
            label1 = new Label();
            inputProjectName = new TextBox();
            inputDescription = new RichTextBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.BackColor = SystemColors.HotTrack;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreate.ForeColor = SystemColors.Control;
            btnCreate.Location = new Point(291, 317);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(106, 41);
            btnCreate.TabIndex = 9;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(291, 201);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 8;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(291, 134);
            label1.Name = "label1";
            label1.Size = new Size(129, 25);
            label1.TabIndex = 6;
            label1.Text = "Project Name";
            // 
            // inputProjectName
            // 
            inputProjectName.Location = new Point(291, 162);
            inputProjectName.Name = "inputProjectName";
            inputProjectName.Size = new Size(218, 23);
            inputProjectName.TabIndex = 5;
            // 
            // inputDescription
            // 
            inputDescription.Location = new Point(291, 229);
            inputDescription.Name = "inputDescription";
            inputDescription.Size = new Size(218, 70);
            inputDescription.TabIndex = 10;
            inputDescription.Text = "";
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
            // createProjectPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(inputDescription);
            Controls.Add(btnCreate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(inputProjectName);
            Name = "createProjectPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "createProjectPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private Label label2;
        private Label label1;
        private TextBox inputProjectName;
        private RichTextBox inputDescription;
        private Button btnBack;
    }
}