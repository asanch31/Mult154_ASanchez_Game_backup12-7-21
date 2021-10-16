using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    //how much dmg dopes player do
    private Weapon damage;
    private SpawnManager waveNum;
    private int difficulty;

    //private float fullHealth;
    private float health = 1;

    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
       

        waveNum = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
        //retrieve difficulty var from spawnmanager
        difficulty = waveNum.difficulty;
        int incDif = waveNum.waveNum / difficulty;
        

        health = health + (health * incDif);
        
        //fullHealth = health;
    }

    private void OnTriggerEnter(Collider other)
    {

        //player interaction with enemy or hazards
        if (other.gameObject.CompareTag("attack"))
        {
            health--;
            
            Destroy(other.gameObject);
            Health();
           
            //damage monster

            
        }
    }
    private void onTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("DMGBarrier"))
        {
            health--;
        }
    }
        void Health()
        {
        
            if (health == 0)
            {
         
            Destroy(gameObject);
            
            }

        }

        // Update is called once per frame
        void Update()
        {
       
        
        }
    
}

