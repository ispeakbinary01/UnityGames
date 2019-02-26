using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    int max;
    int min;
    int guess;
    // Start is called before the first frame update
    void Start() {
        StartGame();
    }

    void StartGame() {

        max = 1000;
        min = 1;
        guess = 500;

        Debug.Log("Welcome to number wizard!");
        Debug.Log("Pick a number: ");
        Debug.Log("Highest number is: " + max);
        Debug.Log("Lowest number is: " + min);
        Debug.Log("Tell me if your number is higher or lower than: " + guess);
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
        Debug.Log("Guess is " + guess);
        max += 1;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
            Debug.Log("Guess now is " + guess);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
            NextGuess();
            Debug.Log("Guess now is " + guess);
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("LATA BITCH");
            StartGame();
        }
        
    }

    void NextGuess() {
        Debug.Log("Higher or Lower than " + guess + "?");
        guess = (max + min) / 2;
    }
}
