using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    public class Employee
    {
        private string _employeeName;
        private string _employeeId;
        private double _salary;
        private string _project; //Change to project (set as project name first)
        private Role _role;
        private bool _dummyData;
        private bool _salaryAccountable;
        public Employee(string _employeeName, double _salary, Role role, bool dummy, bool accountable)
        {
            this._employeeName = _employeeName;
            this._salary = _salary;
            this._role = role;
            this._dummyData = dummy;
            this._salaryAccountable = accountable;
            this._employeeId = UUID.GenerateUUID();
        }
        public Employee()
        {
            this._employeeId= UUID.GenerateUUID();
        }
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }
        public string EmployeeId
        { 
            get { return _employeeId; }
        }
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string Project
        {
            get { return _project; }
            set { _project = value; }
        }
        public bool DummyData
        {
            get { return _dummyData; }
            set { _dummyData = value; }
        }
        public bool SalaryAccountable
        {
            get { return _salaryAccountable; }
            set { _salaryAccountable = value; }
        }
    }
}
