using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //how much dmg dopes player do
    private Weapon damage;

    private float fullHealth;
    public float health = 1;

    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        //fullHealth = health;
    }

    private void OnTriggerEnter(Collider other)
    {

        //player interaction with ememy or hazards
        if (other.gameObject.CompareTag("attack"))
        {
            health = 0;
            
            Destroy(other);
            Health();
            print("attack");
            //damage monster

            
        }
    }
        void Health()
        {
            if (health == 0)
            {
            print("attack works");
            Destroy(gameObject);
            print("broken");
        }

        }

        // Update is called once per frame
        void Update()
        {

        }
    
}

