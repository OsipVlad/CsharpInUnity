using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestNsp
{

    public class Test : MonoBehaviour
    {
        public UnityEvent MyUnityEvent;

        public delegate int TestDelegate(int val1, int val2);

        event TestDelegate MyEvent;

        public TestDelegate summ;
        public TestDelegate substraction;
        public TestDelegate multiply;
        public TestDelegate divide;


        private void OnEnable()
        {
            
        }

        public void InfoHandler()
        {
            Debug.Log("Произошло событие");
        }

        static int SomeMethod1(int a, int b)
        {
            Debug.Log("Summ: " + (a + b));
            return a + b;
        }

        static int SomeMethod2(int a, int b)
        {
            Debug.Log("substraction: " + (a - b));
            return a - b;
        }

        static int SomeMethod3(int a, int b)
        {
            Debug.Log("multiply: " + (a * b));
            return a * b;
        }

        static int SomeMethod4(int a, int b)
        {
            Debug.Log("divide: " + (a / b));
            return a / b;
        }


        private void Start()
        {
            summ = SomeMethod1;
            substraction = SomeMethod2;
            multiply = SomeMethod3;
            divide = SomeMethod4;

            divide += SomeMethod1;
            divide += SomeMethod2;
            divide += SomeMethod3;
            divide += SomeMethod4;

            MyEvent += TempVoid;

            if (MyUnityEvent == null)
            {
                MyUnityEvent = new UnityEvent();
                MyUnityEvent.AddListener(InfoHandler);
            }

            MyUnityEvent.Invoke();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Operation(20, 30, substraction);

                MyEvent?.Invoke(40, 60);
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                divide?.Invoke(100, 50);

            }
        }

        public void Operation(int a, int b, TestDelegate myDelegate)
        {
            myDelegate(a, b);
        }

        int TempVoid(int x, int y)
        {
            return 0;
        }
    }
}
