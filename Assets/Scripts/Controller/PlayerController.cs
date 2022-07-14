using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarsWar
{
    public class PlayerController : IExecute
    {
        private readonly Unit _player;
        private float _forwardDirection;

        public PlayerController(Unit player)
        {
            _player = player;
        }

        public void Update()
        {
            if(Input.GetMouseButton(1))
            {
                _forwardDirection = 1f;
            }
            else
            {
                _forwardDirection = 0f;
                _player.SetSpeed(0);
            }

            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
            if(mouseWheel != 0)
            {
                _player.SetSpeed(mouseWheel);
            }

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

            _player.Move(0f, 0f, _forwardDirection);
        }
    }
}
