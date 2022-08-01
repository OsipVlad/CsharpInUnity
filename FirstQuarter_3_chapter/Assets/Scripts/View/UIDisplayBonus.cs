using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Maze
{


    public class UIDisplayBonus
    {
        private Text _pointLabel;

        public UIDisplayBonus(Text pointsLabel)
        {
            _pointLabel = pointsLabel;
            _pointLabel.text = String.Empty;
        }

        public void Display(int value)
        {
            _pointLabel.text = $"Bonus: {value}";
        }
    }
}
