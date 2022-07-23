    using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    [Serializable]
    public class Project
    {
        private string _projectName;
        private string _projectId;
        private Employee _projectLeader;
        private double _revenue;
        
        public Project()
        {
            _projectId = UUID.GenerateUUID();
        }
        public Project(string projectName, Employee projectLeaderId, double revenue) 
        {
            _projectId = UUID.GenerateUUID();
            _projectName = projectName;
            _projectLeader = projectLeaderId;
            _revenue = revenue;
        }
        public Project(string projectId, string projectName, Employee projectLeader, double revenue)
        {
            this._projectId = projectId;
            this._projectName = projectName;
            this._projectLeader = projectLeader;
            this.Revenue = revenue;
        }
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }
        public Employee ProjectLeader
        {
            get { return _projectLeader; }
            set { _projectLeader = value; }
        }
        public string ProjectId
        {
            get { return _projectId; }
        }
        public double Revenue
        {
            get { return _revenue; }
            set { _revenue = value; }
        }
    }
}
