using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Maze
{
    public class UIDisplayWin
    {
        private Text _gameWinLabel;

        public UIDisplayWin(Text gameWinText)
        {
            _gameWinLabel = gameWinText;
            _gameWinLabel.text = String.Empty;
        }

        public void WinGame(string name, Color color)
        {
            _gameWinLabel.text = $"You Win. Please 'Restart'";
        }
    }
}
