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
    public partial class addCommentsPage : Form
    {
        TaskCentralDBContext context;
        TaskCentralClassLibrary.Task selectedTask;
        public addCommentsPage(TaskCentralDBContext context, TaskCentralClassLibrary.Task selectedTask)
        {
            InitializeComponent();
            this.context = context;
            this.selectedTask = selectedTask;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(inputComment.Text))
                {
                    MessageBox.Show("Cannot add an empty comment");
                    return;
                }
                Comment newComment = new Comment();
                newComment.Text = inputComment.Text;
                newComment.DateTime = DateTime.Now;
                newComment.UserId = Global.loggedUser.UserId;
                newComment.TaskId = selectedTask.TaskId;

                context.Comments.Add(newComment);
                context.SaveChanges();
                this.Close();
            }catch(Exception ex){
                Log lg = Global.ExceptionHandler(ex, "addCommentsPage");
                context.Add(lg);
                context.SaveChanges();
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
