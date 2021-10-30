using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    //how much dmg dopes player do
    private Weapon damage;
    private SpawnManager waveNum;
    private int difficulty;

    //private float fullHealth;
    private float health = 2;

    public bool dead = false;
    private Animator anim;

    


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        waveNum = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        difficulty = waveNum.difficulty;
        int incDif = waveNum.waveNum / waveNum.difficulty;


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

        }
        if (other.gameObject.CompareTag("DMG"))
        {
            
            health--;
            Health();
        }
    }
    void Health()
    {
        if (health == 0)
        {
            anim.SetBool("Dead", true);
            StartCoroutine(DeathAnim());

        }

    }
    IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);


    }
    // Update is called once per frame
    void Update()
    {
    
    }

}
