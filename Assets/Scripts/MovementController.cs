using Unity.Mathematics;
using UnityEngine;

public class MovementController : MonoBehaviour {
    private Transform sliderTransform;
    private const double Speed = 0.1;

    private void Start() {
        sliderTransform = gameObject.GetComponent<Transform>();
    }

    private void Update() {
        Vector3 Direction = new Vector2(0, 0);

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
        sliderTransform.position += (float) Speed * Direction;
    }
}