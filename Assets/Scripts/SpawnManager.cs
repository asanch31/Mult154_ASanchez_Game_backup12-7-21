using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    //difficulty, waves before boss
    public int difficulty = 5;

    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public GameObject[] powerUpPrefab;

    //spawning boundaries
    private float spawnRangeX = 24.0f;
    private float spawnRangeZ = 11.5f;
    //safe area for player, enemies wont spawn
    private float safeArea = 5;
    private int enemyCount;
    public int waveNum = 1;
    public int enemySpawns = 1;

    public TextMeshProUGUI waveText;

    //audio source sounds
    private AudioSource ASPlayer;
    
    public AudioClip bossSpawn;

    // Start is called before the first frame update
    void Start()
    {
        ASPlayer = GetComponent<AudioSource>();
        SpawnWave(waveNum);
    }

    void SpawnWave(int enemyNum)
    {
        SpawnPowerup();

        //after all current enemies all defeated move to next wave
        for (int i = 0; i < enemyNum; i++)
        {
            
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        //create spawn position
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float ZPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        //if spawn position is within safe area, create new spawn position
        while (xPos > -safeArea && xPos < safeArea && ZPos > -safeArea && ZPos < safeArea)
        {
            xPos = Random.Range(-spawnRangeX, spawnRangeX);
            ZPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        }
        //spawn enemy pos.
            Vector3 spawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, ZPos);
            return spawnPos;
        
        
        }


    void WaveNumber()
    {
        //how much ammo does player have
        waveText.text = waveNum.ToString();
    }

    void SpawnPowerup ()
    {
        int randomUP = Random.Range(0, powerUpPrefab.Length);
        
        //spawn powerup
        GameObject powerup=Instantiate(powerUpPrefab[randomUP], GenerateSpawnPosition(), powerUpPrefab[randomUP].transform.rotation);

        //
        //Destroy powerup after 20 secs.
        Destroy(powerup, 20f);

    }

    // Update is called once per frame
    void Update()
    {
        WaveNumber();
        enemyCount = FindObjectsOfType<Enemy>().Length; 
        if (enemyCount == 0)
        {
            
            waveNum++;
            enemySpawns++;
            
            if (enemySpawns==difficulty)
            {
                ASPlayer.PlayOneShot(bossSpawn, 1.0f);
                int numBoss = waveNum / difficulty;
                
                while (numBoss >= 1)
                {
                    //after 10 (current 3;testing reasons) rounds summon boss
                    Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
                    numBoss--;
                    SpawnWave(numBoss);
                    
                    enemySpawns = 0;
                    
                }

            }
            SpawnWave(enemySpawns);
        }
    }
}
