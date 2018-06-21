/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Quicksort.cs
 Description    :   Class implements Quick Sort Algorithm.           
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
    /// Implements Quicksort Algorithm.
    /// </summary>
    public class Quicksort
    {
        /// <summary>
        /// Performs Quick sort by First Name.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>Returns Sorted Students.</returns>
        public IStudent[] quickSortByFirstName(IStudent[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].FirstName;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    while (students[i].FirstName.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }

                    while (students[j].FirstName.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortByFirstName(students, start, j - 1);
                // sort right partition
                quickSortByFirstName(students, j + 1, end);
            }
            return students;
        }

        /// <summary>
        /// Performs Quick sort by Student Id.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>Returns Sorted Students.</returns>
        public IStudent[] quickSortById(IStudent[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                int pivot = students[i].Id;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    while (students[i].Id <= pivot && i < end && j > i)
                    {
                        i++;
                    }

                    while (students[j].Id >= pivot && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortById(students, start, j - 1);
                // sort right partition
                quickSortById(students, j + 1, end);
            }
            return students;
        }

        /// <summary>
        /// Performs Quick sort by status.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>Returns Sorted Students.</returns>
        public IStudent[] quickSortByStatus(IStudent[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].Status;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    while (students[i].Status.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }

                    while (students[j].Status.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortByStatus(students, start, j - 1);
                // sort right partition
                quickSortByStatus(students, j + 1, end);
            }
            return students;
        }

        /// <summary>
        /// Performs Quick sort the last name.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>Returns Sorted Students.</returns>
        public IStudent[] quickSortByLastName(IStudent[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].LastName;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    while (students[i].LastName.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }

                    while (students[j].LastName.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortByLastName(students, start, j - 1);
                // sort right partition
                quickSortByLastName(students, j + 1, end);
            }

            return students;
        }

        /// <summary>
        /// Swaps the specified students.
        /// </summary>
        /// <param name="students">The students.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        private static void Swap(IStudent[] students, int i, int j)
        {
            var temp = students[i];
            students[i] = students[j];
            students[j] = temp;
        }
    }
}
