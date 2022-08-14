using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Player : Unit
    {

        delegate void Message();

        Message myMessage;




        int x = 10;
        int y = 5;

        string s1 = "temp";
        string s2 = "Test";



        public override void Awake()
        {
            base.Awake();
            #region Swap()
            base.Awake();
            Debug.Log($"x = {x} :: y = {y}");
            Swap(ref x, ref y);
            Debug.Log($"x = {x} :: y = {y}");

            Debug.Log($"s1 = {s1} :: s2 = {s2}");
            Swap(ref s1, ref s2);
            Debug.Log($"s1 = {s1} :: s2 = {s2}");
            #endregion
            myMessage = Temp;

        }

        public void Temp()
        {
            Debug.Log("Delegate 1");
        }

        public void TempMessage()
        {
            Debug.Log("Delegate 2");
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);

                
            }
        }

        void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
