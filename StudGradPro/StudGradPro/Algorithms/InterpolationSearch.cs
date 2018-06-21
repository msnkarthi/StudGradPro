/*
 Author Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Interpolation.cs
 Description    :   Class implements Interpolation Search Algorithm.           
*/
using StudGradPro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Algorithms
{
    public  class InterpolationSearch
    {
        /// <summary>
        /// Method performs Interpolation Search of given sorted array
        /// </summary>
        /// <param name="sortedStudents"></param>
        /// <param name="x"></param>
        /// <returns>location</returns>
        public IStudent[] SearchById(IStudent[] sortedStudents, int x)
        {
            int low, high, mid;
            low = 0;
            high = sortedStudents.Length - 1;
            int location = -1;
            int denominator;

            if(sortedStudents[low].Id <= x && sortedStudents[high].Id >= x)
            {
                while (low <= high && location == -1)
                {
                    denominator = sortedStudents[high].Id - sortedStudents[low].Id;
                    if (denominator == 0)
                    {
                        mid = low;
                    }
                    else
                    {
                        //find the mid using probe position formula based on the values at low and high
                        mid = low + ((x - sortedStudents[low].Id) * (high - low)) / denominator;
                    }

                    //Determine location or high or low based on value at mid and search key
                    if (x == sortedStudents[mid].Id)
                    {
                        location = mid;
                    }
                    else if (x < sortedStudents[mid].Id)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }

                    //Console.WriteLine("Iteration {0}; Mid - {1}, Low - {2}, High - {3}", ++count, mid, low, high);
                }
            }

            if(location < 0)
            {
                return null;
            }

            if (sortedStudents is Student[])
            {
                return new Student[1] { sortedStudents[location] as Student };
            }
            else
            {
                return new StudentByCourse[1] { sortedStudents[location] as StudentByCourse };
            }

            //return new IStudent[1] { sortedStudents[location] };
        }
    }
}
