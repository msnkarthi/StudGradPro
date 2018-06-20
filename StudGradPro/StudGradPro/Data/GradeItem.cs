using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    public class GradeItem
    {
        public int Id { set; get; }
        public int CourseId { set; get; }
        public string Item { set; get; }
        public double WeightPerc { set; get; }
        public double Grade { set; get; }
        public string Feedback { set; get; }
    }
}
