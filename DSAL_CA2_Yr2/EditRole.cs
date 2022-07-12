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
    public partial class EditRole : Form
    {
        public delegate void EditRoleDelegate(string roleName, bool projectLeader);
        public EditRoleDelegate EditRoleCallbackFn;
        private General general = new General();
        private EmployeeTreeNode employeeTreeNode = new EmployeeTreeNode();
        private string roleId;
        private bool leader;
        private RoleTreeNode role = new RoleTreeNode();
        public EditRole(RoleTreeNode role, EmployeeTreeNode employee)
        {
            InitializeComponent();

            tbId.Text = role.Role.RoleId;
            roleId = role.Role.RoleId;
            tbParent.Text = role.TopRole.Role.RoleName;
            tbName.Text = role.Role.RoleName;
            cbLeader.Checked = role.Role.ProjectLeader;
            this.leader = role.Role.ProjectLeader;
            this.role = role;
            employeeTreeNode = employee;
            if(employeeTreeNode == null)
            {
                employeeTreeNode = new EmployeeTreeNode();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string name = tbName.Text;
            bool check = false;
            bool leafnode = true;

            employeeTreeNode.checkHaveEmployeeForRole(roleId, ref check);
            if (check)
            {
                if(this.leader != cbLeader.Checked)
                {
                    MessageBox.Show("There is employee under project leader role");
                    return;
                }
            }

            // do not allow change in project leader if there is role under
            if (cbLeader.Checked)
            {
                role.checkThereIsRoleUnderSubordinate(ref leafnode);
                if (!leafnode)
                {
                    MessageBox.Show("Unable to change to project leader as there is roles under your current role(s)");
                    return;
                }
            }
            bool checkName = general.checkAlphabetAndSpace(name);
            if (checkName)
            {
                bool checkedLeader = cbLeader.Checked;
                EditRoleCallbackFn(name, checkedLeader);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Name contains special character(s) or number(s)");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
