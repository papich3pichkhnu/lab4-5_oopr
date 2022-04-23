using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal sealed class Exam
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public SeniorLecturer? Lecturer { get; set; }
        public Discipline? Discipline { get; set; }
        private int _mark = 0;
        public int Mark { get { return _mark; } set { if (value >= 1 && value <= 5) _mark = value; } }
        public DateTime Date { get; set; } = new DateTime(2022, 3, 1);
        public bool IsSigned { get; set; } = false;        
        public Exam() : this(null, null, null)
        {

        }
        public Exam(Student? _s, SeniorLecturer? _l, Discipline? _d)
        {
            Student = _s;
            Lecturer = _l;
            Discipline = _d;
        }

    }
}
