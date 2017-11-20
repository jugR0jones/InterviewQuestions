using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.Implementations
{
    class Numbers
    {

        public static int MissingInRange(int[] range)
        {
            for(int i=0; i < range.Length-1; i++)
            {
                int value = range[i] ^ range[i + 1];
                if(value % 2 == 0)
                {
                    return range[i] + 1;
                }
            }

            return -1;
        }
    }
}
