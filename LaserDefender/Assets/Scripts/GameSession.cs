﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;
    int health = 200;

    private void Awake() {
        SetUpSingleton();
    }

    private void SetUpSingleton() {
        int gameSessionsNum = FindObjectsOfType(GetType()).Length;
        if (gameSessionsNum > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }


    public int GetScore() {
        return score;
    }

    public int GetHealth() {
        return health;
    }

    public void AddToScore(int scoreValue) {
        score += scoreValue;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}