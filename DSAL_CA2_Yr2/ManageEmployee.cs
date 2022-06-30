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
        public ManageEmployee()
        {
            InitializeComponent();
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            treeViewEmployee.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewEmployee_NodeMouseClick);
            // [ Get data from file ]
            //testing with  generated roles
            _role = general.AutomaticGenerateRole();

            EmployeeTreeNode root = new EmployeeTreeNode(new Employee("root", 0, _role.Role, false, false));
            _root = root;

            treeViewEmployee.Nodes.Add(root);
        }// End of ManageEmployee_Load

        // Create Context Menu on Right Click ------------------------------------------------------------------------------------------------

        private void treeViewEmployee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;
            if (_currentSelectedEmployee != null)
            {
                string id = "", project = "", name = "", salary = "", role = "", officername = "";

                id = _currentSelectedEmployee.Employee.EmployeeId;
                
                name = _currentSelectedEmployee.Employee.EmployeeName;
                salary = _currentSelectedEmployee.Employee.Salary.ToString();
                role = _currentSelectedEmployee.Employee.Role.RoleName;
                if (_currentSelectedEmployee.TopEmployee != null)
                {
                    if (_currentSelectedEmployee.Employee.Project != null)
                    {
                        project = _currentSelectedEmployee.Employee.Project;
                    }
                    else
                        project = "N.A.";
                    
                    officername = _currentSelectedEmployee.TopEmployee.Employee.EmployeeName;
                }
                else
                    officername = "N.A";

                

                    
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
        private void EditEmployeeCallbackFn(string employeeName, double salary, bool dummy, bool sa)
        {
            _currentSelectedEmployee.UpdateEmployee(employeeName, salary, dummy, sa);
            tbConsole.Text = "Updated Employee:\r\nName: " + employeeName + "\r\nSalary: " + salary + "\r\nDummy Data: " + dummy + "\r\nSalary Accountable: " + sa;
        }// end of EditEmployeeCallbackFn

        // Changing Role(s) / Reporting Officer [ NOT DONE ]
        private void MenuItemChange_Click(object sender, EventArgs e) { }// end of MenuItemChange_Click
        private void ChangeCallbackFn() { }//end of ChangeCallbackFn

        // Swaping Employee [ NOT DONE ]
        private void MenuItemSwapEmployee_Click(object sender, EventArgs e) { }// end of MenuItemSwapEmployee_Click
        private void SwapEmployeeCallbackFn() { }//end of SwapEmployeeCallbackFn

        // Remove Employee [ NOT DONE / NEED CHANGING ]
        private void MenuItemRemoveEmployee_Click(object sender, EventArgs e)
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;
            
            // if proj change to class, condition put as [ _currentSelectedEmployee.Employee.Project.Count == 0 ]
            if(_currentSelectedEmployee.SubordinateEmployee.Count == 0 && _currentSelectedEmployee.Employee.Project == null)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm removal of employee? Click OK to proceed", "Confirm Deletion", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    string name = _currentSelectedEmployee.Employee.EmployeeName;
                    _root.RemoveEmployee(_currentSelectedEmployee.Employee.EmployeeId);
                    tbConsole.Text = name + " has been removed";
                }
            }
            // if proj change to class, condition put as [ _currentSelectedEmployee.Employee.Project.Count != 0 ]
            else if (_currentSelectedEmployee.SubordinateEmployee.Count != 0 || _currentSelectedEmployee.Employee.Project != null)
            {
                string text = "The employee can only be removed if there are no subordinates, no assigned projects or if after removal will still remain a full team. Would you like to swap the employee with another first?";
                DialogResult dialogResult = MessageBox.Show(text, "Swap Employee", MessageBoxButtons.YesNo);
                
                // [ DO SWAPING HERE ]
                if(dialogResult == DialogResult.Yes)
                {
                    
                    MessageBox.Show("Swap here");
                }
            }
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
    }
}
