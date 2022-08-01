using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Maze
{

    public class Main : MonoBehaviour
    {
        

        private InputConroller _inputConroller;
        private ListExecuteObject _interactivObject;
        private CameraController _cameraController;
        private UIDisplayBonus _displayBonus;
        private UIDisplayGameOver _displayGameOver;
        private UIDisplayWin _displayWin;

        [SerializeField] private Unit _player;
        [SerializeField] private Text _pointLabel;
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Button _restartBotton;
        [SerializeField] private Text _gameWinLabel;

        private int _bonusCount;


        private void Awake()
        {
            Time.timeScale = 1f;

            _inputConroller = new InputConroller(_player);
            _cameraController = new CameraController(_player.transform, Camera.main.transform);
            _interactivObject = new ListExecuteObject();
            _displayBonus = new UIDisplayBonus(_pointLabel);
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);
            _displayWin = new UIDisplayWin(_gameWinLabel);

            _interactivObject.AddExecuteObject(_cameraController);
            _interactivObject.AddExecuteObject(_inputConroller);

            _restartBotton.onClick.AddListener(RestartGame);
            _restartBotton.gameObject.SetActive(false);

            foreach (var item in _interactivObject)
            {
                if(item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddPoint;

                    if (_bonusCount == 4)
                    {
                        goodBonus.OnGameWin += WinGame;
                        goodBonus.OnGameWin += _displayWin.WinGame;
                    }
                    
                }
                if(item is BadBonus badBonus)
                {
                    badBonus.OnGameOver += GameOver;
                    badBonus.OnGameOver += _displayGameOver.GameOver;
                }
            }
        }


        private void AddPoint(int value)
        {
            _bonusCount += value;
            _displayBonus.Display(_bonusCount);

            
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void GameOver(string value, Color color)
        {

            _restartBotton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void WinGame(string value, Color color)
        {
            _restartBotton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        void Update()
        {
            for(int i = 0; i < _interactivObject.Length; i++)
            {
                if(_interactivObject[i] == null)
                {
                    continue;
                }
                _interactivObject[i].Update();
            }

        }

    }
}
