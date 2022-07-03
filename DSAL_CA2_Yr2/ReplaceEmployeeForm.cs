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
    public partial class ReplaceEmployeeForm : Form
    {
        public delegate void ReplaceEmployeeDelegate(Employee _selectedEmployee);
        public ReplaceEmployeeDelegate SwapEmployeeCallbackFn;
        EmployeeTreeNode _root;
        EmployeeTreeNode _selectedEmployee;
        public ReplaceEmployeeForm(EmployeeTreeNode root, string employee)
        {
            InitializeComponent();
            
            _root = root;
            treeViewEmployee.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewEmployee_NodeMouseClick);
            treeViewEmployee.Nodes.Add(_root);

            treeViewEmployee.ExpandAll();

            tbEmployee.Text = employee;
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                SwapEmployeeCallbackFn(_selectedEmployee.Employee);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No employee is selected to swap with");
        }// end of btnSwap_Click
        private void treeViewEmployee_NodeMouseClick(object sender, EventArgs e)
        {
            _selectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if (_selectedEmployee != null)
            {
                tbId.Text = _selectedEmployee.Employee.EmployeeId;
                tbName.Text = _selectedEmployee.Employee.EmployeeName;
                tbSalary.Text = _selectedEmployee.Employee.Salary.ToString();
                tbRole.Text = _selectedEmployee.Employee.Role.RoleName;

                if (_selectedEmployee.Employee.Project == null)
                {
                    tbProject.Text = "N.A.";
                }
                else
                {
                    tbProject.Text = _selectedEmployee.Employee.Project;
                }

                if (_selectedEmployee.TopEmployee == null)
                {
                    tbReportingOfficer.Text = "N.A";
                }
                else
                {
                    tbReportingOfficer.Text = _selectedEmployee.TopEmployee.Employee.EmployeeName;
                }
            }
        }// end of treeViewEmployee_NodeMouseClick
    }
}
