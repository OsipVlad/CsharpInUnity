using System;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoodBonus : Bonus, IFly, IFlick
    {

        public event Action<int> AddPoints = delegate (int i) { };
        public event Action<string, Color> OnGameWin = delegate (string str, Color color) { };


        private Material _material;
        private int _point;

        public override void Awake()
        {
            base.Awake();
            _material = BonusRenderer.material;
            _hightFly = 2f;
            _point = 1;
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _hightFly), transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        protected override void Interaction()
        {
            AddPoints?.Invoke(_point);
            OnGameWin?.Invoke(gameObject.name, _color);
        }
    }
}
