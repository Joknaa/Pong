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
        public AudioClip MainTheme;

        private void Start() {
            SetupAudio();
            SetupBall();
            SetupSliders();
        }

        private void SetupAudio() {
            AudioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
            AudioSource.clip = MainTheme;
            AudioSource.Play();
        }
        private void SetupBall() {
            Ball = GameObject.FindGameObjectWithTag("Ball");
            BallRigidbody2D = Ball.GetComponent<Rigidbody2D>();
            if (CrossScenes.SelectedBall != null) {

                Ball.GetComponent<SpriteRenderer>().sprite =  Sprite.Create(
                    SetupBallTexture(CrossScenes.SelectedBall), new Rect(0, 0, 50, 50), Vector2.one * 0.5f
                    );
            }
            LaunchBall();
        }

        private static void SetupSliders() {
            if (CrossScenes.SelectedSlider == null) return;
            SpriteRenderer PlayerSR = GameObject.FindGameObjectWithTag("Slider").GetComponent<SpriteRenderer>();
            SpriteRenderer EnemySR = GameObject.FindGameObjectWithTag("EnemyAI").GetComponent<SpriteRenderer>();
            PlayerSR.sprite = Sprite.Create(SetupSliderTexture(CrossScenes.SelectedSlider), new Rect(0, 0, 50, 250), Vector2.one * 0.5f);
            EnemySR.sprite  = Sprite.Create(SetupSliderTexture(CrossScenes.SelectedSlider), new Rect(0, 0, 50, 250), Vector2.one * 0.5f);
        }
        
        private static Texture2D SetupSliderTexture(Sprite Image) {
            Texture2D ImageTexture = Image.texture;
            Texture2D PrefabTexture = new Texture2D(50, 250);

            for (var i = 0; i < PrefabTexture.width; i++)
                for (var j = 0; j < PrefabTexture.height; j++)
                    PrefabTexture.SetPixel(i, j, ImageTexture.GetPixel(i, j));

            PrefabTexture.Apply();
            return PrefabTexture;
        }
        private Texture2D SetupBallTexture(Sprite Image) {
            Texture2D ImageTexture = Image.texture;
            Texture2D PrefabTexture = new Texture2D(50, 50);
            int radius = 25;
            int rSquared = radius * radius;

            for (int u = 25 - radius; u < 25 + radius + 1; u++) {
                for (int v = 25 - radius; v < 25 + radius + 1; v++) {
                
                    if ((25 - u) * (25 - u) + (25 - v) * (25 - v) < rSquared)
                        PrefabTexture.SetPixel(u, v, ImageTexture.GetPixel(u, v));
                    else
                        PrefabTexture.SetPixel(u, v, new Color(0, 0, 0, 0));
                }
            }

            PrefabTexture.Apply();
            return PrefabTexture;
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