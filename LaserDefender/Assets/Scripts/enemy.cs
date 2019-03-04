using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    [SerializeField] float health = 100f;


    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
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
