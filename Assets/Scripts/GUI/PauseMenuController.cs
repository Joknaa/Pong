using System;
using UnityEngine;

namespace GUI {
    public class PauseMenuController : MonoBehaviour {
        private bool GameOver = false;
        public GameObject PauseMenu;
        public AudioClip PauseInSound;
        public AudioClip PauseOutSound;
        private bool IsPaused;
        public AudioSource MainAudioSource;
        public AudioSource PauseAudioSource;

        private void Start() {
            PauseMenu.SetActive(false);
        }
        
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape) && !GameOver) {
                Pause();
            }
        }
        
        public void Pause() {
            IsPaused = !IsPaused;
            PauseMenu.SetActive(IsPaused);
            Time.timeScale = IsPaused ? 0 : 1;

            MainAudioSource.volume = IsPaused ? 0.1f : 0.3f;
            PauseAudioSource.clip = IsPaused ? PauseInSound : PauseOutSound;
            PauseAudioSource.Play();
        }

        public void SetGameOver(bool Status) {
            this.GameOver = Status;
        }
    }
}