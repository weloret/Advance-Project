namespace TaskCentralFormsApp
{
    partial class editCommentsPage
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
            btnEdit = new Button();
            labelCommentOn = new Label();
            inputComment = new RichTextBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(274, 282);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(106, 41);
            btnEdit.TabIndex = 24;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // labelCommentOn
            // 
            labelCommentOn.AutoSize = true;
            labelCommentOn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCommentOn.Location = new Point(274, 128);
            labelCommentOn.Name = "labelCommentOn";
            labelCommentOn.Size = new Size(171, 25);
            labelCommentOn.TabIndex = 23;
            labelCommentOn.Text = "Comment on Task";
            // 
            // inputComment
            // 
            inputComment.Location = new Point(274, 165);
            inputComment.Name = "inputComment";
            inputComment.Size = new Size(252, 96);
            inputComment.TabIndex = 22;
            inputComment.Text = "";
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
            btnBack.TabIndex = 25;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // editCommentsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            Controls.Add(labelCommentOn);
            Controls.Add(inputComment);
            Name = "editCommentsPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "editCommentsPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEdit;
        private Label labelCommentOn;
        private RichTextBox inputComment;
        private Button btnBack;
    }
}