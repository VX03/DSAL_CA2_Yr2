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
            
            _root = _root.LoadFromFileBinary();
            if (_root != null)
            {
                foreach (var item in _root.List)
                {
                    ListViewItem lvi = new ListViewItem(item.ProjectId);
                    lvi.SubItems.Add(item.ProjectName);
                    lvi.SubItems.Add(item.Revenue.ToString());
                    lvi.SubItems.Add(item.ProjectLeader.EmployeeName);
                    lvi.Tag = item;
                    listviewProjectList.Items.Add(lvi);
                }
            }
            else
            {
                _root = new ProjectList();
            }
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
                if (employeeTreeNode.Employee.Project == null)
                {
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
                }
                else if (employeeTreeNode.Employee.Project != null)
                {
                    List<EmployeeTreeNode> employee3 = new List<EmployeeTreeNode>();
                    _employee.getEmployeeByName(employeeTreeNode.Employee.EmployeeName, ref employee3);
                    double r;
                    bool checking = false;
                    foreach (EmployeeTreeNode employeeTreeNode3 in employee3)
                    {
                        r = employeeTreeNode3.Employee.Salary;
                        //employeeTreeNode3.getAllSalary(ref r);
                        employeeTreeNode3.getTopAllSalary(ref r);
                        if (employeeTreeNode3.Employee.Role.ProjectLeader)
                        {
                            employeeTreeNode3.getAllSalary(ref r);
                        }
                        if(employeeTreeNode3.Employee.Project == null && r >= revenue)
                        {
                            checking = true;
                        }
                        if (
                            (employeeTreeNode3.Employee.Project != null && 
                            employeeTreeNode3.Employee.Project.ProjectId.Equals(projectId)
                            ) && 
                            r >= revenue)
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
                if (projectId == null)
                {
                    tbAddProjectName.Enabled = true;
                    tbAddProjectRevenue.Enabled = true;
                }
                else
                {
                    tbEditProjectName.Enabled = true;
                    tbEditRevenue.Enabled = true;
                }
            }
            else
            {
                if (projectId == null)
                {
                    tbAddProjectName.Enabled = false;
                    tbAddProjectRevenue.Enabled = false;
                }
                else
                {
                    tbEditProjectName.Enabled = false;
                    tbEditRevenue.Enabled = false;
                }
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
            if ((tbAddProjectName.Enabled && tbAddProjectRevenue.Enabled))
            {
                setBackColorToWhite();

                if (projectName == null || projectName.Equals(""))
                {
                    MessageBox.Show("Please input a name");
                    return;
                }
                try
                {
                    double revenue = Double.Parse(tbAddProjectRevenue.Text);
                    searchTeam(revenue, comboAddTeamLeader, null) ;

                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please input a valid revenue.");
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
                string projectId = tbEditProjectId.Text;
                string projectName = tbEditProjectName.Text;

                if (projectId == null || projectId.Equals(""))
                {
                    MessageBox.Show("Please select a project first");
                    return;
                }
                
                if (projectName == null || projectName.Equals(""))
                {
                    MessageBox.Show("Please input a name");
                    return;
                }
                
                double revenue = Double.Parse(tbEditRevenue.Text);
                tbConsole.Text = projectName + " has been selected to be edited";
                comboEditTeamLeader.Text = "";
                searchTeam(revenue, comboEditTeamLeader, _choosenProj.ProjectId) ;
                comboEditTeamLeader.Enabled = true;

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please input a valid revenue.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }// end of btnEditSearchTeams_Click
        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            try
            {
                setBackColorToWhite();
                string projectId = tbEditProjectId.Text;
                string projectName = tbEditProjectName.Text;
                double revenue = Double.Parse(tbEditRevenue.Text);

                string leader = comboEditTeamLeader.Text;

                if (leader == null || leader.Equals(""))
                {
                    MessageBox.Show("Please select a leader");
                    return;
                }

                if (!leader.Equals(_choosenProj.ProjectLeader.EmployeeName))
                {
                    List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
                    List<EmployeeTreeNode> employeeList2 = new List<EmployeeTreeNode>();
                    double r;
                    _employee.getEmployeeByProjectId(projectId, ref employeeList);

                    // setting project to null
                    foreach (EmployeeTreeNode employeeTreeNode in employeeList)
                    {
                        employeeTreeNode.Employee.Project = null;
                    }

                    _employee.getEmployeeByName(leader, ref employeeList2);
                    if (employeeList2.Count > 0)
                    {
                        int k = 0;

                        //checking
                        foreach (EmployeeTreeNode employeeTreeNode in employeeList2)
                        {
                            if (employeeTreeNode.Employee.Project == null && employeeTreeNode.Employee.Role.ProjectLeader)
                            {
                                k = 0;
                                break;
                            }
                            else if (!employeeTreeNode.Employee.Role.ProjectLeader && employeeTreeNode.Employee.Project == null)
                            {
                                k = 1;
                            }
                        }

                        // setting project
                        if (k == 0)
                        {
                            bool check = false;
                            foreach (EmployeeTreeNode employeeTreeNode in employeeList2)
                            {
                                r = employeeTreeNode.Employee.Salary;
                                employeeTreeNode.getTopAllSalary(ref r);
                                employeeTreeNode.getAllSalary(ref r);

                                if (employeeTreeNode.Employee.Project == null && employeeTreeNode.Employee.Role.ProjectLeader && r >= revenue)
                                {
                                    //updating project
                                    Project newProject = new Project(projectId, projectName, employeeTreeNode.Employee, revenue);

                                    employeeTreeNode.Employee.Project = newProject;

                                    foreach (EmployeeTreeNode employeeTreeNodeS in employeeTreeNode.SubordinateEmployee)
                                    {
                                        employeeTreeNodeS.Employee.Project = newProject;
                                    }
                                    _root.UpdateProject(newProject);

                                    _project.SubItems[0].Text = projectId;
                                    _project.SubItems[1].Text = projectName;
                                    _project.SubItems[2].Text = revenue.ToString();
                                    _project.SubItems[3].Text = employeeTreeNode.Employee.EmployeeName;
                                    
                                    check = true;
                                }
                            }
                            if (!check)
                            {
                                MessageBox.Show("Changed revenue exceeded the limit.");
                            }
                        }
                        else if (k == 1)
                        {
                            bool check = false;
                            foreach (EmployeeTreeNode employeeTreeNode in employeeList2)
                            {
                                r = employeeTreeNode.Employee.Salary;
                                employeeTreeNode.getTopAllSalary(ref r);
                                //employeeTreeNode.getAllSalary(ref r);
                                if (employeeTreeNode.Employee.Project == null && !employeeTreeNode.Employee.Role.ProjectLeader && r >= revenue)
                                {
                                    //updating project
                                    Project newProject = new Project(projectName, employeeTreeNode.Employee, revenue);

                                    List<EmployeeTreeNode> epmList = new List<EmployeeTreeNode>();

                                    _employee.getEmployeeByProjectId(_choosenProj.ProjectId, ref epmList);
                                    foreach (EmployeeTreeNode etn in epmList)
                                    {
                                        etn.Employee.Project = newProject;
                                    }


                                    employeeTreeNode.Employee.Project = newProject;

                                    _root.UpdateProject(newProject);

                                    _project.SubItems[0].Text = projectId;
                                    _project.SubItems[1].Text = projectName;
                                    _project.SubItems[2].Text = revenue.ToString();
                                    _project.SubItems[3].Text = employeeTreeNode.Employee.EmployeeName;
                                    
                                    check=true;
                                }
                            }
                            if (!check)
                            {
                                MessageBox.Show("Changed revenue exceeded the limit.");
                            }
                        }

                    }
                }
                else
                {
                    bool check = false;   
                    List<EmployeeTreeNode> ep = new List<EmployeeTreeNode>();
                    _employee.getEmployeeByName(_choosenProj.ProjectLeader.EmployeeName, ref ep);
                    foreach (EmployeeTreeNode employeeTreeNode in ep)
                    {
                        
                        if(
                            employeeTreeNode.Employee.EmployeeId.Equals(_choosenProj.ProjectLeader.EmployeeId) &&
                            employeeTreeNode.Employee.Role.RoleId.Equals(_choosenProj.ProjectLeader.Role.RoleId)
                            )
                        { 
                            double r = employeeTreeNode.Employee.Salary;
                            employeeTreeNode.getTopAllSalary(ref r);
                            employeeTreeNode.getAllSalary(ref r);

                            if(r >= revenue)
                            {


                                Project newProject = new Project(projectId, projectName, _choosenProj.ProjectLeader, revenue);

                                List<EmployeeTreeNode> epmList = new List<EmployeeTreeNode>();
                                _employee.getEmployeeByProjectId(_choosenProj.ProjectId, ref epmList);
                                foreach (EmployeeTreeNode etn in epmList)
                                {
                                    etn.Employee.Project = newProject;
                                }
                                _root.UpdateProject(newProject);

                                _project.SubItems[0].Text = projectId;
                                _project.SubItems[1].Text = projectName;
                                _project.SubItems[2].Text = revenue.ToString();
                                _project.SubItems[3].Text = _choosenProj.ProjectLeader.EmployeeName;
                                check = true;
                                break;
                            }

                        }// end of if
                    }// end of foreach
                    if (!check)
                    {
                        MessageBox.Show("Changed revenue exceeded the limit.");
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                tbEditProjectId.Clear();
                tbEditProjectName.Clear();
                tbEditRevenue.Clear();

                comboEditTeamLeader.Items.Clear();
                comboEditTeamLeader.Text = "";
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

        // End of ListViewProject ----------------------------------------------------------------------------------------------

        // Expand / Collapse treeview ------------------------------------------------------------------------------------------

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeViewEmployees.ExpandAll();
        }// end of btnExpandAll_Click

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewEmployees.CollapseAll();
        }// end of btnCollapseAll_Click

        // End of Expand / Collapse treeview------------------------------------------------------------------------------------

        //  Load / Save Data ---------------------------------------------------------------------------------------------------

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listviewProjectList.Items.Clear();
            treeViewEmployees.Nodes.Clear();

            _root = _root.LoadFromFileBinary();
            _employee = _employee.LoadFromFileBinary();
            _employee.RebuildTreeNodes();

            treeViewEmployees.Nodes.Add(_employee);
            treeViewEmployees.ExpandAll();

            if (_root != null)
            {
                foreach (var item in _root.List)
                {
                    ListViewItem lvi = new ListViewItem(item.ProjectId);
                    lvi.SubItems.Add(item.ProjectName);
                    lvi.SubItems.Add(item.Revenue.ToString());
                    lvi.SubItems.Add(item.ProjectLeader.EmployeeName);
                    lvi.Tag = item;
                    listviewProjectList.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("No Data to load from file");
                _root = new ProjectList();
            }
        }// end of btnLoad_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            setBackColorToWhite(); 
            _root.SaveToFileBinary();
            _employee.SaveToFileBinary();
        }// end of btnSave_Click
        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBoxMode.SelectedIndex = 0;

            tbAddProjectName.Clear();
            tbAddProjectRevenue.Clear();
            comboAddTeamLeader.Items.Clear();

            tbEditProjectId.Clear();
            tbEditProjectName.Clear();
            tbEditRevenue.Clear();
            comboEditTeamLeader.Items.Clear();

            setBackColorToWhite();

            listviewProjectList.Items.Clear();

            _root = _root.LoadFromFileBinary();
            if (_root != null)
            {
                foreach (var item in _root.List)
                {
                    ListViewItem lvi = new ListViewItem(item.ProjectId);
                    lvi.SubItems.Add(item.ProjectName);
                    lvi.SubItems.Add(item.Revenue.ToString());
                    lvi.SubItems.Add(item.ProjectLeader.EmployeeName);
                    lvi.Tag = item;
                    listviewProjectList.Items.Add(lvi);
                }
            }
            else
            {
                _root = new ProjectList();
            }
        }// end of btnReset_Click

        // End of Load / Save Data ---------------------------------------------------------------------------------------------
    }
}
