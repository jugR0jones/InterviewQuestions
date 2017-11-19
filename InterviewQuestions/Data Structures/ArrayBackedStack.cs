using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.Data_Structures
{
    class ArrayBackedStack: IStack
    {
        private object[] _stack;
        private int _stackPointer;
        private int _maximumCount;

        #region Constructors

        public ArrayBackedStack() : this(10)
        {
        }

        public ArrayBackedStack(int size)
        {
            _maximumCount = size;
            this.Clear();
        }

        #endregion

        // Clear all items from the stack
        public void Clear()
        {
            _stack = new object[_maximumCount];
            _stackPointer = 0;
        }

        /// <summary>
        /// Is the stack empty
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            int count = _stack.Count(x => x != null);

            return count == 0;
        }

        // Is the stack full
        public bool Full()
        {
            int count = _stack.Count(x => x != null);

            return count == _maximumCount;
        }

        public void Push(object obj)
        {
            if(_stackPointer < _stack.Length)
            {
                _stack[_stackPointer] = obj;
                _stackPointer++;
            } else
            {
                Console.WriteLine("Cannot push object to stack. Stack is full!");
            }
        }

        public object Pop()
        {
            if(_stackPointer - 1 >= 0)
            {
                _stackPointer--;
                object poppedObject = _stack[_stackPointer];
                _stack[_stackPointer] = null;

                return poppedObject;
            }

            return null;
        }

        public object Peek()
        {
            if(_stackPointer - 1 >= 0)
            {
                return _stack[_stackPointer-1];
            }

            return null;
        }

        public override string ToString()
        {
            string output = (string)_stack.Aggregate((a, b) => a + ", " + b);
            
            return output;
        }
    }
}
