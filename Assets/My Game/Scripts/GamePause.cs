using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyGames
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private Button _quitGameButton;
        [SerializeField] private Button _exitMenuGameButton;

        public bool IsPaused = false;
        public GameObject pauseMenuUI;

        private void Awake()
        {
            _quitGameButton.onClick.AddListener(() => { Application.Quit(); });
            _exitMenuGameButton.onClick.AddListener(MainMenu);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    Continue();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Continue()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
            Continue();
        }


    }
}