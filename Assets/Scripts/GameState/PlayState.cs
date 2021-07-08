using UnityEngine;

namespace GameState {
    public class PlayState : IGameState{
        
        public IGameState DoState(GameStateController GSC) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                return GSC.pauseState;
            }

            return GSC.playState;
        }
    }
}