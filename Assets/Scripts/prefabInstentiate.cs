using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PrefabInstentiate : MonoBehaviour {
    public GameObject SliderPrefab;
    public GameObject SliderParent;
    public GameObject BallPrefab;
    public GameObject BallParent;

    private static Dictionary<int, Sprite> SliderImages = new Dictionary<int, Sprite>();
    private static Dictionary<int, Sprite> BallImages = new Dictionary<int, Sprite>();

    public void InstantiatePrefabs() {
        Sprite[ ] Images = Resources.LoadAll("", typeof(Sprite)).Cast<Sprite>().ToArray();

        for (int i = 0; i < Images.Length; i++) {
            GameObject NewSliderPrefab = InstantiatePrefab(SliderPrefab, SliderParent);
            GameObject NewBallPrefab = InstantiatePrefab(BallPrefab, BallParent);

            NewSliderPrefab.GetComponent<Image>().sprite = Sprite.Create(
                SetupSliderTexture(Images[i]),
                new Rect(0, 0, 200, 40),
                Vector2.one * 0.5f);
            NewBallPrefab.GetComponent<Image>().sprite = Sprite.Create(
                SetupBallTexture(Images[i]),
                new Rect(0, 0, 40, 40),
                Vector2.one * 0.5f);


            SliderImages.Add(NewSliderPrefab.GetInstanceID(), Images[i]);
            BallImages.Add(NewBallPrefab.GetInstanceID(), Images[i]);
        }

    }

    private GameObject InstantiatePrefab(GameObject Prefab, GameObject Parent) {
        GameObject InstantiatedPrefab = Instantiate(Prefab, new Vector3(0, 0, 0), Quaternion.identity);
        InstantiatedPrefab.transform.SetParent(Parent.transform);
        InstantiatedPrefab.GetComponent<RectTransform>().localScale = Vector3.one;

        return InstantiatedPrefab;
    }

    private Texture2D SetupSliderTexture(Sprite Image) {
        Texture2D ImageTexture = Image.texture;
        Texture2D PrefabTexture = new Texture2D(200, 40);

        for (var i = 0; i < PrefabTexture.width; i++)
            for (var j = 0; j < PrefabTexture.height; j++)
                PrefabTexture.SetPixel(i, j, ImageTexture.GetPixel(i, j));

        PrefabTexture.Apply();
        return PrefabTexture;
    }
    private Texture2D SetupBallTexture(Sprite Image) {
        Texture2D ImageTexture = Image.texture;
        Texture2D PrefabTexture = new Texture2D(40, 40);
        int radius = 20;
        int rSquared = radius * radius;

        for (int u = 20 - radius; u < 20 + radius + 1; u++) {
            for (int v = 20 - radius; v < 20 + radius + 1; v++) {
                if ((20 - u) * (20 - u) + (20 - v) * (20 - v) < rSquared)
                    PrefabTexture.SetPixel(u, v, ImageTexture.GetPixel(u, v));
                else
                    PrefabTexture.SetPixel(u, v, new Color(0, 0, 0, 0));
            }
        }

        PrefabTexture.Apply();
        return PrefabTexture;
    }

    public static Sprite GetTextureFromSliderPrefab(int sliderID) {
        Debug.Log(SliderImages.Values.Count);
        return SliderImages[sliderID];
    }

    public static Sprite GetTextureFromBallPrefab(int ballID) {
        return BallImages[ballID];
    }
}