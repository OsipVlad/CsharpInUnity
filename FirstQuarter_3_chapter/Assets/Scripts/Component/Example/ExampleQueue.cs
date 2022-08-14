using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public sealed class ExampleQueue
    {
        public void Main()
        {
            //var numbers = new Queue<int>(4);

            //numbers.Enqueue(1);
            //numbers.Enqueue(1);
            //numbers.Enqueue(5);
            //numbers.Enqueue(2);

            //Debug.Log(numbers.Peek());

            //Debug.Log(numbers.Dequeue());
            //Debug.Log(numbers.Dequeue());
            //Debug.Log(numbers.Dequeue());
            //Debug.Log(numbers.Dequeue());

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Debug.Log(stack.Peek());

            for(int i = 0; i <= stack.Count; i++)
            {
                Debug.Log(stack.Pop());
            }

            Debug.Log(stack.Peek());


        }
    }
}
