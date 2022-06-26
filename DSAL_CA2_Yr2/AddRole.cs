using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2
{
    public partial class AddRole : Form
    {
        public delegate void AddRoleDelegate(string roleName, bool projectLeader);
        public AddRoleDelegate AddRoleCallbackFn;
        public AddRole(string roleParent)
        {
            InitializeComponent();
            tbParentRole.Text = roleParent;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbAddRole.Text;
            bool checkedLeader = cbLeader.Checked;
            AddRoleCallbackFn(name, checkedLeader);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
