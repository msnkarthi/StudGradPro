/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Grade.cs
 Description    :   Defines Grade Type
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Defines Grade Type
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public double Scale { private set; get; }

        /// <summary>
        /// Gets or sets the letter grade.
        /// </summary>
        /// <value>
        /// The letter grade.
        /// </value>
        public string LetterGrade { private set; get; }

        /// <summary>
        /// Gets or sets the total grade.
        /// </summary>
        /// <value>
        /// The total grade.
        /// </value>
        public double TotalGrade { private set; get; }

        /*
        A+      97-100      4.0
        A       93-96       4.0
        A-      90-92       3.7
        B+      87-89       3.3
        B       83-86       3.0
        B-      80-82       2.7
        C+      77-79       2.3
        C       73-76       2.0
        C-      70-72       1.7
        D+      67-69       1.3
        D       65-66       1.0
        F     Below 65    0.0 
        */

        /// <summary>
        /// Initializes a new instance of the <see cref="Grade"/> class.
        /// </summary>
        /// <param name="totalGrade">The total grade.</param>
        public Grade(double totalGrade)
        {
            TotalGrade = totalGrade;
            if (totalGrade >= 97 && totalGrade <= 100)
            {
                Scale = 4.0;
                LetterGrade = "A+";// LetterGrade.APlus;
            }
            else if (totalGrade >= 93 && totalGrade < 97)
            {
                Scale = 4.0;
                LetterGrade = "A";// LetterGrade.A;
            }
            else if (totalGrade >= 90 && totalGrade < 93)
            {
                Scale = 3.7;
                LetterGrade = "A-";// LetterGrade.AMinus;
            }
            else if (totalGrade >= 87 && totalGrade < 90)
            {
                Scale = 3.3;
                LetterGrade = "B+";// LetterGrade.BPlus;
            }
            else if (totalGrade >= 83 && totalGrade < 87)
            {
                Scale = 3.0;
                LetterGrade = "B";// LetterGrade.B;
            }
            else if (totalGrade >= 80 && totalGrade < 83)
            {
                Scale = 2.7;
                LetterGrade = "B-";// LetterGrade.BMinus;
            }
            else if (totalGrade >= 77 && totalGrade < 80)
            {
                Scale = 2.3;
                LetterGrade = "C+";// LetterGrade.CPlus;
            }
            else if (totalGrade >= 73 && totalGrade < 77)
            {
                Scale = 2.0;
                LetterGrade = "C";// LetterGrade.C;
            }
            else if (totalGrade >= 70 && totalGrade < 73)
            {
                Scale = 1.7;
                LetterGrade = "C-";// LetterGrade.CMinus;
            }
            else if (totalGrade >= 67 && totalGrade < 70)
            {
                Scale = 1.3;
                LetterGrade = "D+";// LetterGrade.DPlus;
            }
            else if (totalGrade >= 65 && totalGrade < 67)
            {
                Scale = 1.0;
                LetterGrade = "D";// LetterGrade.D;
            }
            else
            {
                Scale = 0.0;
                LetterGrade = "F";// LetterGrade.F;
            }
        }
    }

    /// <summary>
    /// Enums for Letter Grade.
    /// </summary>
    public enum LetterGrade
    {
        APlus,
        A,
        AMinus,
        BPlus,
        B,
        BMinus,
        CPlus,
        C,
        CMinus,
        DPlus,
        D,
        F,
    }
}
