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
        Project _choosenProj = new Project();
        ListViewItem _project = new ListViewItem();
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

            // list view Project
            ColumnHeader id, name, revenue, leader;

            id = new ColumnHeader();
            name = new ColumnHeader();
            revenue = new ColumnHeader();
            leader = new ColumnHeader();

            id.Text = "UUID";
            id.TextAlign = HorizontalAlignment.Left;
            id.Width = 70;

            name.Text = "Project Name";
            name.TextAlign = HorizontalAlignment.Left;
            name.Width = 150;

            revenue.Text = "Revenue";
            revenue.TextAlign = HorizontalAlignment.Left;
            revenue.Width = 90;

            leader.Text = "Project Leader";
            leader.TextAlign = HorizontalAlignment.Left;
            leader.Width = 150;

            listviewProjectList.Columns.Add(id);
            listviewProjectList.Columns.Add(name);
            listviewProjectList.Columns.Add(revenue);
            listviewProjectList.Columns.Add(leader);

            listviewProjectList.View = View.Details;
            listviewProjectList.FullRowSelect = true;
            listviewProjectList.MultiSelect = false;

            listviewProjectList.Click += new EventHandler(listviewProjectList_Click);
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
            comboEditTeamLeader.Enabled = false;

            btnEditDelete.Enabled = enable;
            btnConfirmEdit.Enabled = enable;
            btnEditSearchTeams.Enabled = enable;
        }// end of editProjectControls
        public void searchTeam(double revenue, ComboBox combobox, string projectId)
        {
            combobox.Items.Clear();
            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();

            _employee.getEmployeeWithLeader(ref employeeList);
            
            List<EmployeeTreeNode> employeeList2 = new List<EmployeeTreeNode>(employeeList);

            // check if it is full team
            foreach (EmployeeTreeNode employeeTreeNode in employeeList)
            {
                List<RoleTreeNode> roleList = new List<RoleTreeNode>();
                _role.getSubordinateRoleById(employeeTreeNode.Employee.Role.RoleId, ref roleList);

                bool check;
                double allrevenue = employeeTreeNode.Employee.Salary;
                List<bool> checkList = new List<bool>();
                EmployeeTreeNode epn = employeeTreeNode;

                while(epn.TopEmployee.Employee.Salary > 0)
                {
                    epn = epn.TopEmployee;
                    allrevenue += epn.Employee.Salary;
                }
                
                // check if there is full team and total salary
                foreach (RoleTreeNode roleTreeNode in roleList)
                {
                    check = false;

                    for (int i = 0; i < employeeTreeNode.SubordinateEmployee.Count; i++)
                    {
                        if (employeeTreeNode.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleTreeNode.Role.RoleId))
                        {
                            allrevenue += employeeTreeNode.SubordinateEmployee[i].Employee.Salary;
                            check = true;
                        }
                    }
                    checkList.Add(check);

                }// foreach role node

                // remove item from list
                if (checkList.Contains(false) || allrevenue < revenue)
                {
                    employeeList2.Remove(employeeTreeNode);
                }

                if (employeeTreeNode.Employee.Project != null)
                {
                    List<EmployeeTreeNode> employee3 = new List<EmployeeTreeNode>();
                    _employee.getEmployeeByName(employeeTreeNode.Employee.EmployeeName, ref employee3);

                    bool checking = false;
                    foreach (EmployeeTreeNode employeeTreeNode3 in employee3)
                    {
                        if (employeeTreeNode3.Employee.Project == null ||( employeeTreeNode3.Employee.Project != null && employeeTreeNode3.Employee.Project.ProjectId.Equals(projectId)))
                        {
                            checking = true;
                        }
                    }

                    if (!checking)
                    {
                        employeeList2.Remove(employeeTreeNode);
                    }
                }
            }// foreach employee node
            if (employeeList2.Count == 0)
            {
                MessageBox.Show("There is no team that fits the criteria");
                tbAddProjectName.Enabled = true;
                tbAddProjectRevenue.Enabled = true;
            }
            else
            {
                foreach (EmployeeTreeNode employeeTreeNode in employeeList2)
                {
                    employeeTreeNode.BackColor = Color.Yellow;
                    combobox.Items.Add(employeeTreeNode.Employee.EmployeeName);
                }
            }
        
        }// end of searchTeam
        private void setBackColorToWhite()
        {
            List<EmployeeTreeNode> list = new List<EmployeeTreeNode>();
            _employee.getAllEmployee(ref list);

            foreach(EmployeeTreeNode obj in list)
            {
                obj.BackColor = Color.White;
            }
        }// end of setBackToWhite
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

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            setBackColorToWhite();
            tbAddProjectName.Clear();
            tbAddProjectRevenue.Clear();
            comboAddTeamLeader.Items.Clear();
            comboAddTeamLeader.Text = null;

            addProjectControls(true);
        }// end of btnAddCancel_Click
        private void btnAddSearchTeams_Click(object sender, EventArgs e)
        {   
            string projectName = tbAddProjectName.Text;
            if (projectName != ""|| projectName != null || (tbAddProjectName.Enabled && tbAddProjectRevenue.Enabled))
            {
                setBackColorToWhite();

                try
                {
                    double revenue = Double.Parse(tbAddProjectRevenue.Text);
                    searchTeam(revenue, comboAddTeamLeader, null) ;

                    tbAddProjectName.Enabled = false;
                    tbAddProjectRevenue.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Team has already been searched");
            }
        }// end of btnAddSearchTeams_Click
        private void btnAddConfirm_Click(object sender, EventArgs e)
        {
            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
            string projectName = tbAddProjectName.Text;
            string leader = comboAddTeamLeader.Text;
            try
            {
                double revenue = Double.Parse(tbAddProjectRevenue.Text);
                if (projectName != null || projectName != null)
                {
                    _employee.getEmployeeByName(leader, ref employeeList);
                    if (employeeList.Count > 0)
                    {   
                        int k = 0;
                        
                        //checking
                        foreach(EmployeeTreeNode employeeTreeNode in employeeList)
                        {
                            if (employeeTreeNode.Employee.Project == null && employeeTreeNode.Employee.Role.ProjectLeader)
                            {
                                k = 0;
                                break;
                            }
                            else if (!employeeTreeNode.Employee.Role.ProjectLeader && employeeTreeNode.Employee.Project == null) 
                            {
                                k = 1;
                                break;
                            }
                        }
                        
                        // setting project
                        if(k == 0)
                        {
                            foreach (EmployeeTreeNode employeeTreeNode in employeeList)
                            {
                                if (employeeTreeNode.Employee.Project == null && employeeTreeNode.Employee.Role.ProjectLeader)
                                {
                                    Project newProject = new Project(projectName, employeeTreeNode.Employee, revenue);
                                    
                                    employeeTreeNode.Employee.Project = newProject;

                                    foreach(EmployeeTreeNode employeeTreeNodeS in employeeTreeNode.SubordinateEmployee)
                                    {
                                        employeeTreeNodeS.Employee.Project = newProject;
                                    }
                                    _root.AddProject(newProject);

                                    ListViewItem lvi = new ListViewItem(newProject.ProjectId);
                                    lvi.SubItems.Add(newProject.ProjectName);
                                    lvi.SubItems.Add(newProject.Revenue.ToString());
                                    lvi.SubItems.Add(newProject.ProjectLeader.EmployeeName);
                                    lvi.Tag = newProject;

                                    listviewProjectList.Items.Add(lvi);
                                }
                            }
                        }
                        else if(k == 1)
                        {
                            foreach (EmployeeTreeNode employeeTreeNode in employeeList)
                            {
                                if (employeeTreeNode.Employee.Project == null && !employeeTreeNode.Employee.Role.ProjectLeader)
                                {
                                    Project newProject = new Project(projectName, employeeTreeNode.Employee, revenue);
                                    employeeTreeNode.Employee.Project = newProject;
                                    _root.AddProject(newProject);

                                    ListViewItem lvi = new ListViewItem(newProject.ProjectId);
                                    lvi.SubItems.Add(newProject.ProjectName);
                                    lvi.SubItems.Add(newProject.Revenue.ToString());
                                    lvi.SubItems.Add(newProject.ProjectLeader.EmployeeName);
                                    lvi.Tag = newProject;

                                    listviewProjectList.Items.Add(lvi);
                                }
                            }
                        }


                        setBackColorToWhite();
                        tbAddProjectName.Clear();
                        tbAddProjectRevenue.Clear();
                        comboAddTeamLeader.Items.Clear();
                        comboAddTeamLeader.Text = null;
                        addProjectControls(true);

                        tbConsole.Text = "Project added:\r\nName: " + projectName + "\r\nRevenue: " + revenue + "\r\nTeam Leader: " + leader;
                    }
                    else
                    {
                        MessageBox.Show("No team has been selected");
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end of btnAddConfirm_Click

        // End of Adding Project------------------------------------------------------------------------------------------------

        // Edit Project---------------------------------------------------------------------------------------------------------
        private void btnEditSearchTeams_Click(object sender, EventArgs e)
        {
            setBackColorToWhite();

            try
            {
                double revenue = Double.Parse(tbEditRevenue.Text);
                string projectName = tbEditProjectName.Text;
                tbConsole.Text = projectName + " has been selected to be edited";

                searchTeam(revenue, comboEditTeamLeader, _choosenProj.ProjectId) ;
                comboEditTeamLeader.Enabled = true;

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }// end of btnEditSearchTeams_Click
        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {

        }// end of btnConfirmEdit_Click
        private void btnEditDelete_Click(object sender, EventArgs e)
        {
            try
            {                
                List<EmployeeTreeNode> employees = new List<EmployeeTreeNode>();
                _employee.getEmployeeByProjectId(_choosenProj.ProjectId, ref employees);

                foreach(EmployeeTreeNode employee in employees)
                {
                    employee.Employee.Project = null;
                }
                _root.deleteProject(_choosenProj.ProjectId);
                listviewProjectList.Items.RemoveAt(_project.Index);


            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end of btnEditDelete_Click

        // End of Edit Project--------------------------------------------------------------------------------------------------

        // ListViewProject------------------------------------------------------------------------------------------------------

        private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
        {
            // Translate the mouse position from screen coordinates to 
            // client coordinates within the given ListView
            Point localPoint = listView.PointToClient(mousePosition);
            return listView.GetItemAt(localPoint.X, localPoint.Y);
        }//End of GetItemFromPoint
        private void listviewProjectList_Click(object sender, EventArgs e)
        {
            _project = GetItemFromPoint(this.listviewProjectList, Cursor.Position);

            if (_project == null)
            {
                return;
            }
            _choosenProj = (Project)_project.Tag;

            tbEditProjectId.Text = _choosenProj.ProjectId;
            tbEditProjectName.Text = _choosenProj.ProjectName;
            tbEditRevenue.Text = _choosenProj.Revenue.ToString();

            comboEditTeamLeader.Text = _choosenProj.ProjectLeader.EmployeeName;
            comboEditTeamLeader.Items.Clear();
        }// end of listviewProjectList_Click

        // End of ListViewProject-----------------------------------------------------------------------------------------------
    }
}
