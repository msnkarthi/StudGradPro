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
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { set; get; }

        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>
        /// The course identifier.
        /// </value>
        public int CourseId { set; get; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public string Item { set; get; }

        /// <summary>
        /// Gets or sets the weight perc.
        /// </summary>
        /// <value>
        /// The weight perc.
        /// </value>
        public double WeightPerc { set; get; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public double Grade { set; get; }

        /// <summary>
        /// Gets or sets the feedback.
        /// </summary>
        /// <value>
        /// The feedback.
        /// </value>
        public string Feedback { set; get; }
    }
}
