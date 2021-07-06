using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {
    public GameObject Ball;
    public GameObject EnemySlider;
    private Rigidbody2D BallRigidbody2D;

    private void Start() {
        BallRigidbody2D = Ball.GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void RestartRound() {
        Ball.transform.position = Vector3.zero;
        LaunchBall();

    }

    private void LaunchBall() {
        var Direction_X = math.sign(Random.value - 0.5f);
        var Direction_Y = math.sign(Random.value - 0.5f);
        BallRigidbody2D.AddForce(new Vector2(200 * Direction_X, 200 * Direction_Y));
    }
}