﻿using System;
using UnityEngine;

namespace GamePlay {
    public class BallController : MonoBehaviour {
        private const int BASE_SPEED = 6;
        private Rigidbody2D BallRigidBody2D;
        private GameObject GameMaster;
        private int Speed = BASE_SPEED;

        private void Start() {
            GameMaster = GameObject.FindGameObjectWithTag("GameMaster");
            BallRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var OtherTag = other.gameObject.tag;
            if (other.gameObject.CompareTag("PlayerGoal") || other.gameObject.CompareTag("EnemyGoal")) {
                GameMaster.GetComponent<ScoreController>().UpdateScore(OtherTag == "EnemyGoal");
                GameMaster.GetComponent<GameController>().RestartRound();
                Speed = BASE_SPEED;
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Slider") || other.gameObject.CompareTag("EnemyAI")) {
                Debug.Log(BallRigidBody2D.velocity);
                BallRigidBody2D.velocity = Speed++ * BallRigidBody2D.velocity.normalized;
            }        
        }
    }
}