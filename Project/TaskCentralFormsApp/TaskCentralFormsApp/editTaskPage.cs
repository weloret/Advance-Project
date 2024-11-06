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
    public partial class editTaskPage : Form
    {
        TaskCentralDBContext context;
        TaskCentralClassLibrary.Task selectedTask;
        public editTaskPage(TaskCentralDBContext context, TaskCentralClassLibrary.Task selectedTask)
        {
            InitializeComponent();
            this.context = context;
            this.selectedTask = selectedTask;

            comboMember.DataSource = context.Users.Where(u => Global.selectedProject.ProjectMembers.Select(pm => pm.UserId).Contains(u.UserId)).ToList();
            comboMember.DisplayMember = "UserName";
            comboMember.ValueMember = "UserId";

            comboStatus.Items.Add("Pending");
            comboStatus.Items.Add("Completed");


            inputTaskName.Text = selectedTask.TaskName;
            inputDescription.Text = selectedTask.Description;
            comboStatus.SelectedIndex = selectedTask.Status == "Pending" ? 0 : 1;
            inputDeadline.Value = selectedTask.Deadline;
            comboMember.SelectedValue = selectedTask.UserId;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputTaskName.Text))
            {
                MessageBox.Show("Task name is required");
                return;
            }
            if (string.IsNullOrEmpty(inputDescription.Text))
            {
                MessageBox.Show("Task description is required");
                return;
            }
            if (comboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is required");
                return;
            }
            if (!inputDeadline.Checked)
            {
                MessageBox.Show("Deadline is required");
                return;
            }

            if (comboMember.SelectedIndex == -1)
            {
                MessageBox.Show("Member is required");
                return;
            }
            try
            {
                selectedTask.TaskName = inputTaskName.Text;
                selectedTask.Description = inputDescription.Text;
                selectedTask.Status = comboStatus.SelectedItem.ToString();
                selectedTask.Deadline = inputDeadline.Value;
                selectedTask.UserId = (int)comboMember.SelectedValue;
                selectedTask.ProjectId = Global.selectedProject.ProjectId;

                context.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                Log lg = Global.ExceptionHandler(ex, "editTaskPage");
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
