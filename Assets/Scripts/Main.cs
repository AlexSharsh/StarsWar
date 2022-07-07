using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace StarsWar
{
    public class Main : MonoBehaviour
    {
        private Reference _reference;
        private PlayerController _playerController;
        //private CameraController _cameraController;
        [SerializeField] private GameObject _player;
        List<GameObject> _asteroidsPrefabs = new List<GameObject>();
        List<GameObject> _asteroidsListObj = new List<GameObject>();
        AsteroidObjects asteroids;

        public void Awake()
        {
            _reference = new Reference();

            //_cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _playerController = new PlayerController(_player.GetComponent<Unit>());

            asteroids = new AsteroidObjects();
            _asteroidsPrefabs.Add(_reference.Rock1);
            _asteroidsPrefabs.Add(_reference.Rock2);
            _asteroidsPrefabs.Add(_reference.Rock3);
            _asteroidsListObj = asteroids.Create(_asteroidsPrefabs, 1000, _player.transform);

            for (int i = 0; i < _asteroidsListObj.Count; i++)
            {
                //Asteroid asteroid = _asteroidsListObj[i].gameObject.GetComponentInParent<Asteroid>();
                //asteroid.OnCaughtPlayer += DamageByAsteroid;
            }
        }

        void DamageByAsteroid(float damageLevel)
        {
            if(_player.gameObject.GetComponentInChildren<Player>().Health > 0)
            {
                _player.gameObject.GetComponentInChildren<Player>().Health -= damageLevel;
                Debug.Log($"Player Health: {_player.gameObject.GetComponentInChildren<Player>().Health}");
            }
        }

        
        void Update()
        {
            _playerController.Update();
            //_cameraController.Update();
        }
    }
}
