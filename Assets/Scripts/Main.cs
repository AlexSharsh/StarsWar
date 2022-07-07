using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace StarsWar
{
    public class Main : MonoBehaviour
    {
        [SerializeField]private Camera MainCamera;
        [SerializeField]private Camera CabinCamera;

        private Reference _reference;
        private PlayerController _playerController;
        private CameraController _cameraController;
        [SerializeField] private GameObject _player;
        List<GameObject> _Rock1ListObj = new List<GameObject>();
        List<GameObject> _Rock2ListObj = new List<GameObject>();
        List<GameObject> _Rock3ListObj = new List<GameObject>();
        AsteroidObjects asteroids;

        public void Awake()
        {
            _reference = new Reference();


            _cameraController = new CameraController(MainCamera, CabinCamera);
            _playerController = new PlayerController(_player.GetComponent<Unit>());

            asteroids = new AsteroidObjects();
            _Rock1ListObj = asteroids.Create(_reference.Rock1, 330, _player.transform);
            _Rock2ListObj = asteroids.Create(_reference.Rock2, 330, _player.transform);
            _Rock3ListObj = asteroids.Create(_reference.Rock3, 330, _player.transform);

            for (int i = 0; i < _Rock1ListObj.Count; i++)
            {
                Rock1 rock1 = _Rock1ListObj[i].gameObject.GetComponentInChildren<Rock1>();
                rock1.Rock1OnCaughtPlayer += DamageByAsteroid;
            }

            for (int i = 0; i < _Rock2ListObj.Count; i++)
            {
                Rock2 rock2 = _Rock2ListObj[i].gameObject.GetComponentInChildren<Rock2>();
                rock2.Rock2OnCaughtPlayer += DamageByAsteroid;
            }

            for (int i = 0; i < _Rock3ListObj.Count; i++)
            {
                Rock3 rock3 = _Rock3ListObj[i].gameObject.GetComponentInChildren<Rock3>();
                rock3.Rock3OnCaughtPlayer += DamageByAsteroid;
            }
        }

        private void DamageByAsteroid(float damageLevel)
        {
            float playerHealth = _player.gameObject.GetComponentInChildren<Player>().Health;
            if (playerHealth > 0)
            {
                playerHealth -= damageLevel;
                _player.gameObject.GetComponentInChildren<Player>().Health = playerHealth;
                Debug.Log($"Player Health: {playerHealth}");
            }
        }

        
        void Update()
        {
            _playerController.Update();
            _cameraController.Update();
        }
    }
}
