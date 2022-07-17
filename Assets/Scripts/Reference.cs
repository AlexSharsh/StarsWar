using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StarsWar
{
    [Serializable]
    public class Reference
    {
        private Enemy _enemy;
        private GameObject _rock1;
        private GameObject _rock2;
        private GameObject _rock3;
        private Canvas _canvas;
        private GameObject _speedLabel;
        private GameObject _healthLabel;
        private Camera _mainCamera;


        public Enemy Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    Enemy enemyPrefab = Resources.Load<Enemy>("GameObjects/Enemy");
                    _enemy = enemyPrefab;
                }
                return _enemy;
            }

            set { _enemy = value; }
        }

        public GameObject Rock1
        {
            get
            {
                if (_rock1 == null)
                {
                    GameObject rock1Prefab = Resources.Load<GameObject>("GameObjects/Rock1");
                    _rock1 = rock1Prefab;
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
                    _rock2 = rock2Prefab;
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
                    _rock3 = rock3Prefab;
                }
                return _rock3;
            }

            set { _rock3 = value; }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }

            set { _canvas = value; }
        }

        public GameObject SpeedLabel
        {
            get
            {
                if (_speedLabel == null)
                {
                    GameObject speedLabelPrefab = Resources.Load<GameObject>("UI/SpeedLabel");
                    _speedLabel = Object.Instantiate(speedLabelPrefab, Canvas.transform);
                }
                return _speedLabel;
            }

            set { _speedLabel = value; }
        }

        public GameObject HealthLabel
        {
            get
            {
                if (_healthLabel == null)
                {
                    GameObject healthLabelPrefab = Resources.Load<GameObject>("UI/HealthLabel");
                    _healthLabel = Object.Instantiate(healthLabelPrefab, Canvas.transform);
                }
                return _healthLabel;
            }

            set { _speedLabel = value; }
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
