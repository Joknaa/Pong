using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay {
    public class AIController : MonoBehaviour {
        private const float BASE_SPEED = 14;
        public Rigidbody2D AIRigidbody2D;
        public Rigidbody2D BallRigidbody2D;
        private float Accuracy;
        private float Speed = BASE_SPEED;
        private float RoundDuration;
        private float AIMovement;

        private void Start() {
            Guess();
        }

        private void Update() {
            if (Time.time - RoundDuration > 5) {
                Speed -= Time.deltaTime/10;
                Debug.Log(Speed);
            }
        }

        private void FixedUpdate() {
            AIMovement = BallRigidbody2D.position.y - AIRigidbody2D.position.y + Accuracy;
            AIRigidbody2D.velocity = new Vector2(AIRigidbody2D.velocity.x, Speed * AIMovement);
        }
        
        public void Guess() {
            Accuracy = Random.Range(-2f, 2f);
            AIMovement = BallRigidbody2D.position.y - AIRigidbody2D.position.y + Accuracy;
            Debug.Log(Accuracy);
        }

        public void Reset() {
            Speed = BASE_SPEED;
            RoundDuration = Time.time;
            Guess();
        }
    }
}