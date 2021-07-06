using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {
    private GameObject Ball;
    private Rigidbody2D BallRigidbody2D;

    private void Start() {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        BallRigidbody2D = Ball.GetComponent<Rigidbody2D>();
        LaunchBall();
    }
    
    private void Update() { }

    private void LaunchBall() {
        var Direction_X = math.sign(Random.value - 0.5f);
        var Direction_Y = math.sign(Random.value - 0.5f);
        BallRigidbody2D.AddForce(new Vector2(200 * Direction_X, 200 * Direction_Y));
    }
    
    public void DestroyBall() {
        Destroy(Ball);
    }
    public void SpawnBall() {
        Instantiate(Ball, Ball.transform);
    }
}