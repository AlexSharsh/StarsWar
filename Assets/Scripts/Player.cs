using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class Player : Unit
    {

        public void Awake()
        {
            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }

            if (GetComponent<Transform>())
            {
                _tr = GetComponent<Transform>();
            }
        }

        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                Vector3 d = new Vector3(x, y, z);
                _rb.AddForce(_tr.TransformDirection(d.normalized * Speed) * Speed, ForceMode.VelocityChange);
            }
            else
            {
                throw new Exception("Player: No RigidBody");
            }
        }

        public override void Rotate(float x, float y, float z)
        {
            _tr.Rotate(new Vector3(x, y, z));
        }
    }
}
