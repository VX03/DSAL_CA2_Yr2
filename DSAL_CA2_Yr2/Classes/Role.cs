using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    [Serializable]
    public class Role
    {
        private string roleId;
        private string roleName;
        private bool projectLeader;
        // private RoleTreNode _container;

        public Role(string roleName, bool projectLeader) {
            this.projectLeader = projectLeader;
            this.roleName = roleName;
            this.roleId = UUID.GenerateUUID();
        }
        public Role() 
        {
            this.roleId = UUID.GenerateUUID();
            this.roleName = null;
            this.ProjectLeader = false;
        }
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        public string RoleId
        {
            get { return roleId; }
        }
        public bool ProjectLeader
        {
            get { return projectLeader; }
            set { projectLeader = value; }
        }
    }
}
