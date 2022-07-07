using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    public class Rock1 : Asteroid
    {
        float DamageLevel = 10f;

        public event Action<float> Rock1OnCaughtPlayer = delegate (float damageLevel) { };


        public override void Interaction()
        {
            Rock1OnCaughtPlayer.Invoke(DamageLevel);
        }

        public override void Update()
        {
            
        }
    }
}
