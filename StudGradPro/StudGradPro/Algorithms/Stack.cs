/*
 Student Name   : Karthikeyan Nagarajan; # 227516
 
 File Name      :   Stack.cs
 Description    :   Stack class implements the functionality of stack - Last In First Out(LIFO).
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
    /// Stack class implements functionality of LIFO system
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// Internal array used to store the data
        /// </summary>
        private IStudent[] stack;

        /// <summary>
        /// Index of the array called as "TOP" - stores the last position of item in the stack.
        /// </summary>
        private int topIndex = -1;

        /// <summary>
        /// Stores the max size of the stack
        /// </summary>
        public int Capacity { get; private set; }

        /// <summary>
        /// Returns TRUE if stack has no values
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return topIndex == -1;
            }
        }

        /// <summary>
        /// Returns TRUE if stack is full
        /// </summary>
        public bool IsFull
        {
            get
            {
                return topIndex == Capacity - 1;
            }
        }

        /// <summary>
        /// Constructor initializes the values of the Stack
        /// </summary>
        /// <param name="capacity"></param>
        public Stack(Type type, int capacity)
        {
            this.Capacity = capacity;
            if(type == typeof(Student))
            {
                stack = new Student[capacity];
            }
            else
            {
                stack = new StudentByCourse[capacity];
            }

            //stack = new int[capacity]; //create and initialize stack with given size
            topIndex = -1; 
        }

        /// <summary>
        /// Pushes/Adds a value to the stack
        /// </summary> 
        /// <param name="value"></param>
        public void Push(IStudent value)
        {
            if (IsFull)
            {
                throw new Exception("Exception. Stack is full.");
            }
            
            stack[++topIndex] = value; //Increase the TOP index by 1 & Assigns value to the stack 
        }

        /// <summary>
        /// Pops/Removes a value from the stack
        /// </summary>
        /// <returns></returns>
        public IStudent Pop()
        {
            if (IsEmpty)
            {
                throw new Exception("Exception. Stack is empty.");
            }

            return stack[topIndex--]; //Return the item stored in the TOP index & decrease the TOP index by 1
        }

        /// <summary>
        /// Gets the value at the TOP of the stack (without deletion)
        /// </summary>
        /// <returns></returns>
        public IStudent Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Exception. Stack is Empty");
            }

            return stack[topIndex];
        }

        
    }
}
