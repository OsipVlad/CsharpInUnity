using System.Collections;
using UnityEngine;
using System;
using Object = UnityEngine.Object;



namespace Maze
{
    public class ListExecuteObject : IEnumerable, IEnumerator
    {
        private IExecute[] _interactivObject;
        private int _index = -1;

        public object Current => _interactivObject[_index];
        public int Length => _interactivObject.Length;

        public IExecute this[int curr]
        {
            get => _interactivObject[curr];
            private set => _interactivObject[curr] = value;
        }
        public ListExecuteObject()
        {
            Bonus[] BonusObj = Object.FindObjectsOfType<Bonus>();
            for (int i = 0; i < BonusObj.Length; i++)
            {
                if(BonusObj[i] is IExecute intObject)
                {
                    AddExecuteObject(intObject);
                }
            }
        }

        public void AddExecuteObject(IExecute execute)
        {
            if (_interactivObject == null)
            {
                _interactivObject = new[] { execute };
                return;
            }
            Array.Resize(ref _interactivObject, Length + 1);
            _interactivObject[Length - 1] = execute;
        }

        public bool MoveNext()
        {
            if (_index == Length - 1)
            {
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index -= 1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


       
    }
}
