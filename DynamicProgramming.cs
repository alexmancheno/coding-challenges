using System;
using System.Text;
using System.Collections.Generic;

namespace coding_challenges
{
    class DynamicProgramming 
    {
        /* Leetcode 70 - Climb Stairs
            You are climbing a stair case. It takes n steps to reach the top. Each time you
            can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
        */
        public static int climbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            int[] dp = new int[n + 1]; 
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            
            return dp[n];
        }

        /* LeetCode 413 - Arithmetic Slices
            A sequence of number is called arithmetic if it consists of at least three elements and if the
            difference between any two consecutive elements is the same.

            A zero-indexed array A consisting of N numbers is given. A slice of that array is any pair of
            integers (P, Q) such that 0 <= P < Q < N.

            A slice (P, Q) of array A is called arithmetic if the sequence:
            A[P], A[p + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.

            The function should return the number of arithmetic slices in the array A.
        */

        public static int NumerOfArithmeticSlices(int[] a)
        {
            int dp = 0, result = 0;

            for (int i = 2; i < a.Length; i++)
            {
                if ((a[i] - a[i - 1]) == (a[i - 1] - a[i - 2])) 
                {
                    dp++;
                    result += dp;
                }
                else dp = 0;

            }
            return result;
        }

        // Dynamic programming approach with array
        public static int fibonacci(int n)
        {
            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; i++)
                fib[i] = fib[i - 1] + fib[i - 2];
            
            return fib[n];
        }

        // Dynamic programming approach without array
        public static int fibonacci1(int n)
        {
            if (n == 0) return 0;

            int a = 0;
            int b = 1;

            for (int i = 2; i < n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }

            return a + b;
        }    


        /* P. 134 (8.1) - Triple Step:
            A child is running up a staircase with n steps and can hop either 1, 2, or 3 steps at a time.
            Implement a method to count how many possible ways the child can run up the stairs.
         */
        public static int tripleStep(int n)
        {
            int[] stairs = new int[n + 1];
            stairs[1] = 1;
            stairs[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                stairs[i] = stairs[i - 1] + stairs[i - 2] + stairs[i - 3];
            }

            return stairs[n];
        }

        /* P. 135 - Robot in a grid.
            Imagine a robot sitting on the upper left corner of grid with r rows and c columns. The robot
            can only move in two directions, right and down, but certain cells are "off limits" such that
            the robot cannot step on them. Design an algorithm to find a path for the robot from top left
            to bottom right.
         */

        // public static int ccti8_2(int[,] grid)
        // {

        // }

        /* P. 135 (8.4) - Power Set:
            Write a method to return all subsets of a set
        */ 
        // Runtime: O(n 2^n)
        public static string[] powerSet(string set)
        {
            int p = (int) Math.Pow(2, set.Length);
            int l = set.Length;
            string[] pset = new string[p];

            for (int i = 0; i < p; i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(l, '0');
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < binary.Length; j++)
                {
                    
                    if (binary[j] == '1')
                    {
                        sb.Append($"{set[j]}, ");
                    }
                }
                Console.WriteLine();
                pset[i] = sb.ToString();
            }
            return pset;
        }
    }
}