using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class EnemyFactory : MonoBehaviour
    {
        Helper helper = new Helper();

        public List<GameObject> Create(GameObject EnemyPrefab, int ObjectCount, Transform tr)
        {
            List<GameObject> EnemyList = new List<GameObject>();

            for (int i = 0; i < ObjectCount; i++)
            {
                GameObject enemyObj = Instantiate(EnemyPrefab, helper.RandomAround(100, 1000, tr.position), tr.rotation);
                EnemyList.Add(enemyObj);
            }

            return EnemyList;
        }
    }
}
