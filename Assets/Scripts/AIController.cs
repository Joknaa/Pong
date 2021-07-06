using UnityEngine;

public class AIController : MonoBehaviour {
    public Rigidbody2D AIRigidbody2D;
    public Rigidbody2D BallRigidbody2D;
    private bool Playing = true;
    
    private void FixedUpdate() {
        if (!Playing) return;
        var AIMovement = BallRigidbody2D.position.y - AIRigidbody2D.position.y;
        AIRigidbody2D.velocity = new Vector2(AIRigidbody2D.velocity.x, AIMovement * 20);
    }

    public void SetPlaying(bool status) {
        Playing = status;
    }
}