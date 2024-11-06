namespace TaskCentralFormsApp
{
    partial class ProjectListPage
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
            dgvProjects = new DataGridView();
            btnCreateProject = new Button();
            btnDashboard = new Button();
            panelManager = new Panel();
            btnEdit = new Button();
            btnDelete = new Button();
            textBoxSearch = new TextBox();
            label1 = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            panelManager.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProjects
            // 
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(117, 98);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.RowTemplate.Height = 25;
            dgvProjects.Size = new Size(606, 273);
            dgvProjects.TabIndex = 0;
            dgvProjects.SelectionChanged += dgvProjects_SelectionChanged;
            // 
            // btnCreateProject
            // 
            btnCreateProject.BackColor = SystemColors.HotTrack;
            btnCreateProject.FlatStyle = FlatStyle.Flat;
            btnCreateProject.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateProject.ForeColor = SystemColors.Control;
            btnCreateProject.Location = new Point(570, 51);
            btnCreateProject.Name = "btnCreateProject";
            btnCreateProject.Size = new Size(153, 41);
            btnCreateProject.TabIndex = 5;
            btnCreateProject.Text = "Create Project";
            btnCreateProject.UseVisualStyleBackColor = false;
            btnCreateProject.Click += btnCreateProject_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = SystemColors.HotTrack;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDashboard.ForeColor = SystemColors.Control;
            btnDashboard.Location = new Point(582, 383);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(141, 41);
            btnDashboard.TabIndex = 7;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panelManager
            // 
            panelManager.Controls.Add(btnEdit);
            panelManager.Controls.Add(btnDelete);
            panelManager.Location = new Point(117, 377);
            panelManager.Name = "panelManager";
            panelManager.Size = new Size(189, 52);
            panelManager.TabIndex = 8;
            panelManager.Visible = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(86, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 41);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.HotTrack;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(0, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 41);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(117, 64);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(258, 23);
            textBoxSearch.TabIndex = 9;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(117, 40);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 10;
            label1.Text = "Search";
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
            // ProjectListPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(textBoxSearch);
            Controls.Add(panelManager);
            Controls.Add(btnDashboard);
            Controls.Add(btnCreateProject);
            Controls.Add(dgvProjects);
            Name = "ProjectListPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProjectListPage";
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            panelManager.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProjects;
        private Button btnCreateProject;
        private Button btnDashboard;
        private Panel panelManager;
        private Button btnEdit;
        private Button btnDelete;
        private TextBox textBoxSearch;
        private Label label1;
        private Button btnBack;
    }
}