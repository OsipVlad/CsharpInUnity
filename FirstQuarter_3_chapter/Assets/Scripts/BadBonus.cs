using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Maze
{


    public class BadBonus : Bonus, IFly, IRotation
    {
        private float speedRotate;

        public event Action<string, Color> OnGameOver = delegate (string str, Color color) { };


        public override void Awake()
        {
            base.Awake();
            _hightFly = Random.Range(1f, 4f);
            speedRotate = Random.Range(13f, 40f);
        }


        protected override void Interaction()
        {
            OnGameOver?.Invoke(gameObject.name, _color);
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _hightFly), transform.position.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotate), Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }
    }
}
