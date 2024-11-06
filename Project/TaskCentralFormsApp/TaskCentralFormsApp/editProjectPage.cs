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
    public partial class editProjectPage : Form
    {
        public editProjectPage()
        {
            InitializeComponent();
            inputProjectName.Text = Global.selectedProject.ProjectName;
            inputDescription.Text = Global.selectedProject.Description;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
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
            Global.selectedProject.ProjectName = inputProjectName.Text;
            Global.selectedProject.Description = inputDescription.Text;

            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
