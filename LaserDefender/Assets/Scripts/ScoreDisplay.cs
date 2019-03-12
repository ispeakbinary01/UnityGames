using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    Text scoreText;
    GameSession gs;


    void Start() {
        scoreText = GetComponent<Text>();
        gs = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = gs.GetScore().ToString();
    }
}
