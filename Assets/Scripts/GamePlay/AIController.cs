using UnityEngine;

namespace GamePlay {
    public class AIController : MonoBehaviour {
        private const int EASY_MODE = 10;
        private const int HARD_MODE = 5;
        private const int CHALLENGE_MODE = 0;
        public Rigidbody2D AIRigidbody2D;
        public Rigidbody2D BallRigidbody2D;
        private int Sign;

        private void Start() {
            Sign = Random.Range(-1, 1) >= 0 ? 1 : -1;
        }

        private void FixedUpdate() {
            var AIMovement = BallRigidbody2D.position.y - AIRigidbody2D.position.y;
            AIRigidbody2D.velocity = new Vector2(AIRigidbody2D.velocity.x, AIMovement * 15 + EASY_MODE);
        }
    }
}