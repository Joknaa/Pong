using System;
using UnityEngine;

namespace GUI {
    public class MainMenuController : MonoBehaviour {
        public PrefabInstentiate prefabInstantiate;
        private void Start() {
            prefabInstantiate.InstantiatePrefabs();
        }
    }
}