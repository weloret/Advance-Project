namespace TaskCentralFormsApp
{
    partial class TasksPage
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
            dgvTasks = new DataGridView();
            labelTasksOf = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnComments = new Button();
            btnEdit = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // dgvTasks
            // 
            dgvTasks.Anchor = AnchorStyles.None;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(34, 76);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowTemplate.Height = 25;
            dgvTasks.Size = new Size(736, 273);
            dgvTasks.TabIndex = 19;
            // 
            // labelTasksOf
            // 
            labelTasksOf.AutoSize = true;
            labelTasksOf.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelTasksOf.Location = new Point(30, 48);
            labelTasksOf.Name = "labelTasksOf";
            labelTasksOf.Size = new Size(144, 25);
            labelTasksOf.TabIndex = 18;
            labelTasksOf.Text = "Tasks of Project";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.HotTrack;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.Control;
            btnAdd.Location = new Point(33, 355);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 41);
            btnAdd.TabIndex = 22;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.HotTrack;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(319, 355);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 41);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnComments
            // 
            btnComments.BackColor = SystemColors.HotTrack;
            btnComments.FlatStyle = FlatStyle.Flat;
            btnComments.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnComments.ForeColor = SystemColors.Control;
            btnComments.Location = new Point(462, 355);
            btnComments.Name = "btnComments";
            btnComments.Size = new Size(137, 41);
            btnComments.TabIndex = 24;
            btnComments.Text = "Comments";
            btnComments.UseVisualStyleBackColor = false;
            btnComments.Click += btnComments_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(176, 355);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(137, 41);
            btnEdit.TabIndex = 25;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
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
            btnBack.TabIndex = 26;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // TasksPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            Controls.Add(btnComments);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(dgvTasks);
            Controls.Add(labelTasksOf);
            Name = "TasksPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TasksPage";
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTasks;
        private Label labelTasksOf;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnComments;
        private Button btnEdit;
        private Button btnBack;
    }
}