using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DSAL_CA2_Yr2.Classes
{
    [Serializable]
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
        public void getAllEmployee(ref List<EmployeeTreeNode> employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                employeeList.Add(this.SubordinateEmployee[i]);   
                
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getAllEmployee(ref employeeList);
                }
            }
        }// end of getAllEmployee
        public void getEmployeeById(string employeeId, ref EmployeeTreeNode employee)
        {
            if (this.Employee.EmployeeId.Equals(employeeId))
            {
                employee = this;
                return;
            }
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

        }// end of getEmployeeById 
        public void getAllSalary(ref double revenue) 
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                    revenue += this.SubordinateEmployee[i].Employee.Salary;

                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getAllSalary(ref revenue);
                }
            }
        } 
        public void getTopAllSalary(ref double revenue)
        {
            EmployeeTreeNode TopEmployee = this.TopEmployee;
            while (TopEmployee != null)
            {
                revenue += TopEmployee.Employee.Salary;
                TopEmployee = TopEmployee.TopEmployee;
            }
        }
        public void getEmployeeByName(string name, ref List<EmployeeTreeNode> employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeName.Equals(name))
                {
                    employeeList.Add(this.SubordinateEmployee[i]);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getEmployeeByName(name, ref employeeList);
                }
            }
        }// end of getEmployeeByName
        public void getEmployeeByIdAndRoleId(string id,string roleid, ref EmployeeTreeNode employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(id) && this.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleid))
                {
                    employeeList = this.SubordinateEmployee[i];
                    return;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getEmployeeByIdAndRoleId(id,roleid, ref employeeList);
                }
            }
        }// end of getEmployeeByName
        public void getEmployeeByIdAndRoleName(string id, string roleid, ref EmployeeTreeNode employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(id) && this.SubordinateEmployee[i].Employee.Role.RoleName.Equals(roleid))
                {
                    employeeList = this.SubordinateEmployee[i];
                    return;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getEmployeeByIdAndRoleName(id, roleid, ref employeeList);
                }
            }
        }// end of getEmployeeByName
        public void getEmployeeWithLeader(ref List<EmployeeTreeNode> employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Role.ProjectLeader)
                {
                    employeeList.Add(this.SubordinateEmployee[i]);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getEmployeeWithLeader(ref employeeList);
                }
            }
        }// end of getEmployeeWithLeader
        public void getEmployeeByProjectId(string projectId, ref List<EmployeeTreeNode> employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Project != null && this.SubordinateEmployee[i].Employee.Project.ProjectId.Equals(projectId))
                {
                    employeeList.Add(this.SubordinateEmployee[i]);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getEmployeeByProjectId(projectId, ref employeeList);
                }
            }
        }//end of getEmployeeByProjectId
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
        public void getAllEmployeeDuplicate(string role,ref List<Employee> employeeList)
        {
            if (this.Employee.Role.RoleName.Equals(role))
            {
                employeeList.Add(this.Employee);
            }
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Role.RoleName.Equals(role))
                {
                    employeeList.Add(this.SubordinateEmployee[i].Employee);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getAllEmployeeDuplicate( role,ref employeeList);
                }
            }

        }// end of getAllReportingOfficerDuplicate
        public void getAllEmployeeByRoleId(string role,ref List<EmployeeTreeNode> employeeList)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Role.RoleId.Equals(role))
                {
                    employeeList.Add(this.SubordinateEmployee[i]);
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getAllEmployeeByRoleId(role, ref employeeList);
                }
            }
        }
        public List<string> getAllEmployeeByRole(string role)
        {
            List<Employee> newEmployeeList = new List<Employee>();
            List<Employee> checkEmployeeList = new List<Employee>();
            List<string> employeeList = new List<string>();

            getAllEmployeeDuplicate(role,ref newEmployeeList);
            foreach(Employee employee in newEmployeeList)
            {
                if (!checkEmployeeList.Contains(employee))
                {
                    checkEmployeeList.Add(employee);
                }
            }
            foreach(Employee employee in checkEmployeeList)
            {
                employeeList.Add(employee.EmployeeName);
            }
            return employeeList;
        }// end of getAllReportingOfficer
        public void getReportingOfficerTreeNode(string role,string name, ref EmployeeTreeNode employee)
        {
            if(this.Employee.Role.RoleId.Equals(role) && this.Employee.EmployeeName.Equals(name))
            {
                employee = this;
            }
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Role.RoleId.Equals(role) && this.SubordinateEmployee[i].Employee.EmployeeName.Equals(name))
                {
                    employee = this.SubordinateEmployee[i];
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].getReportingOfficerTreeNode(role, name, ref employee);
                }
            }
        }// end of getReportingOfficerTreeNode
        public void checkHaveEmployeeForRole(string role, ref bool check)
        {
            if (this.Employee != null && this.Employee.Role.RoleId.Equals(role))
            {
                check = true;
            }
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.Role.RoleId.Equals(role))
                {
                    check = true;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].checkHaveEmployeeForRole(role, ref check);
                }
            }
        }// end of checkHaveEmployeeForRole
        public void setAllEmployeeTreeNodeText()
        {
            
            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
            employeeList.Add(this);

            this.getAllEmployee(ref employeeList);

            foreach (EmployeeTreeNode employeeTreeNode in employeeList)
            {
                List <EmployeeTreeNode> list = new List <EmployeeTreeNode>();
                for(int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].Employee.EmployeeId.Equals(employeeTreeNode.Employee.EmployeeId)){
                        list.Add(employeeList[i]);
                    }
                }
                if (list.Count > 1)
                {
                    string text = "";
                    if (list.Count != 0)
                    {
                        text = list[0].Employee.EmployeeName;
                    }

                    // get all the roles
                    foreach (EmployeeTreeNode employeeTreeNode2 in list)
                    {
                        if (text.Equals(employeeTreeNode2.Employee.EmployeeName))
                            text += " - " + employeeTreeNode2.Employee.Role.RoleName;
                        else
                            text += ", " + employeeTreeNode2.Employee.Role.RoleName;
                    }
                    //get salary
                    employeeTreeNode.Text = text + " (S$" + employeeTreeNode.Employee.Salary + ")";
                    
                }
                // if text is not set and 
                else if(list[0].Text.Equals("") || list[0].Text == null)
                {
                    list[0].setEmployeeTreeNodeText();
                }
            }// end of foreach

        }// end of setAllEmployeeTreeNodeText
        public void setEmployeeTreeNodeText(string employeeId)
        {
            List<EmployeeTreeNode> employeeList = new List<EmployeeTreeNode>();
            if (this.Employee.EmployeeId.Equals(employeeId))
            {
                employeeList.Add(this);
            }
            getSameEmployeeRolesById(employeeId, ref employeeList);
            if(employeeList.Count > 1)
            {

                string text = "";
                if(employeeList.Count != 0)
                {
                    text = employeeList[0].Employee.EmployeeName;
                }
                foreach(EmployeeTreeNode employeeTreeNode in employeeList)
                {
                    if(text.Equals(employeeTreeNode.Employee.EmployeeName))
                        text += " - "+employeeTreeNode.Employee.Role.RoleName;
                    else
                        text += ", " + employeeTreeNode.Employee.Role.RoleName;
                }

                foreach(EmployeeTreeNode employeeTreeNode in employeeList)
                {
                    employeeTreeNode.Text = text +" (S$"+employeeTreeNode.Employee.Salary+")";
                }
            }
            else if(employeeList.Count == 1)
            {
                employeeList[0].setEmployeeTreeNodeText();
            }
        }// end of setEmployeeTreeNodeText
        public void setEmployeeTreeNodeText()
        {
            this.Text = this.Employee.EmployeeName + " - " + this.Employee.Role.RoleName + " (S$" + this.Employee.Salary + ")";
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
        public void RemoveEmployee(string employeeId, string roleId)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(employeeId) && this.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleId))
                {
                    this.Nodes.Remove(this.SubordinateEmployee[i]);
                    this.SubordinateEmployee.Remove(this.SubordinateEmployee[i]);
                    return;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].RemoveEmployee(employeeId, roleId);
                }
            }
        }//end of Remove Employee
        public void RemoveEmployeeByIdAndRoleId(string employeeId, string roleId)
        {
            for (int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if (this.SubordinateEmployee[i].Employee.EmployeeId.Equals(employeeId) && this.SubordinateEmployee[i].Employee.Role.RoleId.Equals(roleId))
                {
                    this.Nodes.Remove(this.SubordinateEmployee[i]);
                    this.SubordinateEmployee.Remove(this.SubordinateEmployee[i]);
                    return;
                }
                if (this.SubordinateEmployee.Count != 0 && i < this.SubordinateEmployee.Count)
                {
                    this.SubordinateEmployee[i].RemoveEmployeeByIdAndRoleId(employeeId, roleId);
                }
            }
        }//end of Remove Employee
        public override object Clone()
        {
            EmployeeTreeNode clone = (EmployeeTreeNode)base.Clone();
            clone.Employee = this.Employee;
            clone.TopEmployee = this.TopEmployee;
            clone.SubordinateEmployee = this.SubordinateEmployee;

            return clone;
        }// end of overriding Clone
        public void RebuildTreeNodes()
        {
            this.setAllEmployeeTreeNodeText();
            if (this.SubordinateEmployee.Count > 0)
            {
                for (int i = 0; i < this.SubordinateEmployee.Count; i++)
                {
                    this.Nodes.Add(this.SubordinateEmployee[i]);
                    this.SubordinateEmployee[i].TopEmployee = this;
                    this.SubordinateEmployee[i].RebuildTreeNodes();
                }
            }
        }//End of RebuildTreeNodes

        public void checkSalarywithSubordinate(ref bool check, double salary)
        {
            for(int i = 0; i < this.SubordinateEmployee.Count; i++)
            {
                if(salary < this.SubordinateEmployee[i].Employee.Salary)
                {
                    check = false;
                    return;
                }
            }
        }
        // End of Functions -----------------------------------------------------------------------------------------------

        // File IO Functions ----------------------------------------------------------------------------------------------

        public void SaveToFileBinary()
        {
            try
            {
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\EmployeeTreeNode.dat";
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);

                bf.Serialize(stream, this);
                stream.Close();

                MessageBox.Show("Data is added to employee file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //End of SaveToFileBinary
        public EmployeeTreeNode LoadFromFileBinary()
        {
            try
            {
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\EmployeeTreeNode.dat";
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                EmployeeTreeNode root = null;
                if (stream.Length != 0)
                {
                    root = (EmployeeTreeNode)bf.Deserialize(stream);
                }
                stream.Close();

                return root;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Unable to find file.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }//end of ReadFromFileBinary

        // [ SERIALIZE ]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add the required data to file
            info.AddValue("Employee", _employee);
            info.AddValue("SubordinateEmployee", _subordinateEmployee);
            info.AddValue("TopEmployee", _topEmployee);

        }//end of GetObjectData [ SERIALIZE ]

        // [DESERIALIZE]
        protected EmployeeTreeNode(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            this.Employee = (Employee)info.GetValue("Employee", typeof(Employee));
            this.TopEmployee = (EmployeeTreeNode)info.GetValue("TopEmployee", typeof(EmployeeTreeNode));
            this.SubordinateEmployee = (List<EmployeeTreeNode>)info.GetValue("SubordinateEmployee", typeof(List<EmployeeTreeNode>));

        }//end of EmployeeTreeNode [ DESERIALIZE ]

        // End Of File IO Functions ---------------------------------------------------------------------------------------
    }
}
