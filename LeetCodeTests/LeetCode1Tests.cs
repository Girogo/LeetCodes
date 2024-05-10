using LeetCode;
using System;

namespace LeetCodeTests
{
    public class LeetCode1Tests
    {
        private LeetCode1 _leetCode1;
        private Random _random = new Random();

        public LeetCode1Tests()
        {
            _leetCode1 = new LeetCode1();
            _random = new Random();
        }

        [Fact]
        public void TwoSum_WithRandomInput()
        {
            int[] nums = GenerateRandomArray();
            int[] expected = GetResultIndexes(nums);

            int target = nums[expected[0]] + nums[expected[1]];
            int[] result = _leetCode1.TwoSum(nums, target);

            Assert.True((result[0] == expected[0] || result[0] == expected[1]) &&
                (result[1] == expected[0] || result[1] == expected[1]));
        }

        private int[] GenerateRandomArray()
        {
            int length = _random.Next(2, (int)Math.Pow(10, 4));
            int[] nums = new int[length];

            for (int i = 0; i < length; i++)
            {
                nums[i] = _random.Next((int)Math.Pow(-10, 9), (int)Math.Pow(10, 9) + 1);
            }

            return nums;
        }

        private int[] GetResultIndexes(int[] nums)
        {
            int firstIndex = _random.Next(0, nums.Length);
            int secondIndex = -1;

            while (secondIndex == -1 || secondIndex == firstIndex)
            {
                secondIndex = _random.Next(0, nums.Length);
            }

            return new int[] { firstIndex, secondIndex };
        }
    }
}