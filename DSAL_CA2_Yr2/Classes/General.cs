using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    public class General
    {
        public bool checkAlphabetAndSpace(string s)
        {
            if (s == null)
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsLetter(s[i]) && !Char.IsWhiteSpace(s[i]))
                {
                    return false;
                }
            }
            return true;
        }// End of checkAlphabetAndSpace
        public RoleTreeNode AutomaticGenerateRole()
        {
            RoleTreeNode _root = new RoleTreeNode(new Role("Root", false));

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

            return _root;
        }//end of AutomaticGenerateRole
        
    }
}
