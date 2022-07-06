using DSAL_CA2_Yr2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2
{
    public partial class ManageProjects : Form
    {
        EmployeeTreeNode _employee = new EmployeeTreeNode();
        ProjectList _root = new ProjectList();
        RoleTreeNode _role = new RoleTreeNode();
        private General general = new General();

        public ManageProjects()
        {
            InitializeComponent();
        }
        private void ManageProjects_Load(object sender, EventArgs e)
        {
            // Retrieve role if there is no employee
            
            _role = _role.LoadFromFileBinary();
            if (_role == null)
            {
                _role = new RoleTreeNode(new Role("Root", false));
            }//Automatically Create roles

            _employee = _employee.LoadFromFileBinary();

            if( _employee != null )
                _employee.RebuildTreeNodes();
            else
            {
                MessageBox.Show("There is no employee under root");
                EmployeeTreeNode employee = new EmployeeTreeNode(new Employee("root", 0, _role.Role, false, false));
                _employee = employee;
            }

            treeViewEmployees.Nodes.Add(_employee);
            treeViewEmployees.ExpandAll();

        }// end of ManageProjects_Load

        // Controls-------------------------------------------------------------------------------------------------------------

        private void addProjectControls(bool enable)
        {
            tbAddProjectName.Enabled = enable;
            tbAddProjectRevenue.Enabled = enable;
            comboAddTeamLeader.Enabled = enable;

            btnAddCancel.Enabled = enable;
            btnAddConfirm.Enabled = enable;
            btnAddSearchTeams.Enabled = enable;
        }// end of addProjectControls
        private void editProjectControls(bool enable)
        {
            tbEditProjectName.Enabled = enable;
            tbEditRevenue.Enabled = enable;
            comboEditTeamLeader.Enabled = enable;

            btnEditDelete.Enabled = enable;
            btnConfirmEdit.Enabled = enable;
            btnEditSearchTeams.Enabled = enable;
        }// end of editProjectControls
        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxMode.Text == "View")
            {
                addProjectControls(false);
                editProjectControls(false);
            }
            else if (comboBoxMode.Text == "Add")
            {
                addProjectControls(true);
                editProjectControls(false);
            }
            else if (comboBoxMode.Text == "Edit")
            {
                addProjectControls(false);
                editProjectControls(true);
            }
        }// end of comboBoxMode_SelectedIndexChanged

        // End of Controls------------------------------------------------------------------------------------------------------

        // Adding Project-------------------------------------------------------------------------------------------------------

        private void setBackColorToWhite()
        {
            List<EmployeeTreeNode> list = new List<EmployeeTreeNode>();
            _employee.getAllEmployee(ref list);

            foreach(EmployeeTreeNode obj in list)
            {
                obj.BackColor = Color.White;
            }
        }// end of setBackToWhilte
        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            setBackColorToWhite();
            tbAddProjectName.Clear();
            tbAddProjectRevenue.Clear();
        }// end of btnAddCancel_Click

        private void btnAddSearchTeams_Click(object sender, EventArgs e)
        {
            setBackColorToWhite();
            try {
                string projectName = tbAddProjectName.Text;
                double revenue = Double.Parse(tbAddProjectRevenue.Text);
                List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();

                _employee.getEmployeeWithLeader(ref employeeList);

                List<EmployeeTreeNode> employeeList2 = new List<EmployeeTreeNode>(employeeList);

                // check if it is full team
                foreach(EmployeeTreeNode employeeTreeNode in employeeList)
                {
                    List<RoleTreeNode> roleList = new List<RoleTreeNode>();
                    _role.getSubordinateRoleById(employeeTreeNode.Employee.Role.RoleId, ref roleList);

                    bool check;
                    double allrevenue = employeeTreeNode.Employee.Salary;
                    List<bool> checkList = new List<bool>();
                    foreach(RoleTreeNode roleTreeNode in roleList)
                    {
                        check = false;

                        for(int i = 0; i< employeeTreeNode.SubordinateEmployee.Count; i++)
                        {
                            if (employeeTreeNode.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleTreeNode.Role.RoleId))
                            {
                                allrevenue += employeeTreeNode.SubordinateEmployee[i].Employee.Salary;
                                check = true;
                            }
                        }
                        checkList.Add(check);

                    }// foreach
                    if (checkList.Contains(false) || allrevenue < revenue)
                    {
                        employeeList2.Remove(employeeTreeNode);
                    }
                }

                foreach(EmployeeTreeNode employeeTreeNode in employeeList2)
                {
                    employeeTreeNode.BackColor = Color.Yellow;
                    comboAddTeamLeader.Items.Add(employeeTreeNode.Employee.EmployeeName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end of btnAddSearchTeams_Click
        private void btnAddConfirm_Click(object sender, EventArgs e)
        {

        }// end of btnAddConfirm_Click

        // End of Adding Project------------------------------------------------------------------------------------------------

    }
}
