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
    public partial class editCommentsPage : Form
    {
        TaskCentralDBContext context;
        Comment selectedComment;
        public editCommentsPage(TaskCentralDBContext context, Comment selectedComment)
        {
            InitializeComponent();
            this.context = context;
            this.selectedComment = selectedComment;

            inputComment.Text = selectedComment.Text;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(inputComment.Text))
                {
                    MessageBox.Show("Cannot add an empty comment");
                    return;
                }
                selectedComment.Text = inputComment.Text;
                context.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                Log lg = Global.ExceptionHandler(ex, "editCommentsPage");
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
