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
        public delegate void ChangeRoleOrOfficerDelegate(string id, string name, string salary,string role, string reportingOfficer, bool dummy, bool sa);
        public ChangeRoleOrOfficerDelegate ChangeCallbackFn;
        private General general = new General();
        RoleTreeNode role;
        EmployeeTreeNode root;
        List<string> topEmployee = new List<string>();
        public ChangeRoleOrOfficer(string id,string roleN,string name,double salary,string topemployeeRole,string topEmployeeName, EmployeeTreeNode _root, RoleTreeNode _role)
        {
            InitializeComponent();
            if (_role == null)
                role = general.AutomaticGenerateRole();
            else
                role = _role;

            List<string> allRoles = new List<string>();
 
            int i = 0, e=0;
            root = _root;
            role.getAllRoles(ref allRoles);
            

            foreach (string roleName in allRoles)
            {
                comboRole.Items.Add(roleName);
                if (roleName.Equals(roleN))
                {
                    comboRole.SelectedIndex = i;
                }
                else
                    i++;
            }// end of setting comboRole

            foreach (string employeeName in topEmployee)
            {
                if (employeeName.Equals(topEmployeeName))
                {
                    comboReportingOfficer.SelectedIndex = e;
                }
                else
                    e++;
            }// end of reporting officer

            tbId.Text = id;
            tbName.Text = name;
            tbSalary.Text = salary.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = tbId.Text;
            string name = tbName.Text;
            string salary = tbSalary.Text;
            string reportingOfficer = comboReportingOfficer.Text;
            string role = comboRole.Text;
            bool dummy = cbDummyData.Checked;
            bool sa = cbSalaryAccountable.Checked;

            if(reportingOfficer != null && role != null && !role.Equals("No employee to be selected"))
            {
                ChangeCallbackFn(id, name, salary, role, reportingOfficer, dummy, sa);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (role.Equals("No employee to be selected"))
                    MessageBox.Show("Do not select a role that have no employee");
                else
                    MessageBox.Show("Select value from reporting officer / role list");
            }
        }// end of btnAdd_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }// end of btnCancel_Click

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboReportingOfficer.Items.Clear();
            comboReportingOfficer.Text = "";

            string parentrole = null;
            role.getParentRoleByName(comboRole.Text, ref parentrole);

            topEmployee = root.getAllEmployeeByRole(parentrole);
            if (topEmployee.Count != 0)
            {
                foreach (string employeeName in topEmployee)
                {
                    comboReportingOfficer.Items.Add(employeeName);
                }
            }
            else
                comboReportingOfficer.Items.Add("No employee to be selected");
        }// end of comboRole_SelectedIndexChanged

        private void cbDummyData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDummyData.Checked)
            {
                cbSalaryAccountable.Enabled = true;
                tbName.Text = "Dummy";
            }
            else
            {
                cbSalaryAccountable.Checked = true;
                cbSalaryAccountable.Enabled = false;
            }
        }// end of cbDummyData_CheckedChanged
    }
}
