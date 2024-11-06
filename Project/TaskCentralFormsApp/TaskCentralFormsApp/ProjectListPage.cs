using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ProjectListPage : Form
    {
        TaskCentralDBContext context = new TaskCentralDBContext(Global.loggedUser);
        public ProjectListPage()
        {
            InitializeComponent();
            listProjects();

        }
        public Project getSelectedProject()
        {
            return (Project)dgvProjects.SelectedCells[0].OwningRow.DataBoundItem;
        }
        public void listProjects(string? searchTerm = null)
        {
            try
            {
                var allProjects = context.Projects.Include(p => p.Tasks).Include(p => p.ProjectMembers).AsQueryable();
                allProjects = allProjects.Where(p => p.ManagerId == Global.loggedUser.UserId || p.ProjectMembers.Any(member => member.UserId == Global.loggedUser.UserId));
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    allProjects = allProjects.Where(p => p.ProjectName.Contains(searchTerm));
                }
                dgvProjects.DataSource = allProjects.ToList();
                foreach (DataGridViewColumn column in dgvProjects.Columns)
                {
                    if (column.Name != "ProjectName")
                    {
                        column.Visible = false;
                    }
                }
            }catch(Exception ex){
                Log lg = Global.ExceptionHandler(ex, "ProjectListPage");
                context.Add(lg);
                context.SaveChanges();
            }
        }

        private void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedCells.Count > 0)
            {
                Global.selectedProject = getSelectedProject();
                if (Global.selectedProject.ManagerId == Global.loggedUser.UserId)
                {
                    panelManager.Visible = true;
                }
                else
                {
                    panelManager.Visible = false;
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listProjects(textBoxSearch.Text);
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            createProjectPage createPage = new createProjectPage(context);
            this.Hide();
            createPage.ShowDialog();
            this.Show();
            listProjects();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Global.selectedProject != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + Global.selectedProject.ProjectName + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.Projects.Remove(Global.selectedProject);
                        context.SaveChanges();
                        listProjects();
                    }
                    catch (Exception ex)
                    {
                        Log lg = Global.ExceptionHandler(ex, "ProjectListPage");
                        context.Add(lg);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Global.selectedProject != null)
            {
                editProjectPage editPage = new editProjectPage();
                this.Hide();
                editPage.ShowDialog();
                this.Show();
                context.SaveChanges();
                listProjects();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (Global.selectedProject != null)
            {
                ProjectDashboard dashboardPage = new ProjectDashboard(context);
                this.Hide();
                dashboardPage.ShowDialog();
                this.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
