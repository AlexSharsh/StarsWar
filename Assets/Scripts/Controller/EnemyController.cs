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
        private float _enemySpeed = 3f;

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
                float distance = Vector3.Distance(_enemyList[i].GetComponent<Transform>().position, _enemyGoToPoint[i]);
                Debug.Log($"Enemy[{i}]: {distance}");
                if (distance > 100)
                {
                    Vector3 direction = Vector3.MoveTowards(_enemyList[i].transform.position, _enemyGoToPoint[i], _enemySpeed * Time.deltaTime);
                    //_enemyList[i].transform.position += direction;
                    _enemyList[i].GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
                }
                else
                {
                    _enemyGoToPoint[i] = new Vector3(Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius),
                                                     Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius),
                                                     Random.Range(-_enemyPatrolRadius, _enemyPatrolRadius));
                }

                //if (_agent.remainingDistance <= _agent.stoppingDistance)
                //{
                //    PatrolPointsIndex = (PatrolPointsIndex + 1) % PatrolPoints.Length;
                //    _agent.SetDestination(PatrolPoints[PatrolPointsIndex].position);
                //}

                //if ((Vector3.Distance(_agent.transform.position, _player.transform.position)) < 4)
                //{
                //    _agent.SetDestination(_player.transform.position);
                //    _agent.speed = 1.0f;
                //    _isPatrol = false;
                //}
            }
        }
    }
}
