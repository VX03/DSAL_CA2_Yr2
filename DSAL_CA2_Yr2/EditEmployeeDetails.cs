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
        public delegate void EditEmployeeDelegate(string employeeName, double salary, bool dummy, bool sa, Project p);
        public EditEmployeeDelegate EditEmployeeCallbackFn;
        private General general = new General();
        private Project project;
        ProjectList projectList = new ProjectList();
        private EmployeeTreeNode employee = new EmployeeTreeNode();
        private bool topEmployee = false;
        public EditEmployeeDetails(EmployeeTreeNode employee)
        {
            InitializeComponent();
            
            
            this.employee = employee;

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
            
            if(employee.TopEmployee.TopEmployee == null)
            {
                topEmployee = true;
            }

            projectList = projectList.LoadFromFileBinary();
            if (projectList != null)
            {
                foreach (Project p in projectList.List)
                {
                    if (
                        p.ProjectLeader.EmployeeId.Equals(employee.Employee.EmployeeId) &&
                        p.ProjectLeader.Role.RoleId.Equals(employee.Employee.Role.RoleId)
                        )
                    {
                        project = p;
                        break;
                    }
                }// end of foreach
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                double allrevenue;
                string name = tbName.Text;
                bool checkname = general.checkAlphabetAndSpace(name);
                bool dummy = cbDummyData.Checked;
                bool accountable = cbSalaryAccountable.Checked;
                double salary = Double.Parse(String.Format("{0:0.00}", tbSalary.Text));

                bool isHigher = true;
                employee.checkSalarywithSubordinate(ref isHigher, salary);

                if(project != null)
                {
                    allrevenue = salary;
                    if (employee.Employee.Role.ProjectLeader)
                    {
                        employee.getTopAllSalary(ref allrevenue);
                        employee.getAllSalary(ref allrevenue);
                    }
                    else if (employee.TopEmployee.Employee.Role.ProjectLeader)
                    {
                        employee.TopEmployee.getTopAllSalary(ref allrevenue);
                        
                        employee.TopEmployee.getAllSalary(ref allrevenue);
                        allrevenue -= employee.Employee.Salary;
                        allrevenue += employee.TopEmployee.Employee.Salary;
                    }
                    else
                    {
                        employee.getTopAllSalary(ref allrevenue);
                    }
                    if(allrevenue < project.Revenue) 
                    {
                        MessageBox.Show("The salary of the project");
                        return;
                    }
                }

                if (checkname && salary > 0 && (topEmployee || salary <= employee.TopEmployee.Employee.Salary) && isHigher)
                {
                    EditEmployeeCallbackFn(name, salary, dummy, accountable, project);
                    this.DialogResult = DialogResult.OK;
                }
                // errors
                else if (!isHigher)
                {
                    MessageBox.Show("Unable to put a salary smaller than subordinate's");
                }
                else if(salary > employee.TopEmployee.Employee.Salary && !topEmployee)
                {
                    MessageBox.Show("Unable to put a salary bigger than reporting officer's");
                }
                else if (salary <= 0) //salary
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
