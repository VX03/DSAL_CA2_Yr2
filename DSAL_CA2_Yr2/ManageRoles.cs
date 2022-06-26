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

        }//manageRoles_load
        private void treeViewRole_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Hello");
            }
        }//end of treeViewRole_NodeMouseClick
        private void createMenu()
        {
            
        }
    }
}
