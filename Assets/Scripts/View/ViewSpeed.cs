using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarsWar
{
    public class ViewSpeed
    {
        private Text _speedLabel;
        public ViewSpeed(GameObject speedLabelPrefab)
        {
            _speedLabel = speedLabelPrefab.GetComponent<Text>();
            _speedLabel.text = string.Empty;
        }

        public void Display(int value)
        {
            _speedLabel.text = $"SPEED: {value}";
        }
    }
}
