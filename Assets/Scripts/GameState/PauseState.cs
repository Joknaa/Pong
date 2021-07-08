using UnityEngine;

namespace GameState {
    public class PauseState : IGameState {
        private bool IsPaused;
        private bool ButtonPressed;
        private GameStateController GSC;
        
        public IGameState DoState(GameStateController GSC) {
            this.GSC = GSC;
            if (!IsPaused) {
                Pause();
            } else if (Input.GetKeyDown(KeyCode.Escape) || ButtonPressed) {
                Unpause();
                return GSC.playState;
            }

            return GSC.pauseState;
        }
        
        private void Pause() {
            IsPaused = true;
            GSC.GetPauseMenu().SetActive(true);
            Time.timeScale = 0;

            GSC.GetMainAudioSource().volume = 0.1f;
            GSC.GetPauseAudioSource().clip = GSC.GetPauseINSound();
            GSC.GetPauseAudioSource().Play(); 
        }
        private void Unpause() {
            IsPaused = false;
            GSC.GetPauseMenu().SetActive(false);
            Time.timeScale = 1;

            GSC.GetMainAudioSource().volume = 0.3f;
            GSC.GetPauseAudioSource().clip = GSC.GetPauseOUTSound();
            GSC.GetPauseAudioSource().Play(); 
        }



        public void SetButtonPressed(bool flag) { ButtonPressed = flag; }
    }
}