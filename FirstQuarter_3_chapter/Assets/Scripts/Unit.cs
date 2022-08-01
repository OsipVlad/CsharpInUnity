using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{


    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        public float _speed = 5f;
        private int health = 100;
        public bool _isDead;

        public int Health 
        { 
            get 
            {
                return health;
            }
            set
            { 
               if(health < 100 && health > -1)
               {
                    health = value;
               }
               else
               {
                    health = 0;
                    Debug.Log("Неверный параметр здоровья");
               }

            }
        }

        public virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody>();
        }

        public abstract void Move(float x, float y, float z);
        

    }
}
