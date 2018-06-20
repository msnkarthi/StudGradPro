using StudGradPro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Algorithms
{
    public class BinarySearch
    {

        public Student Search(Student[] students, string item)
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
                return students[mid];
            else
                return null;
        }//end of binary search method
    }
}
