using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour {

    // Config params
    [SerializeField] AudioClip breakingSound;
    [SerializeField] GameObject blockParticle;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;

    // State variables
    [SerializeField] int timesHit; // SF for debug purposes


    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits) {
                DestroyBlock();
            } else {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite() {
        if (timesHit != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        } else {
            Debug.LogError("Block sprite is missing from array! Problem is " + gameObject.name);
        }
    }

    private void DestroyBlock() {
        BreakSound();
        Destroy(gameObject);
        level.BlockDestroyed();
        triggerSparkles();
    }

    private void BreakSound() {
        FindObjectOfType<GameSession>().addToScore();
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
    }

    private void triggerSparkles() {
        GameObject sparkles = Instantiate(blockParticle, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
