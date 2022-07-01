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
        // Funtions -------------------------------------------------------------------------------------------------------
        public void getEmployeeById(string employeeId, ref EmployeeTreeNode employee)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(employeeId))
                {
                    employee = this.SubordinateEmployee[i];
                    return;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getEmployeeById(employeeId,ref employee);
                }
            }

        }
        public void getSameEmployeeRolesById(string employeeId, ref List<EmployeeTreeNode> employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {   
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(employeeId))
                {
                    employeeList.Add(this.SubordinateEmployee[i]);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getSameEmployeeRolesById(employeeId, ref employeeList);
                }
            }
        }// end of getEmployeeRolesById
        public void getAllReportingOfficerDuplicate(string role,ref List<string> employeeList)
        {
            if (this.Employee.Role.RoleName.Equals(role))
            {
                employeeList.Add(this.Employee.EmployeeName);
            }
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Role.RoleName.Equals(role))
                {
                    employeeList.Add(this.SubordinateEmployee[i].Employee.EmployeeName);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getAllReportingOfficerDuplicate( role,ref employeeList);
                }
            }

        }// end of getAllReportingOfficerDuplicate
        public List<string> getAllReportingOfficer(string role)
        {
            List<string> newEmployeeList = new List<string>();
            List<string> employeeList = new List<string>();

            getAllReportingOfficerDuplicate(role,ref newEmployeeList);
            foreach(string employee in newEmployeeList)
            {
                if (!employeeList.Contains(employee))
                {
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }// end of getAllReportingOfficer
        public void setEmployeeTreeNodeText(string employeeId)
        {
            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
            
            getSameEmployeeRolesById(employeeId, ref employeeList);
            if(employeeList.Count > 1)
            {
                string text = "";
                foreach(EmployeeTreeNode employeeTreeNode in employeeList)
                {
                    if(text == "")
                        text += employeeTreeNode.Employee.Role.RoleName;
                    else
                        text += " ," + employeeTreeNode.Employee.Role.RoleName;
                }

                foreach(EmployeeTreeNode employeeTreeNode in employeeList)
                {
                    employeeTreeNode.Text = text +" (S$"+employeeTreeNode.Employee.Salary+")";
                }
            }
        }// end of setEmployeeTreeNodeText
        public void AddEmployeeSubordinate(EmployeeTreeNode employeeNode)
        {
            employeeNode.TopEmployee = this;
            SubordinateEmployee.Add(employeeNode); 

            this.Nodes.Add(employeeNode);
        }//end of AddEmployeeSubordinate
        public void UpdateEmployee(string employeeName, double salary, bool dummy, bool sa)
        {
            this.Text = employeeName + " - " + _employee.Role.RoleName + " (S$" + salary + ")";
            this.Employee.EmployeeName = employeeName;
            this.Employee.Salary = salary;
            this.Employee.DummyData = dummy;
            this.Employee.SalaryAccountable = sa;
        }//End Of UpdateRole
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

        // End of Functions -----------------------------------------------------------------------------------------------

        // File IO Functions ----------------------------------------------------------------------------------------------

        // End Of File IO Functions ---------------------------------------------------------------------------------------
    }
}
