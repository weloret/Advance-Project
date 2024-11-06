namespace TaskCentralFormsApp
{
    partial class TaskCommentsPage
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
            btnDelete = new Button();
            dgvComments = new DataGridView();
            labelCommentsOf = new Label();
            btnEdit = new Button();
            btnAdd = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComments).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.HotTrack;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(255, 358);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 41);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvComments
            // 
            dgvComments.Anchor = AnchorStyles.None;
            dgvComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComments.Location = new Point(34, 76);
            dgvComments.Name = "dgvComments";
            dgvComments.RowTemplate.Height = 25;
            dgvComments.Size = new Size(736, 273);
            dgvComments.TabIndex = 19;
            // 
            // labelCommentsOf
            // 
            labelCommentsOf.AutoSize = true;
            labelCommentsOf.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCommentsOf.Location = new Point(30, 48);
            labelCommentsOf.Name = "labelCommentsOf";
            labelCommentsOf.Size = new Size(169, 25);
            labelCommentsOf.TabIndex = 18;
            labelCommentsOf.Text = "Comments of Task";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(143, 358);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(106, 41);
            btnEdit.TabIndex = 21;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.HotTrack;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.Control;
            btnAdd.Location = new Point(34, 358);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 41);
            btnAdd.TabIndex = 20;
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
            // TaskCommentsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(dgvComments);
            Controls.Add(labelCommentsOf);
            Name = "TaskCommentsPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TaskCommentsPage";
            ((System.ComponentModel.ISupportInitialize)dgvComments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDelete;
        private DataGridView dgvComments;
        private Label labelCommentsOf;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnBack;
    }
}