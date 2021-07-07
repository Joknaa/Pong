using GUI;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay {
    public class ScoreController : MonoBehaviour {
        private bool GameOver;
        private int PlayerScore = 0;
        private int EnemyScore = 0;
        public Text PlayerScoreText;
        public Text EnemyScoreText;
        public GameObject ResultPanel;

        public void UpdateScore(bool IsPlayer) {
            if (IsPlayer) {
                PlayerScore++;
                PlayerScoreText.text = PlayerScore.ToString();
                GameOver = PlayerScore >= 5;
            } else {
                EnemyScore++;
                EnemyScoreText.text = EnemyScore.ToString();
                GameOver = EnemyScore >= 5;
            }

            if (GameOver) {
                gameObject.GetComponent<PauseMenuController>().SetGameOver(true);
                gameObject.GetComponent<ResultPanelController>().DisplayResult(PlayerScore, EnemyScore);
            }
        }
    }
}