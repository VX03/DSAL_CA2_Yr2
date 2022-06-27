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
    public partial class AddRole : Form
    {
        public delegate void AddRoleDelegate(string roleName, bool projectLeader);
        public AddRoleDelegate AddRoleCallbackFn;
        private General general = new General();
        public AddRole(string roleParent)
        {
            InitializeComponent();
            tbParentRole.Text = roleParent;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbAddRole.Text;
            bool checkName = general.checkAlphabetAndSpace(name);
            if (checkName)
            {
                bool checkedLeader = cbLeader.Checked;
                AddRoleCallbackFn(name, checkedLeader);
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
