using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyGames
{
    public class LevelComplet : MonoBehaviour
    {
        [SerializeField] private Button _exitMenuGameButton;
        [SerializeField] private Button _nextLevelGameButton;

        public bool IsPaused = false;
        public GameObject completLevelUI;

        private void Awake()
        {
            _exitMenuGameButton.onClick.AddListener(MainMenu);
            _nextLevelGameButton.onClick.AddListener(NextLevel);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Pause();
            }
        }

        public void Continue()
        {
            completLevelUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }

        public void Pause()
        {
            completLevelUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
            Continue();
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(2);
            Continue();
        }
    }
}