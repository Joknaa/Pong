using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    public class CustomisationController : MonoBehaviour {

        public Text Text;
        
        public void GetSliderColor() {
            Color SelectedColor = gameObject.GetComponent<RawImage>().color;
            Debug.Log(SelectedColor);
            Global.SelectedSlider = SelectedColor;
        }
        
        public void GetBallColor() {
            Color SelectedColor = gameObject.GetComponent<RawImage>().color;
            Debug.Log(SelectedColor);
            Global.SelectedBall = SelectedColor;
        }
        
        public void GetPlayerName() {
            string PlayerName = Text.text;
            Debug.Log(PlayerName);
            Global.PlayerName = PlayerName;
        }
        
        
    }
}