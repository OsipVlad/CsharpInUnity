using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains;

namespace TestMVC
{


    public class Main : MonoBehaviour
    {
        [SerializeField] private View _player;
        [SerializeField] private View _trigger;

        private Controller _controller;
        private ExampleLinkedList List;
        private ExampleQueue Q;


        public void Awake()
        {
            //_controller = new Controller(_player, _trigger);

            List = new ExampleLinkedList();
            List.Main();

            Q = new ExampleQueue();
            Q.Main();
        }

        void Update()
        {
            //Контррлируем обновление всех наших частей
        }
    }
}
