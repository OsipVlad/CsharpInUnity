using UnityEngine;

namespace Maze
{
    public class InputConroller : IExecute
    {
        private readonly Unit _player;

        private float horizontal;
        private float vertical;

        public InputConroller(Unit player)
        {
            _player = player;
        }
        public void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            _player.Move(horizontal, 0, vertical);

        }
    }
}
