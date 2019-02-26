using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    // Config params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlay;

    // State vars
    [SerializeField] int playerScore = 0;


    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        scoreText.text = playerScore.ToString();
    }


    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
    }

    public void addToScore() {
        playerScore += pPerBlock;
        scoreText.text = playerScore.ToString();
    }

    public void destroyScore() {
        Destroy(gameObject);
    }

    public bool IsAutoEnabled() {
        return isAutoPlay;
    }
}
