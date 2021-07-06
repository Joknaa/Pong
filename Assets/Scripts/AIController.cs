using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    private Vector3 PlayerPosition;
    public Rigidbody2D AIRigidbody2D;
    public Rigidbody2D BallRigidbody2D;

    private void Start() {
        PlayerPosition = gameObject.GetComponent<Transform>().position;
    }

    private void FixedUpdate() {
        Debug.Log(BallRigidbody2D.velocity.magnitude);

        float AIMovement = BallRigidbody2D.position.y - AIRigidbody2D.position.y;

        AIRigidbody2D.velocity = new Vector2(AIRigidbody2D.velocity.x, AIMovement * 20);
        Debug.Log("AI Velocity: "+AIRigidbody2D.velocity.magnitude);
    }
}