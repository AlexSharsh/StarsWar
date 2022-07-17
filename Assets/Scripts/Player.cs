using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    [Serializable]
    public class Player : Unit
    {

        public event Action<float> OnPlayerSpeedChange = delegate (float speed) { };

        public void Awake()
        {
            Speed = 0f;

            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            else
            {
                throw new Exception("Player: No RigidBody");
            }

            if (GetComponent<Transform>())
            {
                _tr = GetComponent<Transform>();
            }
            else
            {
                throw new Exception("Player: No Transform");
            }
        }

        public override void Damage(float damage)
        {

        }

        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                Vector3 direction = new Vector3(x, y, z);
                _rb.AddForce(_tr.TransformDirection(direction.normalized * Speed) * Speed, ForceMode.VelocityChange);
            }
        }

        public override void Rotate(float x, float y, float z)
        {
            _tr.Rotate(new Vector3(x, y, z));
        }

        public override void SetSpeed(float speed)
        {
            if (speed == 0)
            {
                Speed = 0;
            }
            else
            {
                Speed += speed * 10;
                if(Speed < 0)
                {
                    Speed = 0;
                }
            }

            OnPlayerSpeedChange.Invoke(Speed);
        }

        public float GetSpeed()
        {
            return Speed;
        }
    }
}
