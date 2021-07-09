using UnityEngine;

namespace GamePlay {
    public class BallController : MonoBehaviour {
        private Rigidbody2D BallRigidBody2D;
        private GameObject GameMaster;
        private Rigidbody2D SliderRigidBody2D;

        private void Start() {
            GameMaster = GameObject.FindGameObjectWithTag("GameMaster");
            BallRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
            SliderRigidBody2D = GameObject.FindGameObjectWithTag("Slider").GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var OtherTag = other.gameObject.tag;
            if (other.gameObject.CompareTag("PlayerGoal") || other.gameObject.CompareTag("EnemyGoal")) {
                GameMaster.GetComponent<ScoreController>().UpdateScore(OtherTag == "EnemyGoal");
                GameMaster.GetComponent<GameController>().RestartRound();
            }
            else if (other.gameObject.CompareTag("Slider")) {
                BallRigidBody2D.velocity -= other.GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}