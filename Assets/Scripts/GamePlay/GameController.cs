using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay {
    public class GameController : MonoBehaviour {
        private Color SliderColor;
        private Color BallColor;
        private GameObject Ball;
        private Rigidbody2D BallRigidbody2D;
        private AudioSource AudioSource;
        private GameState CurrentState = GameState.Play;
        public AudioClip MainTheme;

        private void Start() {
            SetupAudio();
            SetupBall();
            GameObject.FindGameObjectWithTag("Slider").GetComponent<SpriteRenderer>().color = Global.SelectedSlider;
            GameObject.FindGameObjectWithTag("EnemyAI").GetComponent<SpriteRenderer>().color = Global.SelectedSlider;
        }

        private void Update() {
            switch (CurrentState) {
                case GameState.Play: Play();
                    break;
                case GameState.Pause: Pause();
                    break;
                case GameState.Result : Result();
                    break;
            }
        }

        private void Play() {
            throw new NotImplementedException();
        }

        private void Pause() {
            throw new NotImplementedException();
        }
        
        private void Result() {
            throw new NotImplementedException();
        }



        private void SetupAudio() {
            AudioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
            AudioSource.clip = MainTheme;
            AudioSource.Play();
        }
        private void SetupBall() {
            Ball = GameObject.FindGameObjectWithTag("Ball");
            Ball.GetComponent<SpriteRenderer>().color = Global.SelectedBall;
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
            BallRigidbody2D.velocity = Vector2.zero;
            BallRigidbody2D.AddForce(new Vector2(200 * Direction_X, 200 * Direction_Y));
        }
    }
}