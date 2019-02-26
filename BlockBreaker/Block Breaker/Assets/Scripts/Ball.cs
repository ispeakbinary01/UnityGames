using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    // Config param
    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 2f;
    [SerializeField] float velY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    


    // state
    Vector2 paddleToBall;
    bool hasStared = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D angle;

    // Start is called before the first frame update
    void Start() {
        paddleToBall = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        angle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (hasStared == false) {
            LockBall();
            LaunchBall();
        }
    }

    private void LaunchBall() {
        if (Input.GetMouseButtonDown(0)) {
            angle.velocity = new Vector2(velX, velY);
            hasStared = true;
        }
    }

    private void LockBall() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 veloTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStared) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            angle.velocity += veloTweak;
        }
    }
}

