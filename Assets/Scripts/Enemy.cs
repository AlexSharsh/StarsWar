using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarsWar
{
    [Serializable]
    public class Enemy : Unit
    {

        public override void Damage(float damage)
        {

        }

        public override void Move(float x, float y, float z)
        {
            Vector3 delta = new Vector3(x, y, z) - transform.position;
            delta.Normalize();
            transform.position += delta * Speed * Time.deltaTime;
        }

        public override void Rotate(float x, float y, float z)
        {
            
        }

        public override void SetSpeed(float speed)
        {
            Speed = speed;
        }
    }
}
