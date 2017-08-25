using System;
using System.Collections.Generic;
using coding_challenges.DataStructures;
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
            sll.AddLast("a");
            sll.AddLast("b");
            sll.AddLast("c");
            sll.AddLast("d");
            sll.AddLast("e");
            sll.AddLast("f");

            SinglyLinkedList<string> sllA = new SinglyLinkedList<string>();
            sllA.AddLast("a");
            sllA.AddLast("b");
            sllA.AddLast("c");
            // Console.WriteLine(LinkedLists.returnString(sll));
            // LinkedLists.removeDupsNoBuffer(sll);
            // LinkedLists.deleteMiddleNode(sllA);

            Console.WriteLine(sllA.ToString());
            Console.WriteLine(LinkedLists.returnKthToLast(sllA, 3));

            SinglyLinkedList<int> sllB = new SinglyLinkedList<int>();
            sllB.AddLast(6);
            sllB.AddLast(1);
            sllB.AddLast(7);
            // sllB = LinkedLists.partition(sllB, 5);
            SinglyLinkedList<int> sllC = new SinglyLinkedList<int>();
            sllC.AddLast(2);
            sllC.AddLast(9);
            sllC.AddLast(5);
            sllC.AddLast(0);
            
            SinglyLinkedList<int> sllD = LinkedLists.forwardSumLists(sllB, sllC);
            Console.WriteLine(sllD);

            StackWithMin<int> stackMin = new StackWithMin<int>();
            stackMin.Push(10);
            stackMin.Push(5);
            stackMin.Push(7);
            stackMin.Push(1);
            stackMin.Push(3);
            stackMin.Push(8);
            stackMin.Push(4);

            Console.WriteLine(stackMin.Pop());
            Console.WriteLine(stackMin.Min());
            Console.WriteLine(stackMin.Pop());
            Console.WriteLine(stackMin.Min());
            Console.WriteLine(stackMin.Pop());
            Console.WriteLine(stackMin.Min());
            Console.WriteLine(stackMin.Pop());
            Console.WriteLine(stackMin.Pop());
            Console.WriteLine(stackMin.Min()+"\n");

            SetOfStacks<int> set = new SetOfStacks<int>(25);
            for (int i = 0; i < 100; i++) set.Push(i);
            for (int i = 0; i < 100; i++) Console.Write($"{set.Pop()} ");
            Console.WriteLine('\n');

            LinkedStack<int> q1 = new LinkedStack<int>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++) q1.Push(rnd.Next(1, 100));
            StackAndQueueFunctions.sortStack(q1);
            for (int i = 0; i < 100; i++) Console.Write($"{q1.Pop()} ");
            Console.WriteLine('\n');

            Card card = new CreditCard();
            card.Charge();
            Console.WriteLine($"Balance: {card.Balance}");            
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
