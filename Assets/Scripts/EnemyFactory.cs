using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    [Serializable]
    public class EnemyFactory : MonoBehaviour
    {
        Helper helper = new Helper();

        public List<Enemy> Create(Enemy EnemyPrefab, int ObjectCount, Transform tr)
        {
            List<Enemy> EnemyList = new List<Enemy>();

            for (int i = 0; i < ObjectCount; i++)
            {
                Enemy enemyObj = Instantiate(EnemyPrefab, helper.RandomAround(100, 1000, tr.position), tr.rotation);
                EnemyList.Add(enemyObj);
            }

            return EnemyList;
        }
    }
}
