using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal sealed class Faculty
    {
        private static List<Faculty> faculties = new List<Faculty>();
        public static List<Faculty> getList()
        {
            return faculties;
        }
        public static void addToList(Faculty f)
        {
            faculties.Add(f);
        }

        public int YearOfCreating { get; set; } = 2000;
        public int NumOfSpecs { get; set; } = 10;
        public string TelephoneNumber { get; set; } = "380671234567";
        public string Email { get; set; } = "faculty@gmail.com";
        public string Name { get; set; } = "Faculty";
        public string Abbreviature { get; set; } = "Abbreviature";
        public string Decane { get; set; } = "Decane";
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Department> Departments { get; set; } = new List<Department>();
        public bool enrollStudent(Student student)
        {
            if (student.Faculty == null)
            {
                Students.Add(student);
                student.Faculty = this;
                return true;
            }
            return false;
        }
        public bool deductStudent(Student student)
        {
            Student? findStudent = Students.FirstOrDefault(x => x.Equals(student));
            if (findStudent == null)
            {
                return false;
            }
            else
            {
                Students.Remove(findStudent);
                findStudent.Faculty = null;
                return true;
            }
        }
        public bool addDepartment(Department department)
        {
            if (department.Faculty != null)
            {
                return false;

            }
            Departments.Add(department);
            department.Faculty = this;
            return true;
        }
        public bool deleteDepartment(Department department)
        {
            Department? findDepartment = Departments.Find(x => x.Equals(department));
            if (findDepartment == null)
            {
                return false;
            }
            else
            {
                Departments.Remove(findDepartment);
                findDepartment.Faculty = null;
                return true;
            }
        }
    }
}
