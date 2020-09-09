using System;

namespace Palindrome
{
    class Program
    {

        //Write a program that finds the longest palindromic substring of a given string. Try to be as efficient as possible! eg 1001 == 1001, greek == ee, trial == not a palindrome
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindromicSubstring("1001"));
            Console.WriteLine(LongestPalindromicSubstring("greek"));
            Console.WriteLine(LongestPalindromicSubstring("trial"));
            Console.WriteLine(LongestPalindromicSubstring("babad"));
        }

        static string LongestPalindromicSubstring(string str)
        {

            if (str.Length < 2)
            {
                return "not a palindrome";
            }

                string maxPaliSubstr = "";
                string currentSubstr;
                int maxLen = 0;
                int currentLen = 0;

                for( int i =0; i < str.Length - 1; i++)
                {
                    //find a palindromic substring with odd length, i as mid point
                    currentSubstr = Expand(str, i, i);
                    currentLen = currentSubstr.Length;

                    //get the longest substring at this point
                    if (currentLen > maxLen)
                    {
                        maxPaliSubstr = currentSubstr;
                        maxLen = currentLen;
                    }

                    //find a palindromic substring with even length

                    currentSubstr = Expand(str, i, i + 1);
                    currentLen = currentSubstr.Length;

                    if (currentLen > maxLen)
                    {
                        maxPaliSubstr = currentSubstr;
                        maxLen = currentLen;
                    }
                    
                }

                if(maxPaliSubstr.Length < 2)
            {
                return "not a palindrome";
            }
                return maxPaliSubstr;
            
            

        }

        //function that will get a palindromic substring

        static string Expand(string str, int begin, int end)
        {
            //expand in both directions from the mid point
            while (begin >= 0 && end < str.Length && str[begin] == str[end])
            {
                begin--;
                end++;
            }

            //return the pandromic substring with first index being begin+1 and length of end - begin-1
            return str.Substring(begin+1,end-begin-1);
        }
    }
}
