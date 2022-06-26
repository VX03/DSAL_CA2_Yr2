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
        private Role _role;
        private RoleTreeNode _currentSelectedRole;
        public ManageRoles()
        {
            InitializeComponent();
        }

        private void ManageRoles_Load(object sender, EventArgs e)
        {
            treeViewRole.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewRole_NodeMouseClick);
            RoleTreeNode _root = new RoleTreeNode(new Role("Root",false));
            
            RoleTreeNode newRole1 = new RoleTreeNode(new Role("Root1", false));
            RoleTreeNode newRole2 = new RoleTreeNode(new Role("Root2", false));
            RoleTreeNode newRole3 = new RoleTreeNode(new Role("Root3", true));

            _root.AddRoleSubordinate(newRole1);
            _root.AddRoleSubordinate(newRole2);
            newRole2.AddRoleSubordinate(newRole3);
            
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
                menuItemAddRole = new ToolStripMenuItem("Add Role");
                menuItemEditRole = new ToolStripMenuItem("Edit Role");
                menuItemRemoveRole = new ToolStripMenuItem("Remove Role");
                menuItemAddRole.Click += new EventHandler(MenuItemAddRole_Click);
                menuStrip.Items.Add(menuItemAddRole);
                menuStrip.Items.Add(menuItemEditRole);
                menuStrip.Items.Add(menuItemRemoveRole);
                this.ContextMenuStrip = menuStrip;
            }
        }//end of createContextMenu
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
