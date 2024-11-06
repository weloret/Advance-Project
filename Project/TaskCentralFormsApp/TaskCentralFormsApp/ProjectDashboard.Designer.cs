namespace TaskCentralFormsApp
{
    partial class ProjectDashboard
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
            tableLayoutPanel1 = new TableLayoutPanel();
            labelOverDue = new Label();
            labelPending = new Label();
            labelCompleted = new Label();
            labelTotal = new Label();
            btnTasks = new Button();
            buttonMembers = new Button();
            labelDashboard = new Label();
            listTasksMember = new ListBox();
            label1 = new Label();
            btnBack = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.HotTrack;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(labelOverDue, 0, 0);
            tableLayoutPanel1.Controls.Add(labelPending, 0, 1);
            tableLayoutPanel1.Controls.Add(labelCompleted, 0, 2);
            tableLayoutPanel1.Controls.Add(labelTotal, 0, 3);
            tableLayoutPanel1.ForeColor = SystemColors.Control;
            tableLayoutPanel1.Location = new Point(24, 157);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(301, 231);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelOverDue
            // 
            labelOverDue.Anchor = AnchorStyles.Left;
            labelOverDue.AutoSize = true;
            labelOverDue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelOverDue.Location = new Point(3, 18);
            labelOverDue.Name = "labelOverDue";
            labelOverDue.Size = new Size(148, 20);
            labelOverDue.TabIndex = 11;
            labelOverDue.Text = "Overdue Tasks: 0";
            labelOverDue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPending
            // 
            labelPending.Anchor = AnchorStyles.Left;
            labelPending.AutoSize = true;
            labelPending.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelPending.Location = new Point(3, 75);
            labelPending.Name = "labelPending";
            labelPending.Size = new Size(146, 20);
            labelPending.TabIndex = 10;
            labelPending.Text = "Pending Tasks: 0";
            labelPending.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCompleted
            // 
            labelCompleted.Anchor = AnchorStyles.Left;
            labelCompleted.AutoSize = true;
            labelCompleted.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelCompleted.Location = new Point(3, 132);
            labelCompleted.Name = "labelCompleted";
            labelCompleted.Size = new Size(167, 20);
            labelCompleted.TabIndex = 9;
            labelCompleted.Text = "Completed Tasks: 0";
            labelCompleted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTotal
            // 
            labelTotal.Anchor = AnchorStyles.Left;
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotal.Location = new Point(3, 191);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(121, 20);
            labelTotal.TabIndex = 8;
            labelTotal.Text = "Total Tasks: 0";
            labelTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = SystemColors.HotTrack;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTasks.ForeColor = SystemColors.Control;
            btnTasks.Location = new Point(25, 99);
            btnTasks.Name = "btnTasks";
            btnTasks.Size = new Size(148, 41);
            btnTasks.TabIndex = 15;
            btnTasks.Text = "Tasks";
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += btnTasks_Click;
            // 
            // buttonMembers
            // 
            buttonMembers.BackColor = SystemColors.HotTrack;
            buttonMembers.FlatStyle = FlatStyle.Flat;
            buttonMembers.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMembers.ForeColor = SystemColors.Control;
            buttonMembers.Location = new Point(179, 99);
            buttonMembers.Name = "buttonMembers";
            buttonMembers.Size = new Size(146, 41);
            buttonMembers.TabIndex = 16;
            buttonMembers.Text = "Members";
            buttonMembers.UseVisualStyleBackColor = false;
            buttonMembers.Click += buttonMembers_Click;
            // 
            // labelDashboard
            // 
            labelDashboard.AutoSize = true;
            labelDashboard.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelDashboard.Location = new Point(25, 51);
            labelDashboard.Name = "labelDashboard";
            labelDashboard.Size = new Size(209, 25);
            labelDashboard.TabIndex = 17;
            labelDashboard.Text = "Dashboard for Project";
            // 
            // listTasksMember
            // 
            listTasksMember.FormattingEnabled = true;
            listTasksMember.ItemHeight = 15;
            listTasksMember.Location = new Point(350, 159);
            listTasksMember.Name = "listTasksMember";
            listTasksMember.Size = new Size(303, 229);
            listTasksMember.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(350, 115);
            label1.Name = "label1";
            label1.Size = new Size(172, 25);
            label1.TabIndex = 19;
            label1.Text = "Tasks Per Member";
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
            // ProjectDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(listTasksMember);
            Controls.Add(labelDashboard);
            Controls.Add(buttonMembers);
            Controls.Add(btnTasks);
            Controls.Add(tableLayoutPanel1);
            Name = "ProjectDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProjectDashboard";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelOverDue;
        private Label labelPending;
        private Label labelCompleted;
        private Label labelTotal;
        private Button btnTasks;
        private Button buttonMembers;
        private Label labelDashboard;
        private ListBox listTasksMember;
        private Label label1;
        private Button btnBack;
    }
}