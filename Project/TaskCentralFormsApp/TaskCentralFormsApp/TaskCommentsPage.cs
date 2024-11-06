using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskCentralClassLibrary;

namespace TaskCentralFormsApp
{
    public partial class TaskCommentsPage : Form
    {
        TaskCentralDBContext context;
        TaskCentralClassLibrary.Task selectedTask;
        public TaskCommentsPage(TaskCentralDBContext context, TaskCentralClassLibrary.Task selectedTask)
        {
            InitializeComponent();
            this.context = context;
            this.selectedTask = selectedTask;

            listComments();
        }
        public Comment? getSelectedComment()
        {
            if (dgvComments.SelectedCells.Count > 0)
            {
                return (Comment)dgvComments.SelectedCells[0].OwningRow.DataBoundItem;
            }
            return null;

        }
        public void listComments()
        {
            dgvComments.DataSource = context.Comments.Where(c => c.TaskId == selectedTask.TaskId).ToList();
            foreach (DataGridViewColumn column in dgvComments.Columns)
            {
                if (column.Name != "UserId" && column.Name != "Text" && column.Name != "DateTime")
                {
                    column.Visible = false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addCommentsPage addComment = new addCommentsPage(context, selectedTask);
            this.Hide();
            addComment.ShowDialog();
            this.Show();
            listComments();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Comment selectedComment = getSelectedComment();
            if (selectedComment != null)
            {
                editCommentsPage editComment = new editCommentsPage(context, selectedComment);
                this.Hide();
                editComment.ShowDialog();
                this.Show();
                listComments();

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Comment selectedComment = getSelectedComment();
            if (selectedComment != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete Comment " + selectedComment.CommentId + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.Comments.Remove(selectedComment);
                        context.SaveChanges();
                        listComments();
                    }
                    catch (Exception ex)
                    {
                        Log lg = Global.ExceptionHandler(ex, "TaskCommentsPage");
                        context.Add(lg);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
