using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    public class Project
    {
        private string _projectName;
        private string _projectId;
        private string _projectLeaderId;
        private double _revenue;
        
        public Project()
        {
            _projectId = UUID.GenerateUUID();
        }
        public Project(string projectName, string projectLeaderId, double revenue) 
        {
            _projectId = UUID.GenerateUUID();
            _projectName = projectName;
            _projectLeaderId = projectLeaderId;
            _revenue = revenue;
        }
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }
        public string ProjectLeaderId
        {
            get { return _projectLeaderId; }
            set { _projectLeaderId = value; }
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
