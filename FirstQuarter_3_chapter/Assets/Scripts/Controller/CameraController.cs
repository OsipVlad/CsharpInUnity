using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Maze
{


    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _camera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainC)
        {
            _player = player;
            _camera = mainC;
            _offset = _camera.position - _player.position;
            _camera.LookAt(_player);

        }

        public void Update()
        {
            _camera.position = _player.position + _offset;
        }
    }
}
