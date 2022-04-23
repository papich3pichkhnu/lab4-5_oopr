using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal sealed class Student : Person
    {
        public Faculty? Faculty { get; set; } = null;
        public AssociateProfessor? Mentor { get; set; } = null;
        public Student() : this("Herringhton", "Billy", "Glen")
        {

        }
        public Student(string _lName, string _fName, string _mName) : this(_lName, _fName, _mName, 18, 170, "Brown", "Black", "Male")
        {

        }
        public Student(string _lName, string _fName, string _mName, int _age, int _height, string _coe, string _coh, string _sex) :
            base(_lName, _fName, _mName, _age, _height, _coe, _coh, _sex)
        {

        }
        public override string selfDescribe()
        {
            return "I am student " + FullName;
        }

    }
}
