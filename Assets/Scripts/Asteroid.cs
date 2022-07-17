using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    [Serializable]
    public abstract class Asteroid : MonoBehaviour, IExecute
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
            }
        }

        public abstract void Interaction();
        public abstract void Update();
    }
}
