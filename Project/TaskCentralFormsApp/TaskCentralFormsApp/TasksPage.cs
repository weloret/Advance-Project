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
    public partial class TasksPage : Form
    {
        TaskCentralDBContext context;
        public TasksPage(TaskCentralDBContext context)
        {
            InitializeComponent();
            this.context = context;
            labelTasksOf.Text = "Tasks of " + Global.selectedProject.ProjectName;
            listTasks();
        }
        public TaskCentralClassLibrary.Task? getSelectedTask()
        {
            if (dgvTasks.SelectedCells.Count > 0)
            {
                return (TaskCentralClassLibrary.Task)dgvTasks.SelectedCells[0].OwningRow.DataBoundItem;
            }
            return null;

        }
        public void listTasks()
        {
            dgvTasks.DataSource = context.Tasks.Where(t => t.ProjectId == Global.selectedProject.ProjectId).ToList();
            foreach (DataGridViewColumn column in dgvTasks.Columns)
            {
                if (column.Name != "TaskName" && column.Name != "Description" && column.Name != "Status" && column.Name != "Deadline")
                {
                    column.Visible = false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addTaskPage addTask = new addTaskPage(context);
            this.Hide();
            addTask.ShowDialog();
            this.Show();
            listTasks();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedCells.Count > 0)
            {
                editTaskPage editTask = new editTaskPage(context, getSelectedTask());
                this.Hide();
                editTask.ShowDialog();
                this.Show();
                listTasks();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaskCentralClassLibrary.Task selectedTask = getSelectedTask();
            if (selectedTask != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + selectedTask.TaskName + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.Tasks.Remove(selectedTask);
                        context.SaveChanges();
                        listTasks();
                    }
                    catch (Exception ex)
                    {
                        Log lg = Global.ExceptionHandler(ex, "TasksPage");
                        context.Add(lg);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedCells.Count > 0)
            {
                TaskCommentsPage commentsPage = new TaskCommentsPage(context, getSelectedTask());
                this.Hide();
                commentsPage.ShowDialog();
                this.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
