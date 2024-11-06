using Microsoft.EntityFrameworkCore;
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
    public partial class ProjectDashboard : Form
    {
        TaskCentralDBContext context;
        public ProjectDashboard(TaskCentralDBContext context)
        {
            InitializeComponent();
            this.context = context;
            labelDashboard.Text = "Dashboard For " + Global.selectedProject.ProjectName;
            labelOverDue.Text = "Overdue tasks: " + Global.selectedProject.Tasks.Count(t => t.Deadline < DateTime.Now).ToString();
            labelPending.Text = "Pending tasks: " + Global.selectedProject.Tasks.Count(t => t.Status == "Pending").ToString();
            labelCompleted.Text = "Completed tasks: " + Global.selectedProject.Tasks.Count(t => t.Status == "Completed").ToString();
            labelTotal.Text = "Total tasks: " + Global.selectedProject.Tasks.Count().ToString();

            Dictionary<int, int> tasksPerMember = new Dictionary<int, int>();

            foreach (var task in Global.selectedProject.Tasks)
            {
                if (tasksPerMember.TryGetValue(task.UserId, out int count))
                {
                    tasksPerMember[task.UserId] = count + 1;
                }
                else
                {
                    tasksPerMember[task.UserId] = 1;
                }
            }


            foreach (var taskMember in tasksPerMember)
            {

                listTasksMember.Items.Add("Member ID: " + taskMember.Key + ", Task Count: " + taskMember.Value);
            }


        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            TasksPage taskPage = new TasksPage(context);
            this.Hide();
            taskPage.ShowDialog();
            this.Show();
        }

        private void buttonMembers_Click(object sender, EventArgs e)
        {
            MembersPage memberPage = new MembersPage(context);
            this.Hide();
            memberPage.ShowDialog();
            this.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
