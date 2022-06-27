using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2
{
    public partial class EditRole : Form
    {
        public delegate void EditRoleDelegate(string roleName, bool projectLeader);
        public EditRoleDelegate EditRoleCallbackFn;
        public EditRole(string roleName,string parentName,string roleuuid,bool leader)
        {
            InitializeComponent();
            tbId.Text = roleuuid;
            tbParent.Text = parentName;
            tbName.Text = roleName;
            cbLeader.Checked = leader;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            bool checkedLeader = cbLeader.Checked;
            EditRoleCallbackFn(name, checkedLeader);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
