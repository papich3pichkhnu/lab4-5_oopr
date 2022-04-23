using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal sealed class Discipline
    {
        private int _credits = 10;
        public int Credits
        {
            get { return _credits; }
            set { if (value > 0) _credits = value; }
        }

        private int _numberOfHours = 10;
        public int NumberOfHours
        {
            get { return _numberOfHours; }
            set { if (value > 0) _numberOfHours = value; }
        }
        private int _numberOfControlWorks = 2;
        public int NumberOfControlWorks
        {
            get { return _numberOfControlWorks; }
            set { if (value > 0) _numberOfControlWorks = value; }
        }
        public string Name { get; set; } = "Discipline";
        public Department? Department { get; set; }
        public string TypeOfControl { get; set; } = "Exam";
        public Discipline() : this("Discipline", null, "Exam", 10, 10, 3)
        {

        }
        public Discipline(string _n, Department? _d, string _t, int _cr, int _nh, int _ncw)
        {
            Name = _n;
            Department = _d;
            TypeOfControl = _t;
            Credits = _cr;
            NumberOfHours = _nh;
            NumberOfControlWorks = _ncw;
        }

    }
}
