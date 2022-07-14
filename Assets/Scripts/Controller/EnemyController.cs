using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class EnemyController : IExecute
    {
        private List<GameObject> _enemyList = new List<GameObject>();
        private List<Vector3> _enemyGoToPoint = new List<Vector3>();

        private int _enemyPatrolRadius;
        private float _enemySpeed = 20f;

        public EnemyController(List<GameObject> enemyList, int enemyPatrolRadius)
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
                    Vector3 delta = _enemyGoToPoint[i] - _enemyList[i].transform.position;
                    delta.Normalize();
                    _enemyList[i].transform.position += delta * _enemySpeed * Time.deltaTime;
                    //_enemyList[i].transform.TransformDirection(_enemyList[i].transform.forward.normalized);
                    //_enemyList[i].transform.position += delta * _enemySpeed * Time.deltaTime;
                    //_enemyList[i].GetComponent<Rigidbody>().AddForce(_enemyList[i].transform.TransformDirection(_enemyList[i].transform.forward.normalized * _enemySpeed) * _enemySpeed, ForceMode.VelocityChange);
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
