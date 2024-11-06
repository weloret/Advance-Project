namespace TaskCentralFormsApp
{
    partial class MembersPage
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
            labelMembersOf = new Label();
            dgvMembers = new DataGridView();
            panelManager = new Panel();
            btnAdd = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            panelManager.SuspendLayout();
            SuspendLayout();
            // 
            // labelMembersOf
            // 
            labelMembersOf.AutoSize = true;
            labelMembersOf.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelMembersOf.Location = new Point(21, 48);
            labelMembersOf.Name = "labelMembersOf";
            labelMembersOf.Size = new Size(181, 25);
            labelMembersOf.TabIndex = 0;
            labelMembersOf.Text = "Members of Project";
            // 
            // dgvMembers
            // 
            dgvMembers.Anchor = AnchorStyles.None;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(25, 76);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowTemplate.Height = 25;
            dgvMembers.Size = new Size(736, 273);
            dgvMembers.TabIndex = 1;
            // 
            // panelManager
            // 
            panelManager.Controls.Add(btnAdd);
            panelManager.Controls.Add(btnDelete);
            panelManager.Location = new Point(25, 355);
            panelManager.Name = "panelManager";
            panelManager.Size = new Size(218, 47);
            panelManager.TabIndex = 17;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.HotTrack;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.Control;
            btnAdd.Location = new Point(0, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 41);
            btnAdd.TabIndex = 18;
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
            btnDelete.Location = new Point(112, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 41);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            // MembersPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(panelManager);
            Controls.Add(dgvMembers);
            Controls.Add(labelMembersOf);
            Name = "MembersPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MembersPage";
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            panelManager.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMembersOf;
        private DataGridView dgvMembers;
        private Panel panelManager;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnBack;
    }
}