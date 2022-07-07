using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] public Rigidbody _rb;
        public Transform _tr;

        public float Speed = 0f;
        public float RotateSpeed = 5f;
        public float Health = 100f;

        public abstract void Move(float x, float y, float z);
        public abstract void Rotate(float x, float y, float z);
        public abstract void SetSpeed(float speed);
    }
}
