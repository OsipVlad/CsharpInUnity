using System;
using System.Collections.Generic;
using UnityEngine;


namespace TestMVC
{
    public class View : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rb;

        public Action <Collider, int , Transform> OnLvlObjectContact { get; set; }
        public Transform Transform { get => _transform; set => _transform = value; }
        public Collider Collider { get => _collider; set => _collider = value; }
        public Rigidbody Rb { get => _rb; set => _rb = value; }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);

            Collider LevelObject = other;

            OnLvlObjectContact?.Invoke(LevelObject, 13, _transform);
        }
    }
}
