using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{


    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isInteractable;
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;
        
        
        public float _hightFly;


        public bool IsInteractable 
        { 
            get => _isInteractable;

            set
            {
                _isInteractable = value;
                BonusRenderer.enabled = value;
                _collider.enabled = value;

            }
        }

        public Renderer BonusRenderer { get => _renderer; set => _renderer = value; }

        public virtual void Awake()
        {
            BonusRenderer = GetComponent<Renderer>();
            _collider = GetComponent<Collider>();

            IsInteractable = true;
            _color = Random.ColorHSV();

            BonusRenderer.sharedMaterial.color = _color;
        }


        private void OnTriggerEnter(Collider other)
        {
            if(IsInteractable || other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable = false;
            }
        }

        protected abstract void Interaction();
        public abstract void Update();
    }
}
