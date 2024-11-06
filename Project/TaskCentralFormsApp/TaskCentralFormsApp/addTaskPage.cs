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
    public partial class addTaskPage : Form
    {
        TaskCentralDBContext context;
        public addTaskPage(TaskCentralDBContext context)
        {
            InitializeComponent();
            this.context = context;

            comboMember.DataSource = context.Users.Where(u => Global.selectedProject.ProjectMembers.Select(pm => pm.UserId).Contains(u.UserId)).ToList();
            comboMember.DisplayMember = "UserName";
            comboMember.ValueMember = "UserId";

            comboStatus.Items.Add("Pending");
            comboStatus.Items.Add("Completed");
            comboStatus.SelectedIndex = 0;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TaskCentralClassLibrary.Task newTask = new TaskCentralClassLibrary.Task();

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
                newTask.TaskName = inputTaskName.Text;
                newTask.Description = inputDescription.Text;
                newTask.Status = comboStatus.SelectedItem.ToString();
                newTask.Deadline = inputDeadline.Value;
                newTask.UserId = (int)comboMember.SelectedValue;
                newTask.ProjectId = Global.selectedProject.ProjectId;

                context.Tasks.Add(newTask);
                context.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                Log lg = Global.ExceptionHandler(ex, "addTaskPage");
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
