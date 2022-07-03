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
    public partial class AddNewEmployee : Form
    {
        public delegate void AddEmployeeDelegate(string employeeName, double salary, bool dummy, bool accountable,Role roleId);
        public AddEmployeeDelegate AddEmployeeCallbackFn;
        private General general = new General();
        private List<RoleTreeNode> subordinateRoles;
        public AddNewEmployee(string reportingOfficer,List<RoleTreeNode> _subordinateRoles)
        {
            InitializeComponent();

            tbReportingOfficer.Text = reportingOfficer;
            foreach(RoleTreeNode role in _subordinateRoles)
            {
                comboRole.Items.Add(role.Role.RoleName);
            }
            comboRole.SelectedIndex = 0;
            subordinateRoles = _subordinateRoles;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                bool checkname = general.checkAlphabetAndSpace(name);
                bool dummy = cbDummyData.Checked;
                bool accountable = cbSalaryAccountable.Checked;
                double salary = Double.Parse(tbSalary.Text);
                Role role = null;

                foreach (RoleTreeNode roleTreeNode in subordinateRoles)
                {
                    if (roleTreeNode.Role.RoleName.Equals(comboRole.Text))
                    {
                        role = roleTreeNode.Role;
                    }
                }

                if (checkname && role != null && salary > 0)
                {
                    AddEmployeeCallbackFn(name.Trim(), salary, dummy, accountable, role);
                    this.DialogResult = DialogResult.OK;
                }
                // errors
                else if (salary <= 0) //salary
                {
                    MessageBox.Show("Unable to put a salary lesser or equal to 0");
                }
                else if(!checkname) //name
                {
                    if (name.Trim().Length > 0)
                        MessageBox.Show("Name contains special character(s) or number(s)");
                    else
                        MessageBox.Show("Please input the employee name");
                }
                else //selected value
                {
                    MessageBox.Show("Please select a value from the list");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please input a valid salary!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }// End of btnAdd_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }//end of btnCancel_Click

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
