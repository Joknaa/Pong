using System;
using UnityEngine;

namespace GameState {
    public class GameStateController : MonoBehaviour {
        private IGameState currentState;
        private string currentstatename;
        
        public PlayState playState = new PlayState();
        public PauseState pauseState = new PauseState();
        public ResultState resultState = new ResultState();
        
        [Header("Pause Panel: ")]
        [SerializeField] private GameObject PauseMenu;
        [SerializeField] private AudioClip PauseInSound;
        [SerializeField] private AudioClip PauseOutSound;
        [SerializeField] private AudioSource MainAudioSource;
        [SerializeField] private AudioSource PauseAudioSource;

        private void Start() {
            currentState = playState;
        }

        private void Update() {
            currentState = currentState.DoState(this);
            currentstatename = currentState.ToString();
            Debug.Log(currentstatename);
        }

        public void SetState_Pause(bool flag) { pauseState.SetButtonPressed(flag); }
        
        public GameObject GetPauseMenu() { return PauseMenu; }
        public AudioSource GetMainAudioSource() { return MainAudioSource; }
        public AudioSource GetPauseAudioSource() { return PauseAudioSource; }
        public AudioClip GetPauseINSound() { return PauseInSound; }
        public AudioClip GetPauseOUTSound() { return PauseOutSound; }
    }
}