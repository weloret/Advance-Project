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
    public partial class addMemberForm : Form
    {
        TaskCentralDBContext context;

        public addMemberForm(TaskCentralDBContext context)
        {
            InitializeComponent();
            this.context = context;
            comboUser.DataSource = context.Users.Where(u => !(Global.selectedProject.ProjectMembers.Select(pm => pm.UserId).Contains(u.UserId))).ToList();
            comboUser.DisplayMember = "UserName";
            comboUser.ValueMember = "UserId";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectMember newMember = new ProjectMember();
                newMember.ProjectId = Global.selectedProject.ProjectId;
                newMember.UserId = (int)comboUser.SelectedValue;

                context.ProjectMembers.Add(newMember);
                context.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                Log lg = Global.ExceptionHandler(ex, "addMemberForm");
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
