using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool loops = false;


    IEnumerator Start() {

        do {
            yield return StartCoroutine(spawnAllWaves());
        } while (loops);
        
    }

    private IEnumerator spawnAllWaves() {
        for (int i = startingWave; i < waveConfigs.Count; i++) {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(spawnEnemies(currentWave));
        }
    }

    private IEnumerator spawnEnemies(WaveConfig wave) {
        for (int i = 0; i < wave.getNumEnemies(); i++) {
            var newEnemy = Instantiate(wave.getEnemyPrefab(), wave.getWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<enemyPathing>().setWaveConfig(wave);
            yield return new WaitForSeconds(wave.getTimeBetweenSpawns());
        }
        

        

    }
}
