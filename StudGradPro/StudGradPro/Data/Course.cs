/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Course.cs
 Description    :   Defines Course Type           
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Course Type
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { set; get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { set; get; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        /// <value>
        /// The plan.
        /// </value>
        public GradeItem[] Plan { get; set; }

        /// <summary>
        /// Gets or sets the full name of the professor.
        /// </summary>
        /// <value>
        /// The full name of the professor.
        /// </value>
        public string ProfessorFullName { get; set; }

        /// <summary>
        /// Gets or sets the final grade.
        /// </summary>
        /// <value>
        /// The final grade.
        /// </value>
        public double FinalGrade { set; get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Professor: {0}, Course: {1}", ProfessorFullName, Name);
        }
    }
}
