using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] float mintimeShots = 0.2f;
    [SerializeField] float maxTimeShots = 3f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float enemyLaserSpeed = 100f;


    Coroutine enemyFire;


    void Start() {
        shotCounter = Random.Range(mintimeShots, maxTimeShots);
    }

    // Update is called once per frame
    void Update() {
        countdownShoot();
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        damageDealer damageDealer = other.gameObject.GetComponent<damageDealer>();
        healthProccess(damageDealer);
    }

    private void healthProccess(damageDealer damageDealer) {
        health -= damageDealer.getDamage();
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
