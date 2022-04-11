using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public Text waveText;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i=0;i < enemiesToSpawn;i++)
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave: " + waveNumber;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            if (waveNumber >= 10)
            {
                GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinManager>().win = true;
                GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinManager>().gameOver = true;
            }
            else
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                if(GameObject.FindGameObjectsWithTag("Powerup").Length<=0)
                    SpawnPowerup(1);
            }
        }
    }
}
