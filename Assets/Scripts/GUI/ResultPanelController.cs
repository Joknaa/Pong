using System;
using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    public class ResultPanelController : MonoBehaviour {
        private string PlayerName = CrossScenes.PlayerName;
        private string EnemyName = "Bot";
        public GameObject ResultPanel;
        public GameObject PauseButton;

        [Header("Audio: ")]
        public AudioSource MainAudioSource;
        public AudioSource ResultAudioSource;
        public AudioClip ResultSound;
        
        [Header("Text: ")]
        public Text WinnerNameText;
        public Text Score_PlayerNameText;
        public Text Score_EnemyNameText;
        public Text ScoreText;
        
        private void Start() {
            PauseButton.SetActive(true);
            ResultPanel.SetActive(false);
            PlayerName = CrossScenes.PlayerName;
        }

        public void DisplayResult(int PlayerScore, int EnemyScore) {
            PauseButton.SetActive(false);
            MainAudioSource.Stop();
            ResultAudioSource.clip = ResultSound;
            ResultAudioSource.Play();
            
            Time.timeScale = 0;
            ResultPanel.SetActive(true);

            WinnerNameText.text = PlayerScore > EnemyScore ? PlayerName : EnemyName;

            Score_PlayerNameText.text = PlayerName;
            Score_EnemyNameText.text = EnemyName;
            ScoreText.text = $" {PlayerScore} - {EnemyScore} ";

        }
    }
}