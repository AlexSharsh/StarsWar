using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarsWar
{
    [Serializable]
    public class EnemyController : IExecute
    {
        private List<Enemy> _enemyList = new List<Enemy>();
        private List<Vector3> _enemyGoToPoint = new List<Vector3>();

        private int _enemyPatrolRadius;
        private float _enemySpeed = 20f;

        public EnemyController(List<Enemy> enemyList, int enemyPatrolRadius)
        {
            _enemyList = enemyList;

            _enemyPatrolRadius = enemyPatrolRadius;

            for (int i = 0; i < _enemyList.Count; i++)
            {
                _enemyGoToPoint.Add(new Vector3(Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius), 
                                                Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius), 
                                                Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius)));
            }
        }

        public void Update()
        {
            for (int i = 0; i < _enemyList.Count; i++)
            {
                float distance = Vector3.Distance(_enemyGoToPoint[i], _enemyList[i].transform.position);
                Debug.Log($"Enemy[{i}]: {distance}");
                if (distance > 100)
                {
                    _enemyList[i].SetSpeed(_enemySpeed);
                    _enemyList[i].Move(_enemyGoToPoint[i].x, _enemyGoToPoint[i].y, _enemyGoToPoint[i].z);
                }
                else
                {
                    _enemyGoToPoint[i] = new Vector3(Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius),
                                                     Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius),
                                                     Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius));
                }
            }
        }
    }
}
