using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DSAL_CA2_Yr2.Classes
{
    [Serializable]
    public class RoleTreeNode : TreeNode, ISerializable
    {
        private Role _role = new Role();
        private RoleTreeNode _topRole = null;
        private List<RoleTreeNode> _subordinateRoles;

        public RoleTreeNode()
        {
            _subordinateRoles = new List<RoleTreeNode>();
        }
        public RoleTreeNode(Role role)
        {
            _subordinateRoles = new List<RoleTreeNode>();
            _role = role;

            this.Text = _role.RoleName;
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public RoleTreeNode TopRole
        {
            get { return _topRole; }
            set { _topRole = value; }
        }
        public List<RoleTreeNode> SubordinateRoles
        {
            get { return _subordinateRoles; }
            set { _subordinateRoles = value; }
        }

        // Update / Add / Remove ------------------------------------------------------------------------------------------
        public void AddRoleSubordinate(RoleTreeNode roleNode)
        {
            roleNode.TopRole = this;
            _subordinateRoles.Add(roleNode);
            this.Nodes.Add(roleNode);
        }// End of AddRoleSubordinate
        public void UpdateRole(string roleName, bool projectleader)
        {
            this.Text = roleName;
            this.Role.RoleName = roleName;
            this.Role.ProjectLeader = projectleader;
        }//End Of UpdateRole
        public void RemoveRole(string roleId)
        {
            for(int i = 0; i < this.SubordinateRoles.Count; i++)
            {
                if(this.SubordinateRoles[i].Role.RoleId.Equals(roleId))
                { 
                    this.Nodes.Remove(this.SubordinateRoles[i]);
                    this.SubordinateRoles.Remove(this.SubordinateRoles[i]);
                    return;
                }
                if(this.SubordinateRoles.Count != 0 && i < this.SubordinateRoles.Count) 
                {
                    this.SubordinateRoles[i].RemoveRole(roleId);
                }
            }
        }//end of Remove Role

        public void getSubordinateRoleById(string roleId, ref List<RoleTreeNode> roleList)
        {
            if (this.Role.RoleId.Equals(roleId))
            {
                roleList = this.SubordinateRoles;
            }
            for (int i = 0; i <this.SubordinateRoles.Count; i++)
            {
                if (this.SubordinateRoles[i].Role.RoleId.Equals(roleId))
                {
                    roleList = this.SubordinateRoles[i].SubordinateRoles;
                }

                    this.SubordinateRoles[i].getSubordinateRoleById(roleId,ref roleList);
            }
            
        }
        // End of Update / Add / Remove -----------------------------------------------------------------------------------

        // File IO --------------------------------------------------------------------------------------------------------
        public void SaveToFileBinary()
        {
            try
            {
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RoleTreeNode.dat";
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);

                bf.Serialize(stream, this);
                stream.Close();

                MessageBox.Show("Data is added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //End of SaveToFileBinary
        public RoleTreeNode LoadFromFileBinary()
        {
            try
            {
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RoleTreeNode.dat";
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                RoleTreeNode root = null;
                if (stream.Length != 0)
                {
                    root = (RoleTreeNode)bf.Deserialize(stream);
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
                return null ;
            }

        }//end of ReadFromFileBinary

        // [ SERIALIZE ]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //add the required data to file
            info.AddValue("Role", _role);
            info.AddValue("SubordinateRoles", _subordinateRoles);
            info.AddValue("TopRole", _topRole);

        }//end of GetObjectData [ SERIALIZE ]
        // [DESERIALIZE]
        protected RoleTreeNode(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            this.Role = (Role)info.GetValue("Role", typeof(Role));
            this.TopRole = (RoleTreeNode)info.GetValue("TopRole", typeof(RoleTreeNode));
            this.SubordinateRoles = (List<RoleTreeNode>)info.GetValue("SubordinateRoles", typeof(List<RoleTreeNode>));

        }//end of RoleTreeNode [ DESERIALIZE ]

        // End Of File IO -------------------------------------------------------------------------------------------------
        public void RebuildTreeNodes()
        {
            this.Text = this.Role.RoleName;
            if (this.SubordinateRoles.Count > 0)
            {
                int i = 0;
                for (i = 0; i < this.SubordinateRoles.Count; i++)
                {
                    this.Nodes.Add(this.SubordinateRoles[i]);
                    this.SubordinateRoles[i].TopRole = this;
                    this.SubordinateRoles[i].RebuildTreeNodes();
                }
            }

        }//End of RebuildTreeNodes

    }
}
