using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 10.5f;
    private int enemyCount;
    private int waveNum = 1;

    public TextMeshProUGUI waveText;


    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveNum);
    }

    void SpawnWave(int enemyNum)
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        for (int i = 0; i < enemyNum; i++)
        {
            print("wave number" + i);
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float ZPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, ZPos);
        return spawnPos;
    }

    void WaveNumber()
    {
        //how much ammo does player have
        waveText.text = waveNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        WaveNumber();
        enemyCount = FindObjectsOfType<Enemy>().Length; 
        if (enemyCount == 0)
        {
            
            waveNum++;
            SpawnWave(waveNum);
        }
    }
}
