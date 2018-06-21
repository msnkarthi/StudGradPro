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
    /// Quicksort Implementation
    /// </summary>
    public class Quicksort
    {
        public Student[] quickSortByFirstName(Student[] students, int start, int end)
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
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].FirstName.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].FirstName.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortByFirstName(students, start, j - 1);
                // sort right partition
                quickSortByFirstName(students, j + 1, end);
            }
            return students;
        }

        public Student[] quickSortById(Student[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].Id.ToString();
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].Id.ToString().CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].Id.ToString().CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortById(students, start, j - 1);
                // sort right partition
                quickSortById(students, j + 1, end);
            }
            return students;
        }

        public Student[] quickSortByStatus(Student[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].Status;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].Status.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].Status.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortByStatus(students, start, j - 1);
                // sort right partition
                quickSortByStatus(students, j + 1, end);
            }
            return students;
        }

        public Student[] quickSortByLastName(Student[] students, int start, int end)
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
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].LastName.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].LastName.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        Swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                Swap(students, start, j);
                // sort left partition
                quickSortByLastName(students, start, j - 1);
                // sort right partition
                quickSortByLastName(students, j + 1, end);
            }

            return students;
        }

        private static void Swap(Student[] students, int i, int j)
        {
            var temp = students[i];
            students[i] = students[j];
            students[j] = temp;
        }
    }
}
