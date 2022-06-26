using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    public class Role
    {
        private string roleId;
        private string roleName;
        private bool projectLeader;

        public Role(string roleName, bool projectLeader) {
            this.projectLeader = projectLeader;
            this.roleName = roleName;
            this.roleId = generateId();
        }
        public Role() 
        {
            this.roleId = generateId();
        }
        public string generateId()
        {
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            return myuuidAsString;
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
