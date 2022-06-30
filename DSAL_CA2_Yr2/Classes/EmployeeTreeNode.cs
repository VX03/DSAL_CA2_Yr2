using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2.Classes
{
    public class EmployeeTreeNode : TreeNode, ISerializable
    {
        private Employee _employee;
        private EmployeeTreeNode _topEmployee = null;
        private List<EmployeeTreeNode> _subordinateEmployee;

        public EmployeeTreeNode(Employee _employee)
        {
            _subordinateEmployee = new List<EmployeeTreeNode>();
            this._employee = _employee;

            this.Text = _employee.EmployeeName +" - "+_employee.Role.RoleName + " (S$" + _employee.Salary +")";
        }
        public EmployeeTreeNode()
        {
            _subordinateEmployee = new List<EmployeeTreeNode>();
        }
        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }
        public EmployeeTreeNode TopEmployee
        {
            get { return _topEmployee; }
            set { _topEmployee = value; }
        }
        public List<EmployeeTreeNode> SubordinateEmployee
        {
            get { return _subordinateEmployee; }
            set { _subordinateEmployee = value; }
        }
        public void AddEmployeeSubordinate(EmployeeTreeNode employeeNode)
        {
            employeeNode.TopEmployee = this;
            SubordinateEmployee.Add(employeeNode); 

            this.Nodes.Add(employeeNode);
        }//end of AddEmployeeSubordinate
        public void RemoveEmployee(string employeeId)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(employeeId))
                {
                    this.Nodes.Remove(this.SubordinateEmployee[i]);
                    this.SubordinateEmployee.Remove(this.SubordinateEmployee[i]);
                    return;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].RemoveEmployee(employeeId);
                }
            }
        }//end of Remove Employee
    }
}
