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
                string id = _currentSelectedEmployee.Employee.EmployeeId;
                string project = _currentSelectedEmployee.Employee.Project;
                string officername = _currentSelectedEmployee.Employee.EmployeeName;
                string name = _currentSelectedEmployee.Employee.EmployeeName;
                string salary = _currentSelectedEmployee.Employee.Salary.ToString();
                string role = _currentSelectedEmployee.Employee.Role.RoleName;
                if(project == null)
                {
                    project = "No Projects";
                }
                if(officername == null)
                {
                    officername = "No reporting officer";
                }
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
            ToolStripMenuItem menuItemAddEmployee, menuItemRemoveEmployee, menuItemEditEmployee, editEmployeeDetails, menuItemchange, menuItemSwapEmployee;

            if (node != null && node.TopEmployee == null)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                menuItemAddEmployee = new ToolStripMenuItem("Add Employee");
                menuItemAddEmployee.Click += new EventHandler(MenuItemAddEmployee_Click);
                menuStrip.Items.Add(menuItemAddEmployee);
                this.ContextMenuStrip = menuStrip;
            }
            else if(node != null && node.TopEmployee.Employee.Role.ProjectLeader)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();

                //add menu items

                menuItemEditEmployee = new ToolStripMenuItem("Edit Employee");
                editEmployeeDetails = new ToolStripMenuItem("EditEmployeeDetails");
                menuItemchange = new ToolStripMenuItem("Change Role/Reporting Officer");
                menuItemEditEmployee.DropDownItems.Add(editEmployeeDetails);
                menuItemEditEmployee.DropDownItems.Add(menuItemchange);

                menuItemRemoveEmployee = new ToolStripMenuItem("Remove Employee");
                menuItemSwapEmployee = new ToolStripMenuItem("Swap Employee");

                //add event handler
                //menuItemEditRole.Click += new EventHandler(MenuItemEditRole_Click);
                //menuItemRemoveRole.Click += new EventHandler(MenuItemRemoveRole_Click);
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
                editEmployeeDetails = new ToolStripMenuItem("EditEmployeeDetails");
                menuItemchange = new ToolStripMenuItem("Change Role/Reporting Officer");
                menuItemEditEmployee.DropDownItems.Add(editEmployeeDetails);
                menuItemEditEmployee.DropDownItems.Add(menuItemchange);

                menuItemRemoveEmployee = new ToolStripMenuItem("Remove Employee");
                menuItemSwapEmployee = new ToolStripMenuItem("Swap Employee");

                //add event handler
                menuItemAddEmployee.Click += new EventHandler(MenuItemAddEmployee_Click);
                //menuItemEditRole.Click += new EventHandler(MenuItemEditRole_Click);
                //menuItemRemoveRole.Click += new EventHandler(MenuItemRemoveRole_Click);
                //menu strip add item
                menuStrip.Items.Add(menuItemAddEmployee);
                menuStrip.Items.Add(menuItemEditEmployee);
                menuStrip.Items.Add(menuItemRemoveEmployee);
                menuStrip.Items.Add(menuItemSwapEmployee);
                this.ContextMenuStrip = menuStrip;
            }
        }//end of createContextMenu

        // End of Create Context Menu on Right Click -----------------------------------------------------------------------------------------

        // Edit/update/remove Employee in Context Menu ---------------------------------------------------------------------------------------

        // Add Employee
        private void MenuItemAddEmployee_Click(object sender, EventArgs e)
        {
            _currentSelectedEmployee = (EmployeeTreeNode)treeViewEmployee.SelectedNode;

            if (_currentSelectedEmployee == null)
            {
                tbConsole.Text = "You did not select any employee to add a subordinate.\r\n\r\n";
            }
            else
            {
                string employeeName = _currentSelectedEmployee.Employee.EmployeeName;
                tbConsole.Text = employeeName + " has been selected to add a new subordinate\r\n\r\n";

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
        }// end of AddEmployeeCallbackFn

        // End of Edit/update/remove Employee in Context Menu --------------------------------------------------------------------------------

        // Collapse and Expand TreeView-------------------------------------------------------------------------------------------------------

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.ExpandAll();
        }// end of btnExpandAll_Click
        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewEmployee.CollapseAll();
        }// end of btnCollapseAll_Click

        // End Of Collapse and Expand TreeView------------------------------------------------------------------------------------------------
    }
}
