using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    [Serializable]
    public class Rock2 : Asteroid
    {
        float DamageLevel = 10f;

        public event Action<float> Rock2OnCaughtPlayer = delegate (float damageLevel) { };


        public override void Interaction()
        {
            Rock2OnCaughtPlayer.Invoke(DamageLevel);
        }

        public override void Update()
        {

        }
    }
}
