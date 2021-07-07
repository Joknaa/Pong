using System;
using UnityEngine;

public class BallController : MonoBehaviour {
    private GameObject GameMaster;
    private Rigidbody2D BallRigidBody2D;
    private Rigidbody2D SliderRigidBody2D;

    private void Start() {
        GameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        BallRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        SliderRigidBody2D = GameObject.FindGameObjectWithTag("Slider").GetComponent<Rigidbody2D>();
        
        GameObject[] SliderLimiters = GameObject.FindGameObjectsWithTag("SliderLimiter");
        foreach (var Ignored in SliderLimiters) {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Ignored.GetComponent<Collider2D>());
        }
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