using System;
using UnityEngine;

namespace GamePlay {
    public class BallController : MonoBehaviour {
        private const float BASE_SPEED = 6;
        private Rigidbody2D BallRigidBody2D;
        private GameObject GameMaster;
        private float Speed = BASE_SPEED;
        private AIController AIControllerScript;

        private void Start() {
            GameMaster = GameObject.FindGameObjectWithTag("GameMaster");
            BallRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
            AIControllerScript = GameObject.FindGameObjectWithTag("EnemyAI").GetComponent<AIController>();
        }

        private void Update() {
            Speed += Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var OtherTag = other.gameObject.tag;
            if (other.gameObject.CompareTag("PlayerGoal") || other.gameObject.CompareTag("EnemyGoal")) {
                GameMaster.GetComponent<ScoreController>().UpdateScore(OtherTag == "EnemyGoal");
                GameMaster.GetComponent<GameController>().RestartRound();
                Speed = BASE_SPEED;
                AIControllerScript.Reset();
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("EnemyAI")) {
                BallRigidBody2D.velocity = Speed * BallRigidBody2D.velocity.normalized;
                AIControllerScript.Guess();
            } else if (other.gameObject.CompareTag("Slider")) {
                BallRigidBody2D.velocity = Speed * BallRigidBody2D.velocity.normalized;
            }
        }
    }
}