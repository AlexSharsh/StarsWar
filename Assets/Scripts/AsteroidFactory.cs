using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    [Serializable]
    public class AsteroidFactory : MonoBehaviour
    {
        Helper helper = new Helper();
        public List<GameObject> Create(GameObject AsteroidPrefab, int ObjectCount, Transform tr)
        {
            List<GameObject> AsteroidList = new List<GameObject>();

            for (int i = 0; i < ObjectCount; i++)
            {
                float scale = Random.Range(1f, 20f);
                AsteroidPrefab.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
                GameObject astObj = Instantiate(AsteroidPrefab, helper.RandomAround(10, 1000, tr.position), tr.rotation);
                AsteroidList.Add(astObj);
            }

            return AsteroidList;
        }
    }
}
