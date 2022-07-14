using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace StarsWar
{
    public class Main : MonoBehaviour
    {
        [SerializeField] public int _countOfAsteriods = 330;
        [SerializeField] public int _countOfEnemys = 1;
        [SerializeField] public int _playSpaceRadiusMax = 1000;

        [SerializeField] private Camera MainCamera;
        [SerializeField] private Camera CabinCamera;

        private Reference _reference;
        private PlayerController _playerController;
        private EnemyController _enemyController;
        private CameraController _cameraController;
        [SerializeField] private Player _player;

        List<GameObject> _Rock1ListObj = new List<GameObject>();
        List<GameObject> _Rock2ListObj = new List<GameObject>();
        List<GameObject> _Rock3ListObj = new List<GameObject>();
        AsteroidFactory _asteroidsFactory = new AsteroidFactory();

        EnemyFactory _enemyFactory = new EnemyFactory();
        List<GameObject> _EnemyListObj = new List<GameObject>();

        Weapons _weapons = new Weapons();

        ViewSpeed _viewSpeed;
        ViewHealth _viewHealth;

        public void Awake()
        {
            _reference = new Reference();

            _cameraController = new CameraController(MainCamera, CabinCamera);
            _playerController = new PlayerController(_player.GetComponent<Unit>());

            _player.OnPlayerSpeedChange += SetPlayerSpeedForWeapons;

            _Rock1ListObj = _asteroidsFactory.Create(_reference.Rock1, _countOfAsteriods, _player.transform);
            _Rock2ListObj = _asteroidsFactory.Create(_reference.Rock2, _countOfAsteriods, _player.transform);
            _Rock3ListObj = _asteroidsFactory.Create(_reference.Rock3, _countOfAsteriods, _player.transform);

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

            _EnemyListObj = _enemyFactory.Create(_reference.Enemy, _countOfEnemys, _player.transform);
            _enemyController = new EnemyController(_EnemyListObj, _playSpaceRadiusMax);
            //_weapons.Init();


            _viewSpeed = new ViewSpeed(_reference.SpeedLabel);
            _viewSpeed.Display(0);

            _viewHealth = new ViewHealth(_reference.HealthLabel);
            _viewHealth.Display((int)_player.Health);
        }

        private void DamageByAsteroid(float damageLevel)
        {
            float playerHealth = _player.gameObject.GetComponentInChildren<Player>().Health;
            if (playerHealth > 0)
            {
                playerHealth -= damageLevel;
                _player.gameObject.GetComponentInChildren<Player>().Health = playerHealth;
                _viewHealth.Display((int)playerHealth);
            }
        }

        
        void Update()
        {
            _enemyController.Update();
            _playerController.Update();
            _cameraController.Update();
        }


        public void SetPlayerSpeedForWeapons(float speed)
        {
            _weapons.SetPlayerSpeed(speed);
            _viewSpeed.Display((int)_player.GetSpeed());
        }
    }
}
