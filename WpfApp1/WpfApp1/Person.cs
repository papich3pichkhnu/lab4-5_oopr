using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal abstract class Person
    {
        private int _age = 18;
        public int Age { get { return _age; } set { if (value > 0) _age = value; } }
        protected int _height = 170;
        public int Height { get { return _height; } set { if (value > 0) _height = value; } }
        public string ColorOfEyes { get; set; } = "Brown";
        public string ColorOfHair { get; set; } = "Black";
        public string LastName { get; set; } = "Herrighton";
        public string FirstName { get; set; } = "Billy";
        public string MiddleName { get; set; } = "Glen";
        public string Sex { get; set; } = "Male";
        public Person() : this("Herringhton", "Billy", "Glen")
        {

        }
        public Person(string _lName, string _fName, string _mName) : this(_lName, _fName, _mName, 18, 170, "Brown", "Black", "Male")
        {

        }
        public Person(string _lName, string _fName, string _mName, int _age, int _height, string _coe, string _coh, string _sex)

        {
            LastName = _lName; FirstName = _fName; MiddleName = _mName;
            Age = _age; Height = _height;
            ColorOfEyes = _coe; ColorOfHair = _coh;
            Sex = _sex;
        }
        public string FullName { get { return LastName + " " + FirstName + " " + MiddleName; } }
        public abstract string selfDescribe();
    }
}
