using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.Data_Structures
{
    interface IStack
    {
        // Clear all items from the stack
        void Clear();

        /// <summary>
        /// Is the stack empty
        /// </summary>
        /// <returns></returns>
        bool Empty();

        /// <summary>
        /// Is the stack full
        /// </summary>
        /// <returns></returns>
        bool Full();

        /// <summary>
        /// Add an item to the top of the stack
        /// </summary>
        /// <param name="obj"></param>
        void Push(object obj);

        /// <summary>
        /// Return the item from the top of the stack
        /// </summary>
        /// <returns></returns>
        object Pop();

        /// <summary>
        /// Retrieve the topmost item from the stack without removing it.
        /// </summary>
        /// <returns></returns>
        object Peek();
    }
}
