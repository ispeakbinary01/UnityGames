using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    // Config Params
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float health = 200f;
    [Header("Projectile")]
    [SerializeField] GameObject playerLaser;
    [SerializeField] float laserSpeed = 1;
    [SerializeField] float firingPeriod = 0.1f;
    [SerializeField] AudioClip pDeathAudio;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start() {
        SetUpBoundaries();
    }

    

    // Update is called once per frame
    void Update() {
        Move();
        Fire();
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
            AudioSource.PlayClipAtPoint(pDeathAudio, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }



    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }
    IEnumerator FireContinuously() {
        while (true) {
            GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(firingPeriod);
        }
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax); // Delta meaning change/distance.      
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }



    private void SetUpBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    
}
