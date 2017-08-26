using System;
using System.Collections.Generic;
using coding_challenges.DataStructures;

namespace coding_challenges
{
    /* P. 98 (2.2) - Stack Min:
        How would you design a stack which, in addition to push and pop, has a function min
        which returns the minimum element? Push, pop and min should all operate in 0(1) time.
     */
    public class StackWithMin<E> : LinkedStack<E> where E : IComparable
    {
        LinkedStack<E> minStack;

        public StackWithMin() 
        {
            minStack = new LinkedStack<E>();
        }

        public new void Push(E data)
        {
            if (minStack.Size() == 0 || data.CompareTo(minStack.Top()) < 0) minStack.Push(data);
            base.Push(data);
        }

        public new E Pop()
        {
            E value = base.Pop();
            if (value.CompareTo(Min()) == 0) minStack.Pop();
            return value;
        }

        public E Min() 
        {
            if (minStack.IsEmpty()) return default(E);
            return minStack.Top();
        }
    }

    /* P. 99 (2.3) - Stack of Plates:
        Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
        Therefore, in real life, we would likely start a new stack when the previous stack exceeds some
        threshold. Implement a data structure SetOfStacks that mimics this. SetOfStacks should be
        composed of several stacks and should create a new stack once the previous one exceeds capacity.
        SetOfStacks. push () and SetOfStacks. pop () should behave identically to a single stack
        (that is, pop ( ) should return the same values as it would if there were just a single stack).
        FOLLOW UP
        Implement a function popAt (int index) which performs a pop operation on a specific sub-stack.
    */
    
    public class SetOfStacks<E> where E : IComparable
    {
        List<LinkedStack<E>> set = new List<LinkedStack<E>>();
        int capacityPerStack;

        public SetOfStacks(int cap = 100)
        {
            capacityPerStack = cap;
            Console.WriteLine("capacityPerStack: " + capacityPerStack);
            set.Add(new LinkedStack<E>());
        }

        public void Push(E data)
        {
            if (set[set.Count - 1].Size() <= capacityPerStack)
            {
                set[set.Count - 1].Push(data);
            }
            else
            {
                set.Add(new LinkedStack<E>());
                set[set.Count - 1].Push(data);
            }
        }

        public E Pop()
        {
            if (set[set.Count - 1].Top() == null) return default(E);
            E value = set[set.Count - 1].Pop();
            if (set[set.Count - 1].Size() == 0) set.RemoveAt(set.Count - 1);
            return value;
        }

        public E PopAt(int k)
        {
            if (set[set.Count - 1].Top() == null) return default(E);
            if (k >= set.Count) throw new Exception("Index out of bounds.");

            E value = set[k].Pop();
            if (set[k].IsEmpty()) set.RemoveAt(k);
            return value;
        }

 
    }

    /*  P. 99 (2.4) - Queue via Stacks:
        Implement a MyQueue class which implements a queue using two stacks.
    */
    public class MyQueue<E> where E : IComparable
    {
        LinkedStack<E> q1;  // Contains newest items in front.
        LinkedStack<E> q2;  // Contains newest items in back.

        public MyQueue()
        {
            q1 = new LinkedStack<E>();
            q2 = new LinkedStack<E>();
        }

        public void Enqueue(E data)
        {
            q1.Push(data);
        }

        public E Dequeue()
        {
            EnqueueStack();
            return q2.Pop();
        }

        public E First()
        {
            EnqueueStack();
            return q2.Top();
        }

        private void EnqueueStack()
        {
            while (!q1.IsEmpty())
            {
                q2.Push(q1.Pop());
            }
        }
    }

    /* P. 99 (2.5) - Sort Stack:
        Write a program to sort a stack such that the smallest items are on the top. You can use
        an additional temporary stack, but you may not copy the elements into any other data structure
        (such as an array). The stack supports the following operations: push, pop, peek, and isEmpty.

    */
    public class StackAndQueueFunctions
    {
        public static void sortStack(LinkedStack<int> a)
        {
            LinkedStack<int> b = new LinkedStack<int>();

            while (!a.IsEmpty())
            {
                int temp = a.Pop();
                while (!b.IsEmpty() && b.Top() > temp)
                {
                    a.Push(b.Pop());
                }
                b.Push(temp);
            }

            while (!b.IsEmpty())
            {
                a.Push(b.Pop());
            }
        }
    }

    /*  P. 99 (3.6) - Animal Shelter:
        An animal shelter, which holds only dogs and cats, operates on a strictly "first in, first
        out" basis. People must adopt either the "oldest" (based on arrival time) of all animals at the shelter,
        or they can select whether they would prefer a dog or a cat (and will receive the oldest animal of
        that type). They cannot select which specific animal they would like. Create the data structures to
        maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog,
        and dequeueCat. You may use the built-in Linked List data structure.
     */

    public class AnimalShelterQueue<E>
    {
        int order = 0;
        LinkedQueue<Animal> cats = new LinkedQueue<Animal>();
        LinkedQueue<Animal> dogs = new LinkedQueue<Animal>();

        public void Enqueue(string s)
        {
            if (s.Equals("cat"))
            {
                cats.Enqueue(new Animal("cat", order));
            }
            else if (s.Equals("dog"))
            {
                dogs.Enqueue(new Animal("dog", order));
            }
            order++;
        }

        public Animal DequeueCat()
        {
            return cats.Dequeue();
        }

        public Animal DequeueDog()
        {
            return dogs.Dequeue();
        }

        public Animal DequeueAny()
        {
            Animal cat = cats.Dequeue();
            Animal dog = dogs.Dequeue();
            if (cat.Order < dog.Order)
            {
                dogs.Enqueue(dog);
                return cat;
            }
            else
            {
                cats.Enqueue(cat);
                return dog;
            }
        }
    }

    public class Animal : IComparable
    {
        public string Type;
        public int Order { get; }

        public Animal(string t, int o)
        {
            Type = t;
            Order = o;
        }

        int IComparable.CompareTo(Object obj)
        {
            return Order - ((Animal) obj).Order;
        }
    } 
}