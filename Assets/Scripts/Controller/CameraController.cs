using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    enum CameraView
    {
        MAIN = 0,
        CABIN,
        VIEW_COUNT,
    }
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _cameraTransform;
        private Vector3 _offset;
        private CameraView _currentView;
        private Camera _mainCamera;
        private Camera _cabinCamera;

        public CameraController(Camera main, Camera cabin)
        {
            _currentView = CameraView.MAIN;
            _mainCamera = main;
            _cabinCamera = cabin;
        }

        private void CameraChangeView(CameraView view)
        {
            switch (view)
            {
                case CameraView.MAIN:
                    _mainCamera.enabled = true;
                    _cabinCamera.enabled = false;
                    break;

                case CameraView.CABIN:
                    _cabinCamera.enabled = true;
                    _mainCamera.enabled = false;
                    break;
            }
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                _currentView++;
                if(_currentView >= CameraView.VIEW_COUNT)
                {
                    _currentView = CameraView.MAIN;
                }

                CameraChangeView(_currentView);
            }
        }
    }
}
