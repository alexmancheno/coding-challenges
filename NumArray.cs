using System;

namespace coding_challenges
{
    /*  LeetCode 303 - Range Sum Query (Immutable)
        Given an integer array nums, find the sum of the elements between indices (i, j).
        Note: 
            1) You may assume that the array does not change, 2) There are many calls
            2) There are many calls to sumRange function.
     */
    class NumArray
    { 
        private int[] sum;

        public NumArray(int[] nums)
        {
            sum = new int[nums.Length + 1];
            sum[0] = nums[0];
            for (int i = 1; i < sum.Length; i++)
                sum[i] = nums[i - 1] + sum[i - 1];
        }

        public int sumRange(int i, int j)
        {
            return sum[j + 1] - sum[i];
        }

        public void print()
        {
            foreach (int i in sum)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}