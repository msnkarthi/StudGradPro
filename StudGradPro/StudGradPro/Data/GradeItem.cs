/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   GradeItem.cs
 Description    :   Defines Single Task with its grade in a course (eg. Assignment, Project, Forum, etc)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Defines Single Task with its grade in a course
    /// </summary>
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
