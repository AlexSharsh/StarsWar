using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class AsteroidObjects : MonoBehaviour
    {
        Transform tr;

        public List<GameObject> Create(List<GameObject> AsteroidList, int ObjectCount, Transform tr)
        {
            List<GameObject> AsteroidListObj = new List<GameObject>();

            for (int i = 0; i < ObjectCount; i++)
            {
                float scale = Random.Range(1f, 20f);
                GameObject gb = AsteroidList[Random.Range(0, AsteroidList.Count - 1)];
                tr = gb.GetComponent<Transform>();
                tr.localScale = new Vector3(scale, scale, scale);

                GameObject astObj = Instantiate(gb,
                                                new Vector3(Random.Range(tr.position.x - 1000, tr.position.x + 1000),
                                                            Random.Range(tr.position.y - 1000, tr.position.y + 1000),
                                                            Random.Range(tr.position.z - 1000, tr.position.z + 1000)), tr.rotation);

                AsteroidListObj.Add(astObj);
            }

            return AsteroidListObj;
        }
    }
}
