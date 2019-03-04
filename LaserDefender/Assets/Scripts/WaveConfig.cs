﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> getWaypoints() {
        var waveWaypoints = new List<Transform>();
        foreach (Transform t in pathPrefab.transform) {
            waveWaypoints.Add(t);
        }

        return waveWaypoints;
    }

    public float getTimeBetweenSpawns() {
        return timeBetweenSpawns;
    }

    public float getRandomFactor() {
        return spawnRandomFactor;
    }

    public float getMoveSpeed() {
        return moveSpeed;
    }

    public int getNumEnemies() {
        return numberOfEnemies;
    }
}
