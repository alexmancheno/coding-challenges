using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace coding_challenges
{
    class ArraysAndStrings
    {

        /*  p.90 (1.1)- Is Unique:
            Implement an algorithm to determine if a string has all unique characters. What if you cannot use
            additional data structures?
         */
         public static bool isUnique(string a)
         {
             if (a.Length > 128) return false;
             int[] lettersA = new int[128];
             foreach (char i in a)
             {
                 lettersA[i]++;
                 if (lettersA[i] > 1) return false;
             }
             return true;
         }

        /*  P. 90 (1.2) - Check Permutation:
            Given two strings, write a method to decide if one is a permutation of the other.
         */
        public static bool checkPermutation(string a, string b)
        {
            if (a.Length != b.Length) return false;

            int[] lettersA = new int[128];
            int[] lettersB = new int[128];
            for (int i = 0; i < a.Length; i++)
            {
                lettersA[a[i]]++;
                lettersB[b[i]]++;
            }

            for (int i = 0; i < lettersA.Length; i++)
            {
                if (lettersA[i] != lettersB[i]) return false;
            }

            return true;
        }

        /*  P. 91 (1.4) - Palindrome Permutation:
            Given a string, write a function to check if it is a permutationof a palindrome. A palindrome
            is a word or phrase that is the same forward and backwards. A permutation is a rearrangement of
            letters. The palindrome does not need to be limited to just dictionary words.

            Example:
            input: Tact Coa
            output: True (permutations: "taco cat", "atco cta", etc.)
        
         */
        public static bool palindromePermutation(string a)
        {
            a = a.ToUpper();
            int[] letters = new int[128];
            
            for (int i = 0; i < a.Length; i++)
            {
                letters[(int)a[i]]++;
            }

            int oddChars = 0;
            for (int i = 65; i < 91; i++)
            {
                if (letters[i] % 2 != 0) oddChars++;
            }

            return ((oddChars == 1) && ((a.Length - letters[32]) % 2 == 1)) || 
                   ((oddChars == 0) && ((a.Length - letters[32]) % 2 == 0)) ;
        }


        /*P. 91 (1.6) - String Compression:
            Implement a method to perform basic string compression using the counts of repteated characters.
            For example, the string aabcccccaaa would become a2b1c5a3. If the "compressed" string would not
            become smaller than the original string, return the original string. You can assume the string has 
            only uppercase and lowercase letters (a - z).
        */
        public static string stringCompression(string a)
        {
            // Example
            // Input: aabbccddEEAAfaaaCVBaaaDSGaeiuqWERTWERryoiqwfbRETWERTabsfqwfAFDASDFEWRFbwecsADASDam
            // Output: a11b5c3d2e2f4i2m1o1q3r1s2u1w3y1A6B1C1D5E7F3G1R5S3T3V1W4
            StringBuilder compressed = new StringBuilder();
            int[] count = new int[128];
            foreach(char i in a)
            {
                count[i]++;
            }

            for (int i = 97; i < 123; i++)
            {
                if (count[i] > 0) compressed.Append($"{Convert.ToChar(i)}{count[i]}");
            }

            for (int i = 65; i < 91; i++)
            {
                if (count[i] > 0) compressed.Append($"{Convert.ToChar(i)}{count[i]}");
            }
            return compressed.Length < a.Length ? compressed.ToString() : a;
        }

        /* P. 91 (1.7) - Rotate Matrix:
            Given an image represented by a N x N matrix, where each pixel in the image is 4
            bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
        
        */
        public static void rotateMatrix(int[,] a)
        {
            if (a.Length < 2) return;
            rotateMatrix(a, a.GetLength(0) - 1, 0);            
        }

        public static void rotateMatrix(int[,] a, int n, int level)
        {
            if (n - level * 2 < 1) return;

            for (int i = level; i < n - level; i++)
            {
                swap(a, level, i, i, n - level);
                swap(a, level, i, n - level, n - i);
                swap(a, level, i, n - i, level);
            }

            rotateMatrix(a, n, ++level);
        }

        // Helper swap function for rotateMatrix
        private static void swap(int[,] b, int i, int j, int k, int l)
        {
            int temp = b[i, j];
            b[i, j] = b[k, l];
            b[k, l] = temp;
        }

        /* P.91 (1.9) - Zero Matrix:
            Write an algorithm such that if an element in an M x N matrix is 0, its entire row and column
            are set to 0.
        */
        public static void zeroMatrix(int[,] a)
        {
            bool[] row = new bool[a.GetLength(0)];
            bool[] col = new bool[a.GetLength(1)];
            
            for (int r = 0; r < a.GetLength(0); r++)
            {
                for (int c = 0; c < a.GetLength(1); c++)
                {
                    if (a[r, c] == 0)
                    {
                        row[r] = true;
                        col[c] = true;
                    }
                }
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i]) zeroOut(a, i, "row");
            }
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i]) zeroOut(a, i, "col");
            }
        }

        private static void zeroOut(int[,] a, int index, string s)
        {
            if (s.Equals("row"))
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    a[index, i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < a.GetLength(1); i++)
                {
                    a[i, index] = 0;
                }
            }
        }

        /*  P.91 (1.9) - String Rotation:
            Assume you have a method isSubstring which checks if one word is a substring of another. Given
            two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to
            isSubstring (e.g., "waterbottle" is a rotation of "erbottlewat").
         */

         public static bool stringRotation(string s1, string s2)
         {
            if (s1.Length != s2.Length) return false;
            s1 += s1;
            return isSubstring(s1, s2);
        }

         private static bool isSubstring(string s1, string s2)
         {
             return s1.Contains(s2);
         }
    }
}