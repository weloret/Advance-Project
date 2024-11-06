namespace TaskCentralFormsApp
{
    partial class addCommentsPage
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
            inputComment = new RichTextBox();
            labelCommentOn = new Label();
            btnAdd = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // inputComment
            // 
            inputComment.Location = new Point(261, 159);
            inputComment.Name = "inputComment";
            inputComment.Size = new Size(252, 96);
            inputComment.TabIndex = 0;
            inputComment.Text = "";
            // 
            // labelCommentOn
            // 
            labelCommentOn.AutoSize = true;
            labelCommentOn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCommentOn.Location = new Point(261, 122);
            labelCommentOn.Name = "labelCommentOn";
            labelCommentOn.Size = new Size(171, 25);
            labelCommentOn.TabIndex = 1;
            labelCommentOn.Text = "Comment on Task";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.HotTrack;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.Control;
            btnAdd.Location = new Point(261, 276);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 41);
            btnAdd.TabIndex = 21;
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
            btnBack.TabIndex = 23;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // addCommentsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(labelCommentOn);
            Controls.Add(inputComment);
            Name = "addCommentsPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addCommentsPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox inputComment;
        private Label labelCommentOn;
        private Button btnAdd;
        private Button btnBack;
    }
}