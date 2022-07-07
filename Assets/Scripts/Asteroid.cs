using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    public class Asteroid : MonoBehaviour
    {
        float DamageLevel = 10f;

        public event Action<float> OnCaughtPlayer = delegate (float damageLevel) { };

        protected void Interaction()
        {
            OnCaughtPlayer.Invoke(DamageLevel);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
            }
        }
    }
}
