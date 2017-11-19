using InterviewQuestions.Data_Structures;
using System;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "Happiness";

            Console.WriteLine(" Word Functions");
            Console.WriteLine("================");
            Console.WriteLine("Original word  : " + word);
            Console.WriteLine("Manual Reversal: " + String.ManualReverseCharacters(word));
            Console.WriteLine("Array Reversal : " + String.ArrayReverseCharacters(word));
            Console.WriteLine("LINQ Reversal  : " + String.LINQReverseCharacters(word));

            string sentence = "This is happiness";
            Console.WriteLine();
            Console.WriteLine(" String Functions");
            Console.WriteLine("==================");
            Console.WriteLine("Original String   : " + sentence);
            Console.WriteLine("Substring Reversal: " + String.ReverseWordOrderWithSubstring(sentence));
            Console.WriteLine("Manual Reversal   : " + String.ReverseWordOrderManually(sentence));
            Console.WriteLine("Array Reversal    : " + String.ReverseWordOrderByArray(sentence));
            Console.WriteLine("LINQ Reversal     : " + String.ReverseWordOrderByLINQ(sentence));

            string substring1 = "ABCDCBA";
            string substring2 = "DCBAABC";
            Console.WriteLine();
            Console.WriteLine(" Longest Common Substring");
            Console.WriteLine("==========================");
            Console.WriteLine("Substring 1: " + substring1);
            Console.WriteLine("Substring 2: " + substring2);

            Console.WriteLine("Table Method: " + String.LCSLengthUsingATable(substring1, substring2));

            string suffixText = "abakan";
            Console.WriteLine(" Suffix Tree");
            Console.WriteLine("=============");
            Console.WriteLine("Original string: " + suffixText);
            Console.WriteLine("Output from Naive implementation:");

            SuffixTree suffixTree = new SuffixTree(suffixText);
            suffixTree.OutputSuffixes();

            suffixText = "abababa";
            Console.WriteLine();
            Console.WriteLine("Original string: " + suffixText);
            Console.WriteLine("Output from Naive implementation:");
            suffixTree = new SuffixTree(suffixText);
            suffixTree.OutputSuffixes();
            Console.WriteLine("Longest repeating substring: " + suffixTree.LongestRepeatingSubstring());

            Console.WriteLine();
            Console.WriteLine("Longest Common Substring between:");
            substring1 = "xabxa";
            substring2 = "babxba";
            suffixText = substring1 + "#" + substring2 + "$";
            Console.WriteLine("Output from Naive implementation:");
            suffixTree = new SuffixTree(suffixText);
            suffixTree.OutputSuffixes();
            Console.WriteLine("Longest repeating substring: " + suffixTree.LongestRepeatingSubstring());

            Console.WriteLine();
            substring1 = "abcdxyz";
            substring2 = "xyzabcd";
            suffixText = substring1 + "#" + substring2 + "$";
            Console.WriteLine("Output from Naive implementation:");
            suffixTree = new SuffixTree(suffixText);
            suffixTree.OutputSuffixes();
            Console.WriteLine("Longest repeating substring: " + suffixTree.LongestRepeatingSubstring());

            Console.WriteLine();
            Console.WriteLine(" Array Based Stack");
            Console.WriteLine("===================");
            ArrayBackedStack arrayBackedStack = new ArrayBackedStack(10);
            Console.WriteLine("Is Empty: " + (arrayBackedStack.Empty() ? "Yes" : "No"));
            string stackItem1 = "First";
            string stackItem2 = "Second";
            string stackItem3 = "Third";

            arrayBackedStack.Push(stackItem1);
            arrayBackedStack.Push(stackItem2);
            arrayBackedStack.Push(stackItem1);
            arrayBackedStack.Push(stackItem3);
            arrayBackedStack.Push(stackItem1);
            arrayBackedStack.Push(stackItem2);
            arrayBackedStack.Push(stackItem1);
            arrayBackedStack.Push(stackItem2);
            arrayBackedStack.Push(stackItem1);
            arrayBackedStack.Push(stackItem2);
            arrayBackedStack.Push(stackItem1);
            arrayBackedStack.Push(stackItem2);

            Console.WriteLine("Full: " + (arrayBackedStack.Full() ? "YES" : "NO"));
            Console.WriteLine(arrayBackedStack);
            string poppedItem1 = (string)arrayBackedStack.Pop();
            Console.WriteLine("Popped: " + poppedItem1);
            Console.WriteLine(arrayBackedStack);
            string peekedItem1 = (string)arrayBackedStack.Peek();
            Console.WriteLine("Peeked: " + peekedItem1);
            Console.WriteLine(arrayBackedStack);
            Console.WriteLine("Full: " + (arrayBackedStack.Full() ? "YES" : "NO"));


            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
        }
    }
}
