/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Heapsort.cs
 Description    :   Class implements Heap Sort Algorithm.           
*/
using StudGradPro.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Algorithms
{
    /// <summary>
    /// Class Implements the heap sort algorithm
    /// </summary>
    public class Heapsort
    {
        /// <summary>
        /// Sift down helps to maintain heap property 
        /// </summary>
        /// <param name="H"></param>
        /// <param name="i"></param>
        private void Siftdown(Heap H, int i)
        {
            int parent;
            int largerChild;

            StudentByCourse siftKey;
            bool spotFound;

            siftKey = H.SortedStudent[i];

            parent = i;
            spotFound = false;
            while (2 * parent < H.HeapSize && !spotFound)
            {
                if (2 * parent < H.HeapSize - 1 && H.SortedStudent[2 * parent].TotalGrade < H.SortedStudent[2 * parent + 1].TotalGrade) // Compare left child & right child
                {
                    largerChild = 2 * parent + 1; //right is larger
                }
                else
                {
                    largerChild = 2 * parent; // left is larger
                }
                if (siftKey.TotalGrade < H.SortedStudent[largerChild].TotalGrade) // assign to root
                {
                    H.SortedStudent[parent] = H.SortedStudent[largerChild];
                    parent = largerChild;
                }
                else
                {
                    spotFound = true;
                }
            }
            H.SortedStudent[parent] = siftKey;
        }

        /// <summary>
        /// Returns root node & swaps last node; (returned node is considered as sorted) 
        /// </summary>
        /// <param name="H"></param>
        /// <returns></returns>
        StudentByCourse Root(Heap H)
        {
            StudentByCourse keyOut;

            keyOut = H.SortedStudent[0];
            H.SortedStudent[0] = H.SortedStudent[H.HeapSize - 1];
            H.HeapSize = H.HeapSize - 1;
            Siftdown(H, 0);
            return keyOut;
        }

        /// <summary>
        /// Removekey extracts the root to form the sorted array
        /// </summary>
        /// <param name="n"></param>
        /// <param name="H"></param>
        /// <param name="S"></param>
        /// <param name="z"></param>
        private void RemoveKeys(int n, Heap H, StudentByCourse[] S)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                S[i] = Root(H);
            }
        }

        /// <summary>
        /// Helps to heap the non leaf nodes
        /// </summary>
        /// <param name="n"></param>
        /// <param name="H"></param>
        private void MakeHeap(int n, Heap H)
        {
            H.HeapSize = n;
            for (int i = (n / 2) - 1; i >= 0; i--) //Since all leaves are heap, take large index of non-leaf node to 0 inorder to perform heap
            {
                Siftdown(H, i);
            }
        }

        /// <summary>
        /// Sorts the given input
        /// </summary>
        /// <param name="n"></param>
        /// <param name="H"></param>
        public void Sort(int n, Heap H)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            MakeHeap(n, H);
            RemoveKeys(n, H, H.SortedStudent);
            stopWatch.Stop();

            Debug.WriteLine("Heap Execution time is {0} for Array of Length {1}: ", stopWatch.Elapsed, n);
        }
    }

    /// <summary>
    /// The Heap Class.
    /// </summary>
    public class Heap
    {
        /// <summary>
        /// Gets or sets the sorted student.
        /// </summary>
        /// <value>
        /// The sorted student.
        /// </value>
        public StudentByCourse[] SortedStudent { set; get; }
        /// <summary>
        /// Gets the n.
        /// </summary>
        /// <value>
        /// The n.
        /// </value>
        public int n
        {
            get
            {
                return SortedStudent.Length;
            }
        }
        /// <summary>
        /// Gets or sets the size of the heap.
        /// </summary>
        /// <value>
        /// The size of the heap.
        /// </value>
        public int HeapSize { set; get; }
    }
}
