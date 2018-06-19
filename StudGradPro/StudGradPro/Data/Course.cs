using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro
{
    public class Course
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public GradeItem[] Plan { get; set; }
        public string ProfessorFullName { get; set; }
        public double FinalGrade { set; get; }

        public override string ToString()
        {
            return string.Format("Professor: {0}, Course: {1}", ProfessorFullName, Name);
        }
    }
}
