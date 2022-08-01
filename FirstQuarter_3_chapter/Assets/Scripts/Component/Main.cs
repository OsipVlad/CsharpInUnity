using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TestMVC
{


    public class Main : MonoBehaviour
    {
        [SerializeField] private View _player;
        [SerializeField] private View _trigger;

        private Controller _controller;


        public void Awake()
        {
            _controller = new Controller(_player, _trigger);

        }

        void Update()
        {
            //Контррлируем обновление всех наших частей
        }
    }
}
