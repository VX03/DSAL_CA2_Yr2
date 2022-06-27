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
        private RoleTreeNode _root;
        private RoleTreeNode _currentSelectedRole;
        public ManageRoles()
        {
            InitializeComponent();
        }

        private void ManageRoles_Load(object sender, EventArgs e)
        {
            treeViewRole.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewRole_NodeMouseClick);
            _root = new RoleTreeNode(new Role("Root",false));
            
            RoleTreeNode Clusterhead = new RoleTreeNode(new Role("Clusterhead", false));
            RoleTreeNode Manager = new RoleTreeNode(new Role("Manager", false));
            RoleTreeNode ProjectManager = new RoleTreeNode(new Role("Project Manager", false));
            RoleTreeNode ProjectLeader = new RoleTreeNode(new Role("Project Leader", true));
            RoleTreeNode backend = new RoleTreeNode(new Role("Backend Developer", false));
            RoleTreeNode frontend = new RoleTreeNode(new Role("Frontend Developer", false));
            RoleTreeNode database = new RoleTreeNode(new Role("Database Engineer", false));
            RoleTreeNode analyst = new RoleTreeNode(new Role("System Analyst", false));

            _root.AddRoleSubordinate(Clusterhead);
            Clusterhead.AddRoleSubordinate(Manager);
            Manager.AddRoleSubordinate(ProjectManager);
            ProjectManager.AddRoleSubordinate(ProjectLeader);
            ProjectLeader.AddRoleSubordinate(backend);
            ProjectLeader.AddRoleSubordinate(frontend);
            ProjectLeader.AddRoleSubordinate(database);
            ProjectLeader.AddRoleSubordinate(analyst);

            treeViewRole.Nodes.Add(_root);
            treeViewRole.ExpandAll();

        }//manageRoles_load
        private void treeViewRole_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _currentSelectedRole = (RoleTreeNode)treeViewRole.SelectedNode;
            if (_currentSelectedRole != null)
            {
                tbId.Text = _currentSelectedRole.Role.RoleId;
                tbName.Text = _currentSelectedRole.Role.RoleName;
                cbLeader.Checked = _currentSelectedRole.Role.ProjectLeader;

                if (e.Button == MouseButtons.Right)
                {    
                    createContextMenu(_currentSelectedRole);
                }
            }
            
        }//end of treeViewRole_NodeMouseClick
        private void createContextMenu(RoleTreeNode node)
        {
            ToolStripMenuItem menuItemAddRole,menuItemRemoveRole,menuItemEditRole;

            if (node != null && node.Parent == null)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                menuItemAddRole = new ToolStripMenuItem("Add Role");
                menuItemAddRole.Click += new EventHandler(MenuItemAddRole_Click);
                menuStrip.Items.Add(menuItemAddRole);
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
        // Add Role---------------------------------------------------------------------------------------
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
        private void AddRoleCallbackFn( string roleName, bool projectLeader)
        {
            tbConsole.Text = "Role Added:\r\nName: "+roleName+"\r\nProject Leader:"+projectLeader.ToString();
            RoleTreeNode tempRole = new RoleTreeNode(new Role(roleName, projectLeader));
            _currentSelectedRole.AddRoleSubordinate(tempRole);
        }//end of AddRoleCallbackFn
        // End of Add Role--------------------------------------------------------------------------------
        // Edit Role---------------------------------------------------------------------------------------
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
                string parentName = _currentSelectedRole.Parent.Text;
                tbConsole.Text = roleName + " has been selected to be edited";
                EditRole editForm = new EditRole(roleName,parentName,uuid,projectLeader);
                editForm.EditRoleCallbackFn = EditRoleCallbackFn;
                editForm.ShowDialog();
            }
        }
        private void EditRoleCallbackFn(string roleName, bool projectLeader) 
        {
            tbConsole.Text = "Edited Role:\r\nName:"+roleName+"\r\nProjectLeader:"+projectLeader.ToString();
            _currentSelectedRole.UpdateRole(roleName,projectLeader);

        }
        // End of Edit Role--------------------------------------------------------------------------------
        // Remove Role---------------------------------------------------------------------------------------
        private void MenuItemRemoveRole_Click(object sender, EventArgs e)
        {
            _currentSelectedRole = (RoleTreeNode)treeViewRole.SelectedNode;
            _root.RemoveRole(_currentSelectedRole.Role.RoleId);
        }
        // End of Remove Role--------------------------------------------------------------------------------
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeViewRole.ExpandAll();
        }
        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewRole.CollapseAll();
        }
    }
}
