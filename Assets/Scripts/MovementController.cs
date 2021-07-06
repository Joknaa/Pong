using UnityEngine;

public class MovementController : MonoBehaviour {
    private Rigidbody2D sliderRigidbody2D;
    private const double Speed = 10;

    private void Start() {
        sliderRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        var Direction = GetPressedDirection();
        sliderRigidbody2D.velocity = (float) Speed * Direction;
    }

    private static Vector2 GetPressedDirection() {
        if (Input.GetKey(KeyCode.UpArrow)    && Input.GetKey(KeyCode.RightArrow)) return new Vector3(1, 1);
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))  return new Vector3(1, -1);
        if (Input.GetKey(KeyCode.DownArrow)  && Input.GetKey(KeyCode.LeftArrow))  return new Vector3(-1, -1);
        if (Input.GetKey(KeyCode.LeftArrow)  && Input.GetKey(KeyCode.UpArrow))    return new Vector3(-1, 1); 
        
        if (Input.GetKey(KeyCode.UpArrow))    return Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))  return Vector2.down;
        if (Input.GetKey(KeyCode.RightArrow)) return Vector2.right;
        if (Input.GetKey(KeyCode.LeftArrow)) return Vector2.left;
        
        return Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ts a WALL !!!!");
    }
}