using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestMVC
{
    public class Controller
    {
        private View _playerViev;
        private View _triggerView;
        private Transform _playerT;


        public Controller(View playerView, View triggerView)
        {
            _playerViev = playerView;
            _triggerView = triggerView;
            _playerT = _playerViev.Transform;

            _triggerView.OnLvlObjectContact += ControllerRecieveAction;
        }

        private void ControllerRecieveAction(Collider contactView, int val, Transform ObjT)
        {
            Debug.Log("���������� �������: ��� ������� � ��������: " + contactView.name);
            GameObject.Destroy(contactView.gameObject);
        }
    }
}
