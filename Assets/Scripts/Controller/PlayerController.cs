using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class PlayerController : IExecute
    {
        private readonly Unit _player;

        private float horizontal;
        private float vertical;

        public PlayerController(Unit player)
        {
            _player = player;
        }

        public void Update()
        {
            if(Input.GetMouseButton(1))
            {
                vertical = 1f;
            }
            else
            {
                vertical = 0f;
            }

            _player.SetSpeed(Input.GetAxis("Mouse ScrollWheel"));
           

            if (Input.GetKey(KeyCode.W))
            {
                _player.Rotate(1f, 0, 0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                _player.Rotate(-1f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                _player.Rotate(0, -1f, 0f);
            }

            if (Input.GetKey(KeyCode.E))
            {
                _player.Rotate(0, 1f, 0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _player.Rotate(0, 0, 1f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _player.Rotate(0, 0, -1f);
            }


            //var fixedDirection = _player.transform.TransformDirection(_direction.normalized);
            //transform.position += fixedDirection;
            _player.Move(0f, 0f, vertical);
        }
    }
}
