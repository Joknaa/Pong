using System;
using UnityEngine;

public class MovementController : MonoBehaviour {
    private Rigidbody2D sliderRigidbody2D;
    private const double Speed = 10;

    private void Start() {
        sliderRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        var Direction = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) Direction = new Vector3(1, 1);
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) Direction = new Vector3(1, -1);
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) Direction = new Vector3(-1, -1);
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) Direction = new Vector3(-1, 1);
        else {
            if (Input.GetKey(KeyCode.UpArrow)) Direction = Vector2.up;
            if (Input.GetKey(KeyCode.DownArrow)) Direction = Vector2.down;
            if (Input.GetKey(KeyCode.RightArrow)) Direction = Vector2.right;
            if (Input.GetKey(KeyCode.LeftArrow)) Direction = Vector2.left;
        }

        sliderRigidbody2D.velocity = (float) Speed * Direction;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ts a WALL !!!!");
    }
}