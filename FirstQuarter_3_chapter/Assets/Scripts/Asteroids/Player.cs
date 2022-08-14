using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Asteroids
{

    internal sealed class RotationShip : IRotation
    {
        private readonly Transform _transform;

        public RotationShip(Transform transform)
        {
            _transform = transform;
        }

        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        public AccelerationMove(Rigidbody2D rb, float speed, float acceleration): base(rb, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }

    }

    public interface IAttak
    {
        float Force { get; }

        void GoToFire();
    }
    public interface IRotation
    {
        void Rotation(Vector3 direction);
    }
    public interface IMove
    {
        float Speed { get; }
        void Move(float x, float y, float z);
    }
    internal class MoveTransform : IMove
    {
        private readonly Rigidbody2D _playerRb;

        public float Speed { get; internal set; }
        
        public MoveTransform(Rigidbody2D rb, float speed)
        {
            _playerRb = rb;
            Speed = speed;
        }
        public void Move(float x, float y, float z)
        {
            if (_playerRb)
            {
                _playerRb.AddForce(new Vector3(x, y, z) * Speed);
            }
        }
    }


    internal class GoToFireRate : IAttak
    {
        private Rigidbody2D _rb;
        private Transform _barrel;
        public float Force { get; private set; }
        private readonly Rigidbody2D bullet;
        public void GoToFire()
        {
            var temAmmunition = Object.Instantiate(_rb, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * Force);
        }

        public GoToFireRate(Rigidbody2D rb, Transform barrel)
        {
            _rb = rb;
            _barrel = barrel;
        }
    }
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRb;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        
        private Camera _camera;
        private IMove _moveTransform;
        private IRotation _rotation;
        private IAttak _attak;
        private float horizontal;
        private float vertical;

        private void Start()
        {
            _camera = Camera.main;
            _moveTransform = new AccelerationMove(_playerRb, _speed, _acceleration);
            _rotation = new RotationShip(transform);
            _attak = new GoToFireRate(_bullet, _barrel);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _rotation.Rotation(direction);

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            _moveTransform.Move(horizontal, 0, vertical);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if( _moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _attak.GoToFire();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}
