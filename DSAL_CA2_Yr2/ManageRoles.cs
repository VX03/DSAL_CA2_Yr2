using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DSAL_CA2_Yr2.Classes;

namespace DSAL_CA2_Yr2
{
    public partial class ManageRoles : Form
    {
        private EmployeeTreeNode _employee = new EmployeeTreeNode();
        private RoleTreeNode _root = new RoleTreeNode();
        private RoleTreeNode _currentSelectedRole;
        private General general = new General();
        public ManageRoles()
        {
            InitializeComponent();
        }

        // Load data from binary file / automatically generate data
        private void ManageRoles_Load(object sender, EventArgs e)
        {
            treeViewRole.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewRole_NodeMouseClick);

            _root = _root.LoadFromFileBinary();
            _employee = _employee.LoadFromFileBinary();
            if(_employee == null)
            {
                _employee = new EmployeeTreeNode();
            }

            if (_root == null)
            {
                _root = general.AutomaticGenerateRole();
                MessageBox.Show("There is no Data in file. Data is automatically created and saved to file");
                _root.SaveToFileBinary();

            }//Automatically Create roles
            else
            {
                _root.RebuildTreeNodes();
            }
            treeViewRole.Nodes.Add(_root);
            treeViewRole.ExpandAll();

        }//manageRoles_load

