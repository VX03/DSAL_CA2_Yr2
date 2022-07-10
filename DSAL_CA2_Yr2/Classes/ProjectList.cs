using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace DSAL_CA2_Yr2.Classes
{
    [Serializable]
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
        public void SaveToFileBinary()
        {
            try
            {
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ProjectList.dat";
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);

                bf.Serialize(stream, this);
                stream.Close();

                MessageBox.Show("Data is added to Project file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //End of SaveToFileBinary
        public ProjectList LoadFromFileBinary()
        {
            try
            {
                string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ProjectList.dat";
                Stream stream = new FileStream(@filepath, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                ProjectList root = null;
                if (stream.Length != 0)
                {
                    root = (ProjectList)bf.Deserialize(stream);
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
    }
}
