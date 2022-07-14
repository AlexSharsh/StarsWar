using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarsWar
{
    public class ViewHealth
    {
        private Text _healthLabel;
        public ViewHealth(GameObject healthLabelPrefab)
        {
            _healthLabel = healthLabelPrefab.GetComponent<Text>();
            _healthLabel.text = string.Empty;
        }

        public void Display(int value)
        {
            _healthLabel.text = $"HEALTH: {value}%";
        }
    }
}
