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
    public partial class MembersPage : Form
    {
        TaskCentralDBContext context;

        public MembersPage(TaskCentralDBContext context)
        {
            InitializeComponent();

            if (Global.selectedProject.ManagerId == Global.loggedUser.UserId)
            {
                panelManager.Visible = true;
            }
            else
            {
                panelManager.Visible = false;
            }
            labelMembersOf.Text = "Members of " + Global.selectedProject.ProjectName;
            this.context = context;
            listMembers();
        }
        public ProjectMember? getSelectedMember()
        {
            if (dgvMembers.SelectedCells.Count > 0)
            {
                return (ProjectMember)dgvMembers.SelectedCells[0].OwningRow.Cells[0].Value;
            }
            return null;
        }
        public void listMembers()
        {
            dgvMembers.DataSource = context.ProjectMembers.Include(pm => pm.User).Where(pm => pm.ProjectId == Global.selectedProject.ProjectId && pm.UserId != Global.selectedProject.ManagerId).Select(pm => new
            {
                member = pm,
                username = pm.User.UserName

            }).ToList();

            foreach (DataGridViewColumn column in dgvMembers.Columns)
            {
                if (column.Name != "username")
                {
                    column.Visible = false;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProjectMember selectedMember = getSelectedMember();
            if (selectedMember != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove " + selectedMember.User.UserName + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.ProjectMembers.Remove(selectedMember);
                        context.SaveChanges();
                        listMembers();
                    }
                    catch (Exception ex)
                    {
                        Log lg = Global.ExceptionHandler(ex, "MemebersPage");
                        context.Add(lg);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addMemberForm addMember = new addMemberForm(context);
            this.Hide();
            addMember.ShowDialog();
            this.Show();
            listMembers();
            //context.SaveChanges();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
