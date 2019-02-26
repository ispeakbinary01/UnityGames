using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    

    // Configuration Paramaters
    [SerializeField] float widthUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Cached ref
    GameSession autoPos;
    Ball autoBall;


    // Start is called before the first frame update
    void Start() {
        autoPos = FindObjectOfType<GameSession>();
        autoBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos() {
        if (autoPos.IsAutoEnabled()) {
            return autoBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * widthUnits;
        }
    }
}
