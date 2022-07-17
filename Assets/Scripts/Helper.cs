using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    [Serializable]
    public sealed class Helper
    {
        public Vector3 RandomAround(float minDiametr, float maxDiametr, Vector3 pos)
        {
            return new Vector3(RandomAxisPoint(minDiametr, maxDiametr, pos.x), 
                               RandomAxisPoint(minDiametr, maxDiametr, pos.y),
                               RandomAxisPoint(minDiametr, maxDiametr, pos.z));
        }

        public float RandomAxisPoint(float minDiametr, float maxDiametr, float axisPos)
        {
            float r1 = Random.Range(axisPos - maxDiametr, axisPos + maxDiametr);
            float r2 = Random.Range(minDiametr, maxDiametr);

            if (-minDiametr < r1)
                r1 -= r2;
            if (r1 < minDiametr)
                r1 += r2;

            return r1;
        }
    }
}
