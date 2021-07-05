using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    private Rigidbody2D ballRigidbody2D;

    private void Start() {
        ballRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        ballRigidbody2D.AddForce(new Vector2(200, 0));
    }


    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Goal")) {
            Debug.Log("GOAAAAAl");
        } else if (other.gameObject.CompareTag("Slider")) {
            Debug.Log("tuch !!");

            Vector2 ballVelocity;
            ballVelocity.x = (ballRigidbody2D.velocity.x + other.gameObject.GetComponent<Rigidbody2D>().velocity.x);
            ballVelocity.y = (ballRigidbody2D.velocity.y + other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            ballRigidbody2D.velocity = ballVelocity;
        }
    }
}