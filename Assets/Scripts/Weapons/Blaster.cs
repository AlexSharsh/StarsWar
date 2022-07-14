using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarsWar
{
    public class Blaster : MonoBehaviour, IFire, ISetPlayerSpeed
    {
        private GameObject _blaserPrefab;
        private Rigidbody _blaserRigidBody;
        private Transform _parentTransform;
        private float _blasterSpeed = 30f;
        private float _playerSpeed = 0f; 

        public void Init(Transform ParentTransform)
        {
            _blaserPrefab = Resources.Load<GameObject>("GameObjects/Blaster");
            _parentTransform = ParentTransform;
        }

        public void Fire()
        {
            GameObject blaster = Instantiate(_blaserPrefab, _parentTransform);
            blaster.transform.position = new Vector3(blaster.transform.position.x, blaster.transform.position.y - 0.015f, blaster.transform.position.z);
            _blaserRigidBody = blaster.GetComponent<Rigidbody>();
            _blaserRigidBody.AddForce(blaster.transform.TransformDirection(Vector3.up.normalized * _blasterSpeed * (_playerSpeed + 1f)), ForceMode.VelocityChange);
            Destroy(blaster, 1f);
        }

        public void SetPlayerSpeed(float speed)
        {
            _playerSpeed = speed;
        }
    }
}
