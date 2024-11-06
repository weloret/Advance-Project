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
    public partial class createProjectPage : Form
    {
        TaskCentralDBContext context;
        public createProjectPage(TaskCentralDBContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Project newProject = new Project();
                if (string.IsNullOrEmpty(inputProjectName.Text))
                {
                    MessageBox.Show("Please Insert a Project Name");
                    return;
                }
                if (string.IsNullOrEmpty(inputDescription.Text))
                {
                    MessageBox.Show("Please Insert a Description");
                    return;
                }
                newProject.ProjectName = inputProjectName.Text;
                newProject.Description = inputDescription.Text;
                newProject.ManagerId = Global.loggedUser.UserId;

                context.Projects.Add(newProject);
                context.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                Log lg = Global.ExceptionHandler(ex, "createProjectPage");
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
