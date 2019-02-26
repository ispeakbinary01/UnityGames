﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


    public void LoadNextScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void GetFirstScene() {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().destroyScore();
    }

    public void OnApplicationQuit() {
        Application.Quit();
    }
}