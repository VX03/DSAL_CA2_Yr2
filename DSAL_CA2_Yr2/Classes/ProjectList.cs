using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    public class ProjectList
    {
        private List<Project> _projectList;

        public ProjectList()
        {
            this._projectList = new List<Project>();
        }// end of constructor
        public List<Project> List {
            get { return _projectList; }
            set { _projectList = value; }
        }
        public void AddProject(Project project)
        {
            this.List.Add(project);
        }
        public void UpdateProject(Project project)
        {
            Project p = this.List.Find(proj => proj.ProjectId.Equals(project.ProjectId) );

            if (p != null)
            {
                p.ProjectName = project.ProjectName;
                p.ProjectLeader = project.ProjectLeader;
                p.Revenue = project.Revenue;
            }
        }// end of update
        public void deleteProject(string id)
        {
            Project p = this.List.Find(proj => proj.ProjectId.Equals(id));
            this.List.Remove(p);
        }// remove item
    }
}
