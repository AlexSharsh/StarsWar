using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    enum Weapon
    {
        BLASTER = 0,

    }

    [Serializable]
    public class Weapons : MonoBehaviour, ISetPlayerSpeed
    {
        private int _weaponCurrent;
        private Blaster _leftBlaster = new Blaster();
        private Blaster _rightBlaster = new Blaster();
        [SerializeField] Transform _leftBlasterTransform;
        [SerializeField] Transform _rightBlasterTransform;


        public void Awake()
        {
            _leftBlaster.Init(_leftBlasterTransform);
            _rightBlaster.Init(_rightBlasterTransform);
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _leftBlaster.Fire();
                _rightBlaster.Fire();
            }
        }

        public void SetPlayerSpeed(float speed)
        {
            _leftBlaster.SetPlayerSpeed(speed);
            _rightBlaster.SetPlayerSpeed(speed);
        }
    }
}
