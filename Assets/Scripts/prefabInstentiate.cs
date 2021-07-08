using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class prefabInstentiate : MonoBehaviour {
    public GameObject myPrefab;
    public GameObject Parent;
    public SpriteRenderer spriteRenderer;
    private Texture2D ImageTexture;

    private List<GameObject> InstantiatedPrefabsList = new List<GameObject>();
    private Texture2D NewTexture;

    public void LoadPrefab() {
        Sprite[] Images = Resources.LoadAll("", typeof(Sprite)).Cast<Sprite>().ToArray();

        foreach (Sprite Image in Images) {
            GameObject InstantiatedPrefab = InstantiatePrefab();

            SetupTexture(Image);

            InstantiatedPrefab.GetComponent<Image>().sprite = Sprite.Create(NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height),
                Vector2.one * 0.5f);
        }
    }

    private GameObject InstantiatePrefab() {
        GameObject InstantiatedPrefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
        InstantiatedPrefab.transform.SetParent(Parent.transform);
        InstantiatedPrefab.GetComponent<RectTransform>().localScale = Vector3.one;
        InstantiatedPrefabsList.Add(InstantiatedPrefab);
        return InstantiatedPrefab;
    }

    private void SetupTexture(Sprite Image) {
        ImageTexture = Image.texture;
        NewTexture = new Texture2D(16, 118);
        for (var i = 0; i < NewTexture.width; i++) {
            for (var j = 0; j < NewTexture.height; j++) NewTexture.SetPixel(i, j, ImageTexture.GetPixel(i, j));
        }
        NewTexture.Apply();
    }
}