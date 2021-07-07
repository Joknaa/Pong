using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GUI {
    public class ButtonsController : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {
        private CustomisationController CustomisationControllerScript;
        public AudioClip HoverSound;
        public AudioClip ClickSound;
        private AudioSource ButtonAudioSource;

        private void Start() {
            ButtonAudioSource = GetComponent<AudioSource>();
            CustomisationControllerScript = GetComponent<CustomisationController>();
        }

        public void OnPointerEnter(PointerEventData e) {
            ButtonAudioSource.clip = HoverSound;
            ButtonAudioSource.Play();
        }

        public void OnPointerDown(PointerEventData e) {
            ButtonAudioSource.clip = ClickSound;
            ButtonAudioSource.Play();
        }

        public void LoadScene(string SceneToLoad) {
            Time.timeScale = 1;
            if (CustomisationControllerScript != null) {
                CustomisationControllerScript.GetPlayerName();
            }
            SceneManager.LoadScene(SceneToLoad);
        }

        public void Quit() {
            Application.Quit();
        }
    }
}