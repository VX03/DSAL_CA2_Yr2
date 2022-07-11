using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DSAL_CA2_Yr2.Classes;

namespace DSAL_CA2_Yr2
{
    public partial class ManageEmployee : Form
    {
        private EmployeeTreeNode _root = new EmployeeTreeNode();
        private RoleTreeNode _role = new RoleTreeNode();
        private EmployeeTreeNode _currentSelectedEmployee;
        private General general = new General();
        ProjectList _projectList = new ProjectList();

        public ManageEmployee()
        {
            InitializeComponent();
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            treeViewEmployee.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewEmployee_NodeMouseClick);
            
            // [ Get data from role file ]
            _role = _role.LoadFromFileBinary();
            if (_role == null)
            {
                _role = general.AutomaticGenerateRole();
                MessageBox.Show("There is no role data in file. Role data is automatically created and saved to file");
                _role.SaveToFileBinary();

            }//Automatically Create roles
            
            // [ Get data from employee file ]
            _root = _root.LoadFromFileBinary();
            if (_root == null)
            {
                EmployeeTreeNode root = new EmployeeTreeNode(new Employee("root", 0, _role.Role, false, false));
                _root = root;
            }
            else
                _root.RebuildTreeNodes();
            
            treeViewEmployee.Nodes.Add(_root);
            treeViewEmployee.ExpandAll();

            _projectList = _projectList.LoadFromFileBinary();
        }// End of ManageEmployee_Load

        // Create Context Menu on Right Click ------------------------------------------------------------------------------------------------

        private void treeViewEmployee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;
            if (_currentSelectedEmployee != null)
            {
                string id = "", project = "", name = "", salary = "", role = "", officername = "";
                List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();

                id = _currentSelectedEmployee.Employee.EmployeeId;
                
                name = _currentSelectedEmployee.Employee.EmployeeName;
                salary = _currentSelectedEmployee.Employee.Salary.ToString();
                role = _currentSelectedEmployee.Employee.Role.RoleName;

                if (_currentSelectedEmployee.TopEmployee != null)
                {
                    if (_currentSelectedEmployee.Employee.Project != null)
                    {
                        project = _currentSelectedEmployee.Employee.Project.ProjectName;
                    }
                    else
                        project = "N.A.";
                    
                    officername = _currentSelectedEmployee.TopEmployee.Employee.EmployeeName;
                }
                else
                    officername = "N.A";
                
                _root.getEmployeeByName(name, ref employeeList);    
                if(employeeList.Count > 1)
                {
                    List<bool> check = new List<bool>();
                    foreach (EmployeeTreeNode employeeTreeNode in employeeList)
                    {
                        if(employeeTreeNode.Employee.Project != null)
                            check.Add(true);
                        else
                            check.Add(false);
                    }
                    if (check.Contains(false)) ;
                    else
                    {

                        if (!_currentSelectedEmployee.Employee.Role.ProjectLeader && _currentSelectedEmployee.Employee.Project != null)
                         {
                             string proj = "";
                             foreach(EmployeeTreeNode employee in employeeList)
                             {
                                if (proj.Equals(""))
                                    proj += employee.Employee.Project.ProjectName;
                                else
                                    proj += ", " + employee.Employee.Project.ProjectName;
                             }
                            project = proj;
                        }// end of foreach
                    }
                }// end of foreach

                tbId.Text = id;
                tbReportingOfficer.Text = officername;
                tbName.Text = name;
                tbSalary.Text = salary;
                tbProject.Text = project;
                tbRole.Text = role;
                cbDummyData.Checked = _currentSelectedEmployee.Employee.DummyData;
                cbSalaryAccountable.Checked = _currentSelectedEmployee.Employee.SalaryAccountable;
                tbConsole.Text = name + " has been selected";
                
                if (e.Button == MouseButtons.Right)
                {
                    createContextMenu(_currentSelectedEmployee);
                }

            }

        }//end of treeViewEmployee_NodeMouseClick
        private void createContextMenu(EmployeeTreeNode node)
        {
            ToolStripMenuItem menuItemAddEmployee, menuItemRemoveEmployee, menuItemEditEmployee, menuItemEditEmployeeDetails, menuItemchange, menuItemSwapEmployee;
            bool check = _role.checkHaveSubordinateRoleById(node.Employee.Role.RoleId);
            if (node != null && node.TopEmployee == null)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();

                //add menu items
                menuItemAddEmployee = new ToolStripMenuItem("Add Employee");
                menuItemSwapEmployee = new ToolStripMenuItem("Swap Employee");

                //add event handler
                menuItemAddEmployee.Click += new EventHandler(MenuItemAddEmployee_Click);
                menuItemSwapEmployee.Click += new EventHandler(MenuItemSwapEmployee_Click);

                //menu strip add item
                menuStrip.Items.Add(menuItemAddEmployee);
                menuStrip.Items.Add(menuItemSwapEmployee);

                this.ContextMenuStrip = menuStrip;
            }
            else if(node != null && !check)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();

                //add menu items
                menuItemEditEmployee = new ToolStripMenuItem("Edit Employee");
                menuItemEditEmployeeDetails = new ToolStripMenuItem("Edit Employee Details");
                menuItemchange = new ToolStripMenuItem("Change Role/Reporting Officer");
                menuItemEditEmployee.DropDownItems.Add(menuItemEditEmployeeDetails);
                menuItemEditEmployee.DropDownItems.Add(menuItemchange);

                menuItemRemoveEmployee = new ToolStripMenuItem("Remove Employee");
                menuItemSwapEmployee = new ToolStripMenuItem("Swap Employee");

                //add event handler
                menuItemEditEmployeeDetails.Click += new EventHandler(MenuItemEditEmployeeDetails_Click);
                menuItemchange.Click += new EventHandler(MenuItemChange_Click);
                menuItemRemoveEmployee.Click += new EventHandler(MenuItemRemoveEmployee_Click);
                menuItemSwapEmployee.Click += new EventHandler(MenuItemSwapEmployee_Click);

                //menu strip add item
                menuStrip.Items.Add(menuItemEditEmployee);
                menuStrip.Items.Add(menuItemRemoveEmployee);
                menuStrip.Items.Add(menuItemSwapEmployee);

                this.ContextMenuStrip = menuStrip;
            }
            else if (node != null)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                
                //add menu items
                menuItemAddEmployee = new ToolStripMenuItem("Add Employee");

                menuItemEditEmployee = new ToolStripMenuItem("Edit Employee");
                menuItemEditEmployeeDetails = new ToolStripMenuItem("Edit Employee Details");
                menuItemchange = new ToolStripMenuItem("Change Role/Reporting Officer");
                menuItemEditEmployee.DropDownItems.Add(menuItemEditEmployeeDetails);// Dropdown list
                menuItemEditEmployee.DropDownItems.Add(menuItemchange);// Dropdown list

                menuItemRemoveEmployee = new ToolStripMenuItem("Remove Employee");
                menuItemSwapEmployee = new ToolStripMenuItem("Swap Employee");

                //add event handler
                menuItemAddEmployee.Click += new EventHandler(MenuItemAddEmployee_Click);
                menuItemEditEmployeeDetails.Click += new EventHandler(MenuItemEditEmployeeDetails_Click);
                menuItemchange.Click += new EventHandler(MenuItemChange_Click);
                menuItemRemoveEmployee.Click += new EventHandler(MenuItemRemoveEmployee_Click);
                menuItemSwapEmployee.Click += new EventHandler(MenuItemSwapEmployee_Click);

                //menu strip add item
                menuStrip.Items.Add(menuItemAddEmployee);
                menuStrip.Items.Add(menuItemEditEmployee);
                menuStrip.Items.Add(menuItemRemoveEmployee);
                menuStrip.Items.Add(menuItemSwapEmployee);

                this.ContextMenuStrip = menuStrip;
            }
        }//end of createContextMenu

        // End of Create Context Menu on Right Click -----------------------------------------------------------------------------------------

        // Edit/update/remove/add Employee in Context Menu -----------------------------------------------------------------------------------

        // Add Employee [ DONE ]
        private void MenuItemAddEmployee_Click(object sender, EventArgs e)
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if (_currentSelectedEmployee == null)
            {
                tbConsole.Text = "You did not select any employee to add a subordinate.";
            }
            else
            {
                string employeeName = _currentSelectedEmployee.Employee.EmployeeName;
                tbConsole.Text = employeeName + " has been selected to add a new subordinate";

                List<RoleTreeNode> subordinateRoles = new List<RoleTreeNode>(); 
                _role.getSubordinateRoleById(_currentSelectedEmployee.Employee.Role.RoleId, ref subordinateRoles);
                
                AddNewEmployee addForm = new AddNewEmployee(employeeName, subordinateRoles);
                addForm.AddEmployeeCallbackFn = AddEmployeeCallbackFn;
                addForm.ShowDialog();
            }
        }//end of MenuItemAddRole_Click
        private void AddEmployeeCallbackFn(string employeeName, double salary, bool dummy, bool accountable, Role role)
        {
            tbConsole.Text = "Employee Added:\r\nName: "+employeeName+"\r\nPosition: "+role.RoleName+"\r\nSalary: "+salary+"\r\nDummy Data: "+dummy+"\r\nSalary Accountable: "+accountable;
            EmployeeTreeNode employee = new EmployeeTreeNode(new Employee(employeeName, salary, role, dummy, accountable));
            _currentSelectedEmployee.AddEmployeeSubordinate(employee);
            
            if (employee.TopEmployee.Employee.Role.ProjectLeader)
            {
                employee.Employee.Project = employee.TopEmployee.Employee.Project;
            }
            
            treeViewEmployee.SelectedNode.Expand();
        }// end of AddEmployeeCallbackFn

        // Edit Employee Details [ DONE ]
        private void MenuItemEditEmployeeDetails_Click(object sender, EventArgs e) 
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if (_currentSelectedEmployee == null)
            {
                tbConsole.Text = "You did not select any employee to edit.";
            }
            else
            {
                string employeeName = _currentSelectedEmployee.Employee.EmployeeName;
                tbConsole.Text = employeeName + " has been selected to be edited.";

                EditEmployeeDetails editForm = new EditEmployeeDetails(_currentSelectedEmployee);
                editForm.EditEmployeeCallbackFn = EditEmployeeCallbackFn;
                editForm.ShowDialog();
            }
        }//end of MenuItemEditEmployeeDetails_Click
        private void EditEmployeeCallbackFn(string employeeName, double salary, bool dummy, bool sa,Project p)
        {
            _currentSelectedEmployee.UpdateEmployee(employeeName, salary, dummy, sa);
            if (p != null)
            {
                Project newP = new Project(p.ProjectId, p.ProjectName, _currentSelectedEmployee.Employee, p.Revenue);
                _projectList.UpdateProject(newP);
            }
            tbConsole.Text = "Updated Employee:\r\nName: " + employeeName + "\r\nSalary: " + salary + "\r\nDummy Data: " + dummy + "\r\nSalary Accountable: " + sa;
        }// end of EditEmployeeCallbackFn

        // Changing Role(s) / Reporting Officer [ DONE ]
        private void MenuItemChange_Click(object sender, EventArgs e) 
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if (_currentSelectedEmployee == null)
            {
                tbConsole.Text = "You did not select any employee to change role / reporting officer.";
            }
            else
            {
                List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
                _root.getSameEmployeeRolesById(_currentSelectedEmployee.Employee.EmployeeId, ref employeeList);

                if (employeeList.Count > 0 && employeeList.Count < 2)
                {
                    string employeeName = _currentSelectedEmployee.Employee.EmployeeName;
                    tbConsole.Text = employeeName + " has been selected to be change.";

                    ChangeRoleOrOfficer changeForm = new ChangeRoleOrOfficer(
                        _currentSelectedEmployee.Employee.EmployeeId, // id
                        _currentSelectedEmployee.Employee.Role.RoleName, // role
                        _currentSelectedEmployee.Employee.EmployeeName, // name
                        _currentSelectedEmployee.Employee.Salary, // salary
                        _currentSelectedEmployee.TopEmployee.Employee.Role.RoleName, // reporting officer role
                        _currentSelectedEmployee.TopEmployee.Employee.EmployeeName, // reporting officer name
                        _root,
                        _role
                        );
                    changeForm.ChangeCallbackFn = ChangeCallbackFn;
                    changeForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Unable to add more than 2 roles for each employee");
                }
            }
        }// end of MenuItemChange_Click
        private void ChangeCallbackFn(string id, string name, string salary, string role, string reportingOfficer, bool dummy, bool sa) 
        {
            try
            {
                EmployeeTreeNode officerNode = null;
                RoleTreeNode selectedRole = null;
                
                //get role
                _role.getRoleByName(role, ref selectedRole); 
                //get reporting officer treeNode
                _root.getReportingOfficerTreeNode(selectedRole.TopRole.Role.RoleId, reportingOfficer, ref officerNode);

                //Create Employee and TreeNode
                Employee newEmployee = new Employee(id, name, Double.Parse(salary), selectedRole.Role, dummy, sa);
                EmployeeTreeNode treeNode = new EmployeeTreeNode(newEmployee);

                //Add subordinate
                officerNode.AddEmployeeSubordinate(treeNode);
                if (officerNode.Employee.Role.ProjectLeader)
                {
                    treeNode.Employee.Project = officerNode.Employee.Project;
                }
                officerNode.Expand();

                //Set Text
                _root.setEmployeeTreeNodeText(id);

                tbConsole.Text = name + " has added " + role +" role";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end of ChangeCallbackFn

        // Swaping Employee [ DONE ]
        private void MenuItemSwapEmployee_Click(object sender, EventArgs e) 
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if (_currentSelectedEmployee == null)
            {
                tbConsole.Text = "You did not select any employee to swap roles with";
            }
            else
            {
                string employeeName = _currentSelectedEmployee.Employee.EmployeeName;
                tbConsole.Text = employeeName + " has been selected to be swapped";

                // Clone treeNode
                EmployeeTreeNode root = (EmployeeTreeNode)_root.Clone();


                ReplaceEmployeeForm swapForm = new ReplaceEmployeeForm(
                    (EmployeeTreeNode)root,
                    _currentSelectedEmployee.Employee.EmployeeName+" - "+ _currentSelectedEmployee.Employee.Role.RoleName,
                    _currentSelectedEmployee.Employee.Role.RoleId
                    );
                swapForm.SwapEmployeeCallbackFn = SwapEmployeeCallbackFn;
                swapForm.ShowDialog();
            }
        }// end of MenuItemSwapEmployee_Click
        private void SwapEmployeeCallbackFn(Employee selectedEmployee) 
        {
            string id  = _currentSelectedEmployee.Employee.EmployeeId;
            string name = _currentSelectedEmployee.Employee.EmployeeName;
            double salary = _currentSelectedEmployee.Employee.Salary;
            bool dummy = _currentSelectedEmployee.Employee.DummyData;
            bool sa = _currentSelectedEmployee.Employee.SalaryAccountable;
            Project project = _currentSelectedEmployee.Employee.Project;

            EmployeeTreeNode employee = new EmployeeTreeNode();
            _root.getEmployeeById(selectedEmployee.EmployeeId, ref employee);

            // swap values
            _currentSelectedEmployee.Employee.EmployeeId = employee.Employee.EmployeeId;
            _currentSelectedEmployee.Employee.EmployeeName = employee.Employee.EmployeeName;
            _currentSelectedEmployee.Employee.DummyData = employee.Employee.DummyData;
            _currentSelectedEmployee.Employee.SalaryAccountable = employee.Employee.SalaryAccountable;
            _currentSelectedEmployee.Employee.Salary = employee.Employee.Salary;
            if (_currentSelectedEmployee.Employee.Project != null)
            {
                _currentSelectedEmployee.Employee.Project.ProjectLeader = _currentSelectedEmployee.Employee;
                _projectList.UpdateProject(_currentSelectedEmployee.Employee.Project);
            }

            employee.Employee.EmployeeId = id;
            employee.Employee.EmployeeName = name;
            employee.Employee.DummyData = dummy;
            employee.Employee.SalaryAccountable = sa;
            employee.Employee.Salary = salary;
            if(employee.Employee.Project != null)
            {
                employee.Employee.Project.ProjectLeader = employee.Employee;
                _projectList.UpdateProject(employee.Employee.Project);
            }
            // set treeview text
            _root.setEmployeeTreeNodeText(employee.Employee.EmployeeId);
            _root.setEmployeeTreeNodeText(_currentSelectedEmployee.Employee.EmployeeId);

            tbConsole.Text = employee.Employee.EmployeeName + " has been swapped with " + _currentSelectedEmployee.Employee.EmployeeName;
        }//end of SwapEmployeeCallbackFn

        // Remove Employee [ DONE ]
        private void MenuItemRemoveEmployee_Click(object sender, EventArgs e)
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
            _root.getSameEmployeeRolesById(_currentSelectedEmployee.Employee.EmployeeId, ref employeeList);

            // there is multiple employee ---------------------------------------------------
            if (employeeList.Count > 1)
            {
                // There is no subordinate and project
                if (
                    _currentSelectedEmployee.SubordinateEmployee.Count == 0 &&
                    _currentSelectedEmployee.Employee.Project == null
                  )
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm removal of employee? Click OK to proceed", "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _root.RemoveEmployeeByIdAndRoleId(_currentSelectedEmployee.Employee.EmployeeId, _currentSelectedEmployee.Employee.Role.RoleId);
                        _root.setEmployeeTreeNodeText(_currentSelectedEmployee.Employee.EmployeeId);
                    }
                    
                }

                else
                {
                    bool del = true;
                    if (_currentSelectedEmployee.TopEmployee.Employee.Role.ProjectLeader)
                    {
                        List<bool> checking = new List<bool>();
                        List<RoleTreeNode> roleList = new List<RoleTreeNode>();
                        _role.getSubordinateRoleById(_currentSelectedEmployee.TopEmployee.Employee.Role.RoleId, ref roleList);
                        double allrevenue = _currentSelectedEmployee.Employee.Salary;
                        _currentSelectedEmployee.getTopAllSalary(ref allrevenue);

                        foreach (RoleTreeNode roleTreeNode in roleList)
                        {
                            bool check = false;

                            for (int i = 0; i < _currentSelectedEmployee.TopEmployee.SubordinateEmployee.Count; i++)
                            {
                                if (
                                    _currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleTreeNode.Role.RoleId)
                                     )
                                {
                                    if (!_currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.EmployeeId.Equals(_currentSelectedEmployee.Employee.EmployeeId) ||
                                    !_currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.Role.RoleId.Equals(_currentSelectedEmployee.Employee.Role.RoleId))
                                    {
                                        allrevenue += _currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.Salary;
                                        check = true;
                                    }
                                }
                            }

                            checking.Add(check);
                        }

                        if (!checking.Contains(false))
                        {
                            del = false;
                        }

                        if (allrevenue < _currentSelectedEmployee.Employee.Project.Revenue)
                        {
                            MessageBox.Show("Unable to delete employee as total revenue will be lesser than project revenue");
                            del = true;
                        }
                    }

                    if (del)
                    {
                        string text = "The employee can only be removed if there are no subordinates, no assigned projects or if after removal will still remain a full team. Would you like to swap the employee with another first?";
                        DialogResult dialogResult = MessageBox.Show(text, "Swap Employee", MessageBoxButtons.YesNo);

                        // [ DO SWAPING HERE ]
                        if (dialogResult == DialogResult.Yes)
                        {
                            // Clone treeNode
                            EmployeeTreeNode root = (EmployeeTreeNode)_root.Clone();


                            ReplaceEmployeeForm swapForm = new ReplaceEmployeeForm(
                                (EmployeeTreeNode)root,
                                _currentSelectedEmployee.Employee.EmployeeName + " - " + _currentSelectedEmployee.Employee.Role.RoleName,
                                _currentSelectedEmployee.Employee.Role.RoleId
                                );
                            swapForm.SwapEmployeeCallbackFn = SwapEmployeeCallbackFn;
                            swapForm.ShowDialog();
                        }
                    }
                    else
                    {
                        // delete employee
                        DialogResult dialogResult = MessageBox.Show("Confirm removal of employee? Click OK to proceed", "Confirm Deletion", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string name = _currentSelectedEmployee.Employee.EmployeeName;
                            _root.RemoveEmployeeByIdAndRoleId(_currentSelectedEmployee.Employee.EmployeeId, _currentSelectedEmployee.Employee.Role.RoleId);
                            _root.setEmployeeTreeNodeText(_currentSelectedEmployee.Employee.EmployeeId);
                            tbConsole.Text = name + " has been removed";
                        }
                    }
                }
            }

            //there is only 1 employee ---------------------------------------------------------------------------
            else
            {
                // if proj change to class, condition put as [ _currentSelectedEmployee.Employee.Project.Count == 0 ]
                if (
                    _currentSelectedEmployee.SubordinateEmployee.Count == 0 &&
                    _currentSelectedEmployee.Employee.Project == null
                  )
                {

                    DialogResult dialogResult = MessageBox.Show("Confirm removal of employee? Click OK to proceed", "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string name = _currentSelectedEmployee.Employee.EmployeeName;
                        _root.RemoveEmployee(_currentSelectedEmployee.Employee.EmployeeId);
                        _root.setEmployeeTreeNodeText(_currentSelectedEmployee.Employee.EmployeeId);
                        tbConsole.Text = name + " has been removed";
                    }
                }
                else 
                {
                    // checking
                    bool del = true;
                    if( _currentSelectedEmployee.TopEmployee.Employee.Role.ProjectLeader ) 
                    {
                        List<bool> checking = new List<bool>();
                        List<RoleTreeNode> roleList = new List<RoleTreeNode>();
                        _role.getSubordinateRoleById(_currentSelectedEmployee.TopEmployee.Employee.Role.RoleId, ref roleList);
                        double allrevenue = _currentSelectedEmployee.Employee.Salary;
                        _currentSelectedEmployee.getTopAllSalary(ref allrevenue);
                        
                        foreach (RoleTreeNode roleTreeNode in roleList)
                        {
                            bool check = false;

                            for (int i = 0; i < _currentSelectedEmployee.TopEmployee.SubordinateEmployee.Count; i++)
                            {
                                //MessageBox.Show(_currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.EmployeeName);
                                if (
                                    _currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleTreeNode.Role.RoleId) &&
                                    (
                                    !_currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.EmployeeId.Equals(_currentSelectedEmployee.Employee.EmployeeId) ||
                                    !_currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.Role.RoleId.Equals(_currentSelectedEmployee.Employee.Role.RoleId)
                                    )
                                     )
                                {
                                    allrevenue += _currentSelectedEmployee.TopEmployee.SubordinateEmployee[i].Employee.Salary;
                                    check = true;
                                }
                            }

                            checking.Add(check);
                        }
                        
                        if (!checking.Contains(false))
                        {
                            del = false;
                        }
                        
                        if(allrevenue < _currentSelectedEmployee.Employee.Project.Revenue)
                        {
                            MessageBox.Show("Unable to delete employee as total revenue will be lesser than project revenue");
                            del = true;
                        }
                    }
                    if (del)
                    {
                        string text = "The employee can only be removed if there are no subordinates, no assigned projects or if after removal will still remain a full team. Would you like to swap the employee with another first?";
                        DialogResult dialogResult = MessageBox.Show(text, "Swap Employee", MessageBoxButtons.YesNo);

                        // [ DO SWAPING HERE ]
                        if (dialogResult == DialogResult.Yes)
                        {
                            // Clone treeNode
                            EmployeeTreeNode root = (EmployeeTreeNode)_root.Clone();


                            ReplaceEmployeeForm swapForm = new ReplaceEmployeeForm(
                                (EmployeeTreeNode)root,
                                _currentSelectedEmployee.Employee.EmployeeName + " - " + _currentSelectedEmployee.Employee.Role.RoleName,
                                _currentSelectedEmployee.Employee.Role.RoleId
                                );
                            swapForm.SwapEmployeeCallbackFn = SwapEmployeeCallbackFn;
                            swapForm.ShowDialog();
                        }
                    }
                    else
                    {
                        // delete employee
                        DialogResult dialogResult = MessageBox.Show("Confirm removal of employee? Click OK to proceed", "Confirm Deletion", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string name = _currentSelectedEmployee.Employee.EmployeeName;
                            _root.RemoveEmployeeByIdAndRoleId(_currentSelectedEmployee.Employee.EmployeeId, _currentSelectedEmployee.Employee.Role.RoleId);
                            _root.setEmployeeTreeNodeText(_currentSelectedEmployee.Employee.EmployeeId);
                            tbConsole.Text = name + " has been removed";
                        }
                    }
                }
            }// end of else
        }// end of MenuItemRemoveEmployee_Click
        
        // End of Edit/update/remove/add Employee in Context Menu ----------------------------------------------------------------------------

        // Collapse and Expand TreeView ------------------------------------------------------------------------------------------------------

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.ExpandAll();
        }// end of btnExpandAll_Click
        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.CollapseAll();
        }// end of btnCollapseAll_Click

        // End Of Collapse and Expand TreeView -----------------------------------------------------------------------------------------------

        // Save and Load (File IO) -----------------------------------------------------------------------------------------------------------
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            _root.SaveToFileBinary();
            _projectList.SaveToFileBinary();
        }// end of btnSave_Click
        private void btnLoad_Click(object sender, EventArgs e)
        {
            EmployeeTreeNode root;
            // Load from binary
            root = _root.LoadFromFileBinary();

            if(root == null)
            {   
                MessageBox.Show("There is no data in file");
            }
            else
            {
                treeViewEmployee.Nodes.Clear();
                _root = root;
                _root.RebuildTreeNodes();
                treeViewEmployee.Nodes.Add(_root);
                treeViewEmployee.ExpandAll();
            }

        }// end of btnLoad_Click
        private void btnReset_Click(object sender, EventArgs e)
        {
            EmployeeTreeNode root;
            // Load from binary
            root = _root.LoadFromFileBinary();

            if (root == null)
            {
                root = new EmployeeTreeNode(new Employee("root", 0, _role.Role, false, false));
                _root = root;
            }
            else
            {
                treeViewEmployee.Nodes.Clear();
                _root = root;
                _root.RebuildTreeNodes();
                treeViewEmployee.Nodes.Add(_root);
                treeViewEmployee.ExpandAll();
            }
        }// end of btnReset_Click

        // End of Save and Load (File IO) ----------------------------------------------------------------------------------------------

    }
}
