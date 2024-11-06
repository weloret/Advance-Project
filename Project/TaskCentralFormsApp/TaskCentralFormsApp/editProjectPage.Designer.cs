namespace TaskCentralFormsApp
{
    partial class editProjectPage
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
            inputDescription = new RichTextBox();
            btnEdit = new Button();
            label2 = new Label();
            label1 = new Label();
            inputProjectName = new TextBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // inputDescription
            // 
            inputDescription.Location = new Point(291, 208);
            inputDescription.Name = "inputDescription";
            inputDescription.Size = new Size(218, 70);
            inputDescription.TabIndex = 15;
            inputDescription.Text = "";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(291, 296);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(106, 41);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(291, 180);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 13;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(291, 113);
            label1.Name = "label1";
            label1.Size = new Size(129, 25);
            label1.TabIndex = 12;
            label1.Text = "Project Name";
            // 
            // inputProjectName
            // 
            inputProjectName.Location = new Point(291, 141);
            inputProjectName.Name = "inputProjectName";
            inputProjectName.Size = new Size(218, 23);
            inputProjectName.TabIndex = 11;
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
            // editProjectPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(inputDescription);
            Controls.Add(btnEdit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(inputProjectName);
            Name = "editProjectPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "editProjectPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox inputDescription;
        private Button btnEdit;
        private Label label2;
        private Label label1;
        private TextBox inputProjectName;
        private Button btnBack;
    }
}