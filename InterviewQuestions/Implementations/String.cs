using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions
{
    public class String
    {

        #region Character Reversal

        public static string ManualReverseCharacters(string input)
        {
            string output = "";
            for(int i=input.Length-1; i >= 0; i--)
            {
                output += input[i];
            }

            return output;
        }

        public static string ArrayReverseCharacters(string input)
        {
            char[] charArray = input.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }

        public static string LINQReverseCharacters(string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }

        #endregion

        #region Word Order

        public static string ReverseWordOrderWithSubstring(string input)
        {
            string word;
            int lastSpace = 0;
            string output = "";

            int i;
            for(i=0; i < input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    word = input.Substring(lastSpace, i - lastSpace);
                    output = input[i] + word + output;
                    lastSpace = i+1;
                }
            }

            word = input.Substring(lastSpace);
            output = word + output;

            return output;
        }

        public static string ReverseWordOrderManually(string input)
        {
            string word = "";
            string output = "";
            
            int i;
            for(i=0; i < input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    output = input[i] + word + output;
                    word = "";
                } else
                {
                    word += input[i];
                }
            }

            output = word + output;


            return output;
        }

        public static string ReverseWordOrderByArray(string input)
        {
            string[] stringArray = input.Split(" ");
            Array.Reverse(stringArray);

            return string.Join(" ", stringArray);
        }

        public static string ReverseWordOrderByLINQ(string input)
        {
            return input.Split(" ").Reverse().Aggregate((a, b) => a + " " + b);
        }

        #endregion

        #region Longest Common Substring

        public static int LCSLengthUsingATable(string str1, string str2)
        {
            // If at least one of the strings is empty, then there is no common substring.
            if(string.IsNullOrEmpty(str1)
                || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            // Construct a table, the row will represent the characters from the first string,
            //  while the columns will represent the characters from the second string.
            int[,] table = new int[str1.Length, str2.Length];
            int maximumLength = 0;

            for(int i=0; i < str1.Length; i++)
            {
                for(int j=0; j < str2.Length; j++)
                {
                    if(str1[i] != str2[j])
                    {
                        // Because the strings are not equal, they cannot be part of the same substring.
                        table[i, j] = 0;
                    } else
                    {
                        if(i == 0 || j == 0)
                        {
                            // At the edges, the values are increased at most once.
                            table[i, j] = 1;
                        } else
                        {
                            // The table generates numbers that represent the length of the longest common string.
                            // The first time two equal letters are found, the length of the substring is set to 1.
                            // If the next two letters are found, then the common substring contains two letters, so its
                            //  length is now 2. So we add 1 to the value of the previous character's length, found diagonally
                            //  one to the left and one up.
                            table[i, j] = 1 + table[i - 1, j - 1];
                        }
                    }

                    if(table[i, j] > maximumLength)
                    {
                        maximumLength = table[i, j];
                    }
                }
            }

            return maximumLength;
        }

        #endregion
    }
}
