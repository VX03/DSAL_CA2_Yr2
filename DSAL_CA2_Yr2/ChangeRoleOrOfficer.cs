using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSAL_CA2_Yr2.Classes;


namespace DSAL_CA2_Yr2
{
    public partial class ChangeRoleOrOfficer : Form
    {
        private General general = new General();
        RoleTreeNode role;
        public ChangeRoleOrOfficer(/*EmployeeTreeNode _root, Employee employee, string topEmployee, string roleName*/)
        {
            InitializeComponent();
            role = general.AutomaticGenerateRole();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }// end of btnAdd_Click
    }
}
