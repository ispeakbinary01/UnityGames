using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints;
    
    int waypointIndex = 0;

    private void Start() {
        waypoints = waveConfig.getWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update() {
        Move();
    }

    public void setWaveConfig(WaveConfig wave) {
        this.waveConfig = wave;
    }

    private void Move() {
        if (waypointIndex <= waypoints.Count - 1) {
            var targetPos = waypoints[waypointIndex].transform.position;
            var frameSpeed = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, frameSpeed);

            if (transform.position == targetPos) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
