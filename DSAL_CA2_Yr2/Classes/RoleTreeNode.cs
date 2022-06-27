using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2.Classes
{
    public class RoleTreeNode : TreeNode
    {
        private Role _role = new Role();
        private RoleTreeNode _topRole = null;
        private List<RoleTreeNode> _subordinateRoles;

        public RoleTreeNode()
        {
            _subordinateRoles = new List<RoleTreeNode>();
        }
        public RoleTreeNode(Role role)
        {
            _subordinateRoles = new List<RoleTreeNode>();
            _role = role;

            this.Text = _role.RoleName;
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public RoleTreeNode TopRole
        {
            get { return _topRole; }
            set { _topRole = value; }
        }
        public List<RoleTreeNode> SubordinateRoles
        {
            get { return _subordinateRoles; }
            set { _subordinateRoles = value; }
        }
        public void AddRoleSubordinate(RoleTreeNode roleNode)
        {
            roleNode.TopRole = this;
            
            _subordinateRoles.Add(roleNode);

            this.Nodes.Add(roleNode);
        }
        public void UpdateRole(string roleName, bool projectleader)
        {
            this.Text = roleName;
            this.Role.RoleName = roleName;
            this.Role.ProjectLeader = projectleader;
        }
        public void RemoveRole(string roleId)
        {
            for(int i = 0; i < this.SubordinateRoles.Count; i++)
            {
                if(this.SubordinateRoles[i].Role.RoleId.Equals(roleId))
                {
                    
                    this.Nodes.Remove(this.SubordinateRoles[i]);
                    this.SubordinateRoles.Remove(this.SubordinateRoles[i]);
                }
                if(this.SubordinateRoles.Count != 0 && i<this.SubordinateRoles.Count) 
                {
                    this.SubordinateRoles[i].RemoveRole(roleId);
                }

            }
        }
    }
}
