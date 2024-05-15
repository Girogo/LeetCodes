using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LeetCode4 : ILeetCode
    {
        public string Name => "Median of Two Sorted Arrays";

        public string Description => @"Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Constraints:

    nums1.length == m
    nums2.length == n
    0 <= m <= 1000
    0 <= n <= 1000
    1 <= m + n <= 2000
    -106 <= nums1[i], nums2[i] <= 106
";

        public void Run()
        {
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { 3, 4 };
            double median = FindMedianSortedArrays(nums1, nums2);
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = 0;
            int m = 0;

            int[] allNums = new int[nums1.Length + nums2.Length];
            int nextIndex = 0;

            while (n < nums1.Length || m < nums2.Length)
            {
                if (n < nums1.Length && m < nums2.Length)
                {
                    if (nums1[n] < nums2[m])
                    {
                        allNums[nextIndex] = nums1[n];
                        n++;
                    }
                    else
                    {
                        allNums[nextIndex] = nums2[m];
                        m++;
                    }
                }
                else if (n < nums1.Length)
                {
                    allNums[nextIndex] = nums1[n];
                    n++;
                }
                else
                {
                    allNums[nextIndex] = nums2[m];
                    m++;
                }
                nextIndex++;
            }

            if (allNums.Length % 2 == 0)
            {
                var firstIndex = allNums.Length / 2;
                var secondIndex = firstIndex - 1;

                return (double)(allNums[firstIndex] + allNums[secondIndex]) / 2;
            }
            else
            {
                var index = allNums.Length / 2;
                return allNums[index];
            }
        }
    }
}
