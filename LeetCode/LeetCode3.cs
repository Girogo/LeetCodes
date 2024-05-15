using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LeetCode3 : ILeetCode
    {
        public string Name => "Longest Substring Without Repeating Characters";

        public string Description => @"Given a string s, find the length of the longest
substring
without repeating characters.

Example 1:

Input: s = ""abcabcbb""
Output: 3
Explanation: The answer is ""abc"", with the length of 3.

Example 2:

Input: s = ""bbbbb""
Output: 1
Explanation: The answer is ""b"", with the length of 1.

Example 3:

Input: s = ""pwwkew""
Output: 3
Explanation: The answer is ""wke"", with the length of 3.
Notice that the answer must be a substring, ""pwke"" is a subsequence and not a substring.

Constraints:

    0 <= s.length <= 5 * 104
    s consists of English letters, digits, symbols and spaces.

";


        public void Run()
        {
            string s = "abcabcbb";
            int length = LengthOfLongestSubstring(s);
            var x = 0;
        }

        public int LengthOfLongestSubstring(string s)
        {
            var charHash = new HashSet<char>();
            int longestSubstring = 0;
            int rightPosition = 0;
            int leftPosition = 0;
           
            while (rightPosition < s.Length)
            {
                if (!charHash.Contains(s[rightPosition]))
                {
                    charHash.Add(s[rightPosition]);
                    longestSubstring = Math.Max(longestSubstring, rightPosition - leftPosition + 1);
                    rightPosition++;
                }
                else
                {
                    charHash.Remove(s[leftPosition]);
                    leftPosition++;
                }
            }

            return longestSubstring;
        }
    }
}
