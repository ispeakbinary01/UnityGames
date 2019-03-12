using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    Text healthText;
    Player healthBar;

    void Start() {
        healthText = GetComponent<Text>();
        healthBar = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update() {
        healthText.text = healthBar.GetHealth().ToString();
    }
}