        // Create Context Menu on Right Click ----------------------------------------------------------------------------------------
        private void treeViewRole_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _currentSelectedRole = (RoleTreeNode)treeViewRole.SelectedNode;
            if (_currentSelectedRole != null)
            {
                tbId.Text = _currentSelectedRole.Role.RoleId;
                tbName.Text = _currentSelectedRole.Role.RoleName;
                cbLeader.Checked = _currentSelectedRole.Role.ProjectLeader;
                tbConsole.Text = _currentSelectedRole.Role.RoleName + " has been selected";
                if (e.Button == MouseButtons.Right)
                {    
                    createContextMenu(_currentSelectedRole);
                }
            }
            
        }//end of treeViewRole_NodeMouseClick
        private void createContextMenu(RoleTreeNode node)
        {
            ToolStripMenuItem menuItemAddRole,menuItemRemoveRole,menuItemEditRole;

            if (node != null && node.TopRole == null)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                menuItemAddRole = new ToolStripMenuItem("Add Role");
                menuItemAddRole.Click += new EventHandler(MenuItemAddRole_Click);
                menuStrip.Items.Add(menuItemAddRole);
                this.ContextMenuStrip = menuStrip;
            }
            else if(node != null && node.TopRole.Role.ProjectLeader)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                menuItemEditRole = new ToolStripMenuItem("Edit Role");
                menuItemRemoveRole = new ToolStripMenuItem("Remove Role");

                menuItemEditRole.Click += new EventHandler(MenuItemEditRole_Click);
                menuItemRemoveRole.Click += new EventHandler(MenuItemRemoveRole_Click);
                menuStrip.Items.Add(menuItemEditRole);
                menuStrip.Items.Add(menuItemRemoveRole);
                this.ContextMenuStrip = menuStrip;
            }
            else if(node != null)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                //add menu items
                menuItemAddRole = new ToolStripMenuItem("Add Role");
                menuItemEditRole = new ToolStripMenuItem("Edit Role");
                menuItemRemoveRole = new ToolStripMenuItem("Remove Role");
                //add event handler
                menuItemAddRole.Click += new EventHandler(MenuItemAddRole_Click);
                menuItemEditRole.Click += new EventHandler(MenuItemEditRole_Click);
                menuItemRemoveRole.Click += new EventHandler(MenuItemRemoveRole_Click);
                //menu strip add item
                menuStrip.Items.Add(menuItemAddRole);
                menuStrip.Items.Add(menuItemEditRole);
                menuStrip.Items.Add(menuItemRemoveRole);
                this.ContextMenuStrip = menuStrip;
            }
        }//end of createContextMenu

        // End of Create Context Menu on Right Click ---------------------------------------------------------------------------------

        // Edit/update/remove role in Context Menu -----------------------------------------------------------------------------------

        // Add Role [ DONE ]
        private void MenuItemAddRole_Click(object sender, EventArgs e)
        {
            _currentSelectedRole = (RoleTreeNode)treeViewRole.SelectedNode;
            if(_currentSelectedRole == null)
            {
                tbConsole.Text = "You did not select any role to add a role.\r\n\r\n";
            }
            else
            {
                string roleName = _currentSelectedRole.Role.RoleName;
                tbConsole.Text = roleName + " has been selected to add a new subordinate\r\n\r\n";
                AddRole addForm = new AddRole(roleName);
                addForm.AddRoleCallbackFn = AddRoleCallbackFn;
                addForm.ShowDialog();
            }
        }//end of MenuItemAddRole_Click
        private void AddRoleCallbackFn(string roleName, bool projectLeader)
        {
            tbConsole.Text = "Role Added:\r\nName: "+roleName+"\r\nProject Leader: "+projectLeader.ToString();
            RoleTreeNode tempRole = new RoleTreeNode(new Role(roleName, projectLeader));
            _currentSelectedRole.AddRoleSubordinate(tempRole);
            treeViewRole.SelectedNode.Expand();
        }//end of AddRoleCallbackFn

        // Edit Role [ DONE ]
        private void MenuItemEditRole_Click(object sender, EventArgs e)
        {
            _currentSelectedRole = (RoleTreeNode)treeViewRole.SelectedNode;
            if (_currentSelectedRole == null)
            {
                tbConsole.Text = "You did not select any role to edit.";
            }
            else
            {
                string roleName = _currentSelectedRole.Role.RoleName;
                string uuid = _currentSelectedRole.Role.RoleId;
                bool projectLeader = _currentSelectedRole.Role.ProjectLeader;
                string parentName = _currentSelectedRole.TopRole.Role.RoleName;

                tbConsole.Text = roleName + " has been selected to be edited";

                EditRole editForm = new EditRole(_currentSelectedRole, _employee);
                editForm.EditRoleCallbackFn = EditRoleCallbackFn;
                editForm.ShowDialog();
            }
        }// End of MenuItemEditRole_Click
        private void EditRoleCallbackFn(string roleName, bool projectLeader) 
        {
            _currentSelectedRole.UpdateRole(roleName,projectLeader);
            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
   
            _employee.getAllEmployeeByRoleId(_currentSelectedRole.Role.RoleId, ref employeeList);

            foreach(EmployeeTreeNode employee in employeeList)
            {
                employee.Employee.Role = _currentSelectedRole.Role;
            }

            tbConsole.Text = "Edited Role:\r\nName: "+roleName+"\r\nProjectLeader: "+projectLeader.ToString();
            

        }//end of EditRoleCallbackFn

        //Remove Role [ DONE ]
        private void MenuItemRemoveRole_Click(object sender, EventArgs e)
        {

            _currentSelectedRole = (RoleTreeNode)treeViewRole.SelectedNode;
            string name = _currentSelectedRole.Role.RoleName;

            if (_employee == null)
            {    
                _root.RemoveRole(_currentSelectedRole.Role.RoleId);
                tbConsole.Text = name + " has been removed";
            }
            else
            {
                bool check = false;
                _employee.checkHaveEmployeeForRole(_currentSelectedRole.Role.RoleId, ref check);
                if (check)
                {
                    MessageBox.Show("Unable to delete " + name + " as there is employees under the role");
                }
                else
                {
                    _root.RemoveRole(_currentSelectedRole.Role.RoleId);
                    tbConsole.Text = name + " has been removed";
                }
            }
        }// End of MenuItemRemoveRole_Click

        // End of Edit/update/remove Role in Context Menu -----------------------------------------------------------------------------

        // Collapse and Expand TreeView------------------------------------------------------------------------------------------------
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeViewRole.ExpandAll();
        }
        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewRole.CollapseAll();
        }

        // End Of Collapse and Expand TreeView-----------------------------------------------------------------------------------------

        // Save and Load (File IO) ----------------------------------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            _employee.SaveToFileBinary();
            _root.SaveToFileBinary();
        }// btnSave_Click
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Clear all Nodes in treeView
            treeViewRole.Nodes.Clear();
            // Load from binary
            _root = _root.LoadFromFileBinary();
            _employee = _employee.LoadFromFileBinary();
            // Add to treeView
            _root.RebuildTreeNodes();
            treeViewRole.Nodes.Add(_root);
            treeViewRole.ExpandAll();

        }// End of btnLoad_Click
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all Nodes in treeView
            treeViewRole.Nodes.Clear();
            // Load from binary
            _root = _root.LoadFromFileBinary();

            if (_root == null)
            {
                _root = general.AutomaticGenerateRole();
                MessageBox.Show("There is no Data in file. Data is automatically created and saved to file");
                _root.SaveToFileBinary();

            }//Automatically Create roles
            else
            {
                _root.RebuildTreeNodes();
            }
            treeViewRole.Nodes.Add(_root);
            treeViewRole.ExpandAll();

        }// End of btnReset_Click

        // End of Save and Load (File IO) ----------------------------------------------------------------------------------------------

    }
}
