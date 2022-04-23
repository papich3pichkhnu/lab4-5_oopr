using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal sealed class Department
    {
        public Faculty? Faculty { get; set; }
        public string Name { get; set; } = "Department";
        public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public AssociateProfessor? HeadOfDepartment { get; set; }
        public Department() : this("Department")
        {

        }
        public Department(string _Name)
        {
            Name = _Name;
        }
        public bool enrollLecturer(Lecturer lecturer)
        {
            if (lecturer.Department == null)
            {
                Lecturers.Add(lecturer);
                lecturer.Department = this;
                return true;
            }
            return false;
        }
        public bool deductLecturer(Lecturer lecturer)
        {
            Lecturer? findLecturer = Lecturers.Find(x => x.Equals(lecturer));
            if (findLecturer == null)
            {
                return false;
            }
            else
            {
                Lecturers.Remove(findLecturer);
                findLecturer.Department = null;
                return true;
            }
        }
    }
}
