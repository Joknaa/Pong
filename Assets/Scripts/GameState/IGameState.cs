namespace GameState {
    public interface IGameState {

        IGameState DoState(GameStateController GSC);
    }
}