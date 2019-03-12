using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    [Header("Enemy Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 100;

    [Header("Shooting")]
    float shotCounter;
    [SerializeField] float mintimeShots = 0.2f;
    [SerializeField] float maxTimeShots = 3f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float enemyLaserSpeed = 100f;

    [Header("SoundFX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathTimer = 1f;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] AudioClip laserAudio;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.7f;



    Coroutine enemyFire;


    void Start() {
        shotCounter = Random.Range(mintimeShots, maxTimeShots);
    }

    // Update is called once per frame
    void Update() {
        countdownShoot();
    }

    private void deathSound() {
        
    }

    private void countdownShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            Fire();
            shotCounter = Random.Range(mintimeShots, maxTimeShots);
        } 
    }

    private void Fire() {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
        AudioSource.PlayClipAtPoint(laserAudio, Camera.main.transform.position, deathVolume);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        damageDealer damageDealer = other.gameObject.GetComponent<damageDealer>();
        if (!damageDealer) {
            return;
        }
        healthProccess(damageDealer);
    }

    private void healthProccess(damageDealer damageDealer) {
        health -= damageDealer.getDamage();
        damageDealer.hit();
        if (health <= 0) {
            AudioSource.PlayClipAtPoint(deathAudio, Camera.main.transform.position);
            die();
        }
    }

    private void die() {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, deathTimer);
    }
}
