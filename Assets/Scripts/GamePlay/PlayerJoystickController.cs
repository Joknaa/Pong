using System;
using GUI;
using UnityEngine;

namespace GamePlay {
    public class PlayerJoystickController : MonoBehaviour {
        private const float Speed = 14;
        public GameObject Joystick;
        public GameObject Handle;
        public GameObject PlayerSlider;
        private Vector2 centerPosition = Vector3.zero;
        private Vector2 Direction;

        private RectTransform HandleTransform;
        private RectTransform JoystickTransform;
        private PauseMenuController PauseMenuScript;
        private Rigidbody2D sliderRigidbody2D;
        private Touch touch;

        private void Start() {
            sliderRigidbody2D = PlayerSlider.GetComponent<Rigidbody2D>();
            Joystick.SetActive(false);
            JoystickTransform = Joystick.GetComponent<RectTransform>();
            HandleTransform = Handle.GetComponent<RectTransform>();

            PauseMenuScript = GetComponent<PauseMenuController>();
        }

        private void Update() {
            if (GamePaused()) return;
            if (Input.touchCount <= 0) return;
            touch = Input.GetTouch(0);

            switch (touch.phase) {
                case TouchPhase.Began:
                    JoystickTransform.position = touch.position;
                    centerPosition = touch.position;
                    Joystick.SetActive(true);
                    break;
                case TouchPhase.Moved:
                    var currentPosition = touch.position;
                    HandleTransform.position =
                        centerPosition + Vector2.ClampMagnitude(touch.position - centerPosition, 150);
                    Direction = new Vector2(currentPosition.x - centerPosition.x,
                        currentPosition.y - centerPosition.y).normalized;
                    break;
                case TouchPhase.Ended:
                    HandleTransform.position = JoystickTransform.position;
                    Direction = Vector2.zero;
                    Joystick.SetActive(false);
                    break;
                case TouchPhase.Canceled:
                    Direction = Vector2.zero;
                    break;
            }
        }

        private bool GamePaused() {
            return PauseMenuScript.GetIsPaused() || PauseMenuScript.GetIsGameOver();
        }

        private void FixedUpdate() {
            sliderRigidbody2D.velocity = Speed * Direction;
        }
    }
}