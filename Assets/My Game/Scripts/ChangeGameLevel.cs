using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyGames
{
    public class ChangeGameLevel : MonoBehaviour
    {
        [SerializeField] private Button _level1GameButton;
        [SerializeField] private Button _level2GameButton;

        private void Awake()
        {
            _level1GameButton.onClick.AddListener(Level1);
            _level2GameButton.onClick.AddListener(Level2);
        }

        public void Level1()
        {
            SceneManager.LoadScene(1);
        }

        public void Level2()
        {
            SceneManager.LoadScene(2);
        }
    }
}