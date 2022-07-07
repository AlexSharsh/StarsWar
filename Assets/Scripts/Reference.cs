using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class Reference
    {
        private GameObject _rock1;
        private GameObject _rock2;
        private GameObject _rock3;
        private Camera _mainCamera;

        public GameObject Rock1
        {
            get
            {
                if (_rock1 == null)
                {
                    GameObject rock1Prefab = Resources.Load<GameObject>("GameObjects/Rock1");
                    _rock1 = Object.Instantiate(rock1Prefab);
                }
                return _rock1;
            }

            set { _rock1 = value; }
        }

        public GameObject Rock2
        {
            get
            {
                if (_rock2 == null)
                {
                    GameObject rock2Prefab = Resources.Load<GameObject>("GameObjects/Rock2");
                    _rock2 = Object.Instantiate(rock2Prefab);
                }
                return _rock2;
            }

            set { _rock2 = value; }
        }

        public GameObject Rock3
        {
            get
            {
                if (_rock3 == null)
                {
                    GameObject rock3Prefab = Resources.Load<GameObject>("GameObjects/Rock3");
                    _rock3 = Object.Instantiate(rock3Prefab);
                }
                return _rock3;
            }

            set { _rock3 = value; }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
            set { _mainCamera = value; }
        }
    }
}
