/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   BinarySearch.cs
 Description    :   Class implements Binary Search Algorithm.           
*/
using StudGradPro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Algorithms
{
    /// <summary>
    /// Class implements binary search algorithm
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// Perform Binary Search by FirstName
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="item">The item.</param>
        /// <returns>Returns Student.</returns>
        public IStudent[] SearchByFirstName(IStudent[] students, string item)
        {
            int n = students.Length - 1;
            int lowerbound = 0;
            int upperbound = n - 1;
            int mid = (lowerbound + upperbound) / 2;
            int ctr = 1;
            while ((string.Compare(item, students[mid].FirstName) != 0) && (lowerbound <= upperbound))
            {
                if (string.Compare(item, students[mid].FirstName) > 0)
                    lowerbound = mid + 1;
                else
                    upperbound = mid - 1;
                mid = (lowerbound + upperbound) / 2;
                ctr++;
            }
            if (string.Compare(item, students[mid].FirstName) == 0)
            {
                if (students is Student[])
                {
                    return new Student[1] { students[mid] as Student };
                }
                else
                {
                    return new StudentByCourse[1] { students[mid] as StudentByCourse };
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Searches the last name of the by.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="item">The item.</param>
        /// <returns>Returns Student.</returns>
        public IStudent[] SearchByLastName(IStudent[] students, string item)
        {
            int n = students.Length - 1;
            int lowerbound = 0;
            int upperbound = n - 1;
            int mid = (lowerbound + upperbound) / 2;
            int ctr = 1;
            while ((string.Compare(item, students[mid].LastName) != 0) && (lowerbound <= upperbound))
            {
                if (string.Compare(item, students[mid].LastName) > 0)
                    lowerbound = mid + 1;
                else
                    upperbound = mid - 1;
                mid = (lowerbound + upperbound) / 2;
                ctr++;
            }
            if (string.Compare(item, students[mid].LastName) == 0)
            {
                if (students is Student[])
                {
                    return new Student[1] { students[mid] as Student };
                }
                else
                {
                    return new StudentByCourse[1] { students[mid] as StudentByCourse };
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Searches the by status.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="item">The item.</param>
        /// <returns>Returns Student.</returns>
        public IStudent[] SearchByStatus(IStudent[] students, string item)
        {
            int n = students.Length - 1;
            int lowerbound = 0;
            int upperbound = n - 1;
            int mid = (lowerbound + upperbound) / 2;
            int ctr = 1;
            while ((string.Compare(item, students[mid].Status) != 0) && (lowerbound <= upperbound))
            {
                if (string.Compare(item, students[mid].Status) > 0)
                    lowerbound = mid + 1;
                else
                    upperbound = mid - 1;
                mid = (lowerbound + upperbound) / 2;
                ctr++;
            }
            if (string.Compare(item, students[mid].Status) == 0)
            {
                if (students is Student[])
                {
                    return new Student[1] { students[mid] as Student };
                }
                else
                {
                    return new StudentByCourse[1] { students[mid] as StudentByCourse };
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns Student details within the specific Grade range
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>Returns Student details</returns>
        public List<StudentByCourse> SearchRange(StudentByCourse[] students, int from, int to)
        {
            int startIndex = SearchNearest(from, students, true);

            int stopIndex = SearchNearest(to, students, false);

            List<StudentByCourse> res = new List<StudentByCourse>();

            if(stopIndex - startIndex <= 0)
            {
                return res;
            }

            for (int i = startIndex; i <= stopIndex; i++)
            {
                res.Add(students[i]);
            }
            return res;
        }

        /// <summary>
        /// Perform Binary Search to find the location of exact match or the nearest location
        /// Eg 1. Students.TotalGrade = { 78, 85, 89, 90, 91 } & isFromValue is TRUE, (from) value is 80, Method returns location as 1
        /// Eg 2. Students.TotalGrade = { 78, 85, 89, 90, 91 } & isFromValue is FALSE, (from) value is 88, Method returns location as 2
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="students">The students.</param>
        /// <param name="isFromValue">if set to <c>true</c> [is from value].</param>
        /// <returns></returns>
        private int SearchNearest(int value, StudentByCourse[] students, bool isFromValue)
        {
            if (value < students[0].TotalGrade)
            {
                return 0;
            }
            if (value > students[students.Length - 1].TotalGrade)
            {
                return students.Length - 1;
            }

            int low = 0;
            int high = students.Length - 1;

            while (low <= high)
            {
                int mid = (high + low) / 2;

                if (value < students[mid].TotalGrade)
                {
                    high = mid - 1;
                }
                else if (value > students[mid].TotalGrade)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            if (isFromValue)
            {
                return low;
            }
            else
            {
                return high;
            }
        }

    }
}
