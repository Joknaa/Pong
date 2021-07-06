using System;
using UnityEngine;

public class BallController : MonoBehaviour {
    private GameObject GameMaster;

    private void Start() {
        GameMaster = GameObject.FindGameObjectWithTag("GameMaster");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Goal")) {
            GameMaster.GetComponent<GameController>().RestartRound();
            Debug.Log("GOAAAAAl");
        }
    }
}