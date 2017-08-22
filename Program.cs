using System;
using System.Collections.Generic;
namespace coding_challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine($"climbStairs of: {DynamicProgramming.climbStairs(2)}");
            // int[] nums = new int[6] {-2, 0, 3, -5, 2, -1};
            // NumArray obj = new NumArray(nums);
            // obj.print();
            // Console.WriteLine($"sumRange(0, 2) -> {obj.sumRange(0, 2)}");
            // Console.WriteLine($"{obj.sumRange(0, 5)}");
            // Console.WriteLine($"Fibonacci1 of 13: {DynamicProgramming.fibonacci1(5)}");
            // Console.WriteLine($"ccti8_1 of 6: {DynamicProgramming.tripleStep(6)}");
            // string[] pset = DynamicProgramming.powerSet("abc");
            // foreach (string s in pset)
            // {
            //     Console.WriteLine(s);
            // }
            // string a = "abcbbaacbbcad";
            // string b = "adbcabbccbbaa";
            // Console.WriteLine(ArraysAndStrings.checkPermutation(a, b));

            // // Challenge: Is Unique
            // string c = "abcdgehrtyiponmvz";
            // Console.WriteLine(ArraysAndStrings.isUnique(c));

            // // Challenge: String Compression
            // string d = "aabbccddEEAAfaaaCVBaaaDSGaeiuqWERTWERryoiqwfbRETWERTabsfqwfAFDASDFEWRFbwecsADASDam";
            // Console.WriteLine(ArraysAndStrings.stringCompression(d));

            // string f = "Taco cataattom";
            // Console.WriteLine(ArraysAndStrings.palindromePermutation(d));

            // Challenge: Rotate Matrix
            
            int[,] array = new int[,]
            {
                {0, 1, 2, 3, 4, 5, 6},
                {7, 8, 9, 10, 11, 12, 13},
                {14, 15, 16, 17, 18, 19, 20},
                {21, 22, 23, 24, 25, 26, 27},
                {28, 29, 30, 31, 32, 33, 34},
                {35, 36, 37, 38, 39, 40, 41},
                {42, 43, 44, 45, 46, 47, 48}
            };
            Console.WriteLine("Before rotation:");
            printArray(array);
            ArraysAndStrings.rotateMatrix(array);
            Console.WriteLine("\nAfter rotation:");
            printArray(array);

            int[,] zeroArray = new int[,]
            {
                {1, 1, 1, 1, 1},
                {1, 1, 0, 1, 1},
                {1, 1, 1, 1, 0},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1}
            };

            Console.WriteLine("\nzeroArray before zeroing out: ");
            printArray(zeroArray);
            ArraysAndStrings.zeroMatrix(zeroArray);
            Console.WriteLine("\nzeroArray after zeroing out: ");
            printArray(zeroArray);

            string a1 = "alex";
            string a2 = "exla";
            Console.WriteLine($"\nIs a string rotation: {ArraysAndStrings.stringRotation(a1, a2)}");

            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();
            sll.addLast("a");
            sll.addLast("b");
            sll.addLast("c");
            sll.addLast("d");
            sll.addLast("e");
            sll.addLast("f");

            SinglyLinkedList<string> sllA = new SinglyLinkedList<string>();
            sllA.addLast("a");
            sllA.addLast("b");
            sllA.addLast("c");
            // Console.WriteLine(LinkedLists.returnString(sll));
            // LinkedLists.removeDupsNoBuffer(sll);
            // LinkedLists.deleteMiddleNode(sllA);

            Console.WriteLine(sllA.ToString());
            Console.WriteLine(LinkedLists.returnKthToLast(sllA, 3));

            SinglyLinkedList<int> sllB = new SinglyLinkedList<int>();
            sllB.addLast(6);
            sllB.addLast(1);
            sllB.addLast(7);
            // sllB = LinkedLists.partition(sllB, 5);
            SinglyLinkedList<int> sllC = new SinglyLinkedList<int>();
            sllC.addLast(2);
            sllC.addLast(9);
            sllC.addLast(5);
            sllC.addLast(0);
            
            SinglyLinkedList<int> sllD = LinkedLists.forwardSumLists(sllB, sllC);
            Console.WriteLine(sllD);
        }

        public static void printArray(int[,] b)
        {
            for (int row = 0; row < b.GetLength(0); row++)
            {
                for (int col = 0; col < b.GetLength(1); col++)
                {
                    if (b[row, col] < 10) Console.Write($"{b[row, col]}  ");
                    else                  Console.Write($"{b[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
