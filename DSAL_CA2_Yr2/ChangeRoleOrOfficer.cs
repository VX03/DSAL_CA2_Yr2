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
        public delegate void ChangeRoleOrOfficerDelegate();
        public ChangeRoleOrOfficerDelegate ChangeCallbackFn;
        private General general = new General();
        RoleTreeNode role;
        EmployeeTreeNode root;
        List<string> topEmployee = new List<string>();
        public ChangeRoleOrOfficer(string id,string roleN,string name,double salary,string topemployeeRole,string topEmployeeName, EmployeeTreeNode _root)
        {
            InitializeComponent();
            role = general.AutomaticGenerateRole();

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

            topEmployee = root.getAllReportingOfficer(parentrole);
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
    }
}
