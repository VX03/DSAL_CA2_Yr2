using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2
{

    public partial class parentForm : Form
    {
        public ManageRoles Role;
        public ManageEmployee Employee;
        public ManageProjects Projects;
        public parentForm()
        {
            InitializeComponent();
            this.roleFormToolStripMenuItem.Click += new EventHandler(this.RoleFormToolStripMenuItem_Click);
            this.employeeFormToolStripMenuItem.Click += new EventHandler(this.EmployeeFormToolStripMenuItem_Click);
            this.projectFormToolStripMenuItem.Click += new EventHandler(this.ProjectFormToolStripMenuItem_Click);
        }

        private void parentForm_Load(object sender, EventArgs e)
        {

        }

        private void RoleFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Role != null)
            {
                Role.Show();
            }
            if (Role == null)
            {
                Role = new ManageRoles();
                Role.MdiParent = this;
                Role.Show();
            }
        }

        private void EmployeeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Employee != null)
            {
                Employee.Show();
            }
            if (Employee == null)
            {
                Employee = new ManageEmployee();
                Employee.MdiParent = this;
                Employee.Show();
            }
        }

        private void ProjectFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Projects != null)
            {
                Projects.Show();
            }
            if (Projects == null)
            {
                Projects = new ManageProjects();
                Projects.MdiParent = this;
                Projects.Show();
            }
        }


    }
}
