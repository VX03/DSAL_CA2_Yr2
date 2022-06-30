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
    public partial class EditEmployeeDetails : Form
    {
        public delegate void EditEmployeeDelegate(string employeeName, double salary, bool dummy, bool sa);
        public EditEmployeeDelegate EditEmployeeCallbackFn;
        private General general = new General();
        public EditEmployeeDetails(EmployeeTreeNode employee)
        {
            InitializeComponent();
            tbId.Text = employee.Employee.EmployeeId;
            tbName.Text = employee.Employee.EmployeeName;
            tbReportingOfficer.Text = employee.TopEmployee.Employee.EmployeeName;
            tbSalary.Text = String.Format("{0:0.00}", employee.Employee.Salary);
            comboRole.Items.Add(employee.Employee.Role.RoleName);
            comboRole.SelectedIndex = 0;
            cbDummyData.Checked = employee.Employee.DummyData;
            
            cbSalaryAccountable.Checked = employee.Employee.SalaryAccountable;
            if (cbDummyData.Checked) 
            { 
                cbSalaryAccountable.Enabled = true;
            }
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


                if (checkname && salary > 0)
                {
                    EditEmployeeCallbackFn(name, salary, dummy, accountable);
                    this.DialogResult = DialogResult.OK;
                }
                // errors
                else if (salary > 0) //salary
                {
                    MessageBox.Show("Unable to put a salary lesser or equal to 0");
                }
                else if (!checkname) //name
                {
                    MessageBox.Show("Name contains special character(s) or number(s)");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please input a valid salary!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }// end of btnAdd_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }// end of btnCancel_Click

        private void cbDummyData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDummyData.Checked)
            {
                cbSalaryAccountable.Enabled = true;
            }
            else
            {
                cbSalaryAccountable.Checked = true;
                cbSalaryAccountable.Enabled = false;
            }
        }// end of cbDummyData_CheckedChanged
    }
}
