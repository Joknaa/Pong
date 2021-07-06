using UnityEngine;

public class BallController : MonoBehaviour {
    public GameController GameController;
    private Rigidbody2D ballRigidbody2D;

    private void Start() {
        ballRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Goal")) {
            GameController = gameObject.GetComponent<GameController>().DestroyBall(this);
            Debug.Log("GOAAAAAl");
        }
        else if (other.gameObject.CompareTag("Slider")) Debug.Log("tuch !!");
    }
}