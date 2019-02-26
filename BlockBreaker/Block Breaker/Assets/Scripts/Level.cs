using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlock; // for debugging

    // Cached reference
    SceneLoader levelLoader;

    private void Start() {
        levelLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks() {
        breakableBlock++;
    }

    public void BlockDestroyed() {
        breakableBlock--;
        if (breakableBlock <= 0) {
            levelLoader.LoadNextScene();
        }
    }
}
