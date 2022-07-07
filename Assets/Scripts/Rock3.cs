using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    public class Rock3 : Asteroid
    {
        float DamageLevel = 10f;

        public event Action<float> Rock3OnCaughtPlayer = delegate (float damageLevel) { };


        public override void Interaction()
        {
            Rock3OnCaughtPlayer.Invoke(DamageLevel);
        }

        public override void Update()
        {
            
        }
    }
}
