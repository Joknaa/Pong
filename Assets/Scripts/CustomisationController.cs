using UnityEngine;
using UnityEngine.UI;

public class CustomisationController : MonoBehaviour {

    public PrefabInstentiate PrefabInstantiateScript;
    public Text Text;
    private Sprite SliderTexture;
    private Sprite BallTexture;
        
    public void GetSliderTexture() {
        int SliderID = gameObject.GetInstanceID();
        CrossScenes.SelectedSlider = PrefabInstentiate.GetTextureFromSliderPrefab(SliderID);
    }
        
    public void GetBallTexture() {
        int BallID = gameObject.GetInstanceID();
        CrossScenes.SelectedBall = PrefabInstentiate.GetTextureFromBallPrefab(BallID);
    }
        
    public void GetPlayerName() {
        string PlayerName = Text.text;
        Debug.Log(PlayerName);
        CrossScenes.PlayerName = PlayerName;
    }
}