using System;
using UnityEngine;

public class BallController : MonoBehaviour {
    private GameObject GameMaster;
    private Rigidbody2D BallRigidBody2D;
    private Rigidbody2D SliderRigidBody2D;
    private Vector2 BallVelocity;
    private Vector2 SliderVelocity;

    private void Start() {
        GameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        BallRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        BallVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        SliderRigidBody2D = GameObject.FindGameObjectWithTag("Slider").GetComponent<Rigidbody2D>();
        SliderVelocity = GameObject.FindGameObjectWithTag("Slider").GetComponent<Rigidbody2D>().velocity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Goal")) {
            GameMaster.GetComponent<GameController>().RestartRound();
        }
        else if (other.gameObject.CompareTag("Slider")) {
            Vector2 direction = SliderRigidBody2D.position - BallRigidBody2D.position;
            BallRigidBody2D.velocity += direction;

            //BallRigidBody2D.AddForce(new Vector2(0,), ForceMode2D.Force);
            //BallVelocity += SliderVelocity;
            Debug.Log("tuch !!");
        }
    }
}