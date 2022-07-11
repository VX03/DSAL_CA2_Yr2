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
        public EditRole(string roleName,string parentName,string roleuuid,bool leader)
        {
            InitializeComponent();
            tbId.Text = roleuuid;
            roleId = roleuuid;
            tbParent.Text = parentName;
            tbName.Text = roleName;
            cbLeader.Checked = leader;
            this.leader = leader;
            employeeTreeNode = employeeTreeNode.LoadFromFileBinary();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string name = tbName.Text;
            bool check = false;
            employeeTreeNode.checkHaveEmployeeForRole(roleId, ref check);
            if (check)
            {
                if(this.leader != cbLeader.Checked)
                {
                    MessageBox.Show("There is employee under project leader role");
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
