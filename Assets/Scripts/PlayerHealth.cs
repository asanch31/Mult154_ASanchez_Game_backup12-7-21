using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{

    public float health = 30;
    //what weapon is player using
    private Weapon playerWeapon;

    public TextMeshProUGUI healthText;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = GameObject.Find("Player").GetComponent<Weapon>();
        //Player health
        Health();
        HealthText();
    }

    void HealthText()
    {
        //how much ammo does player have
        healthText.text = "Health: " + health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {

        //player interaction with ememy or hazards
        if (other.gameObject.CompareTag("Enemy"))
            print("enemy attack");
        {
            health = health - 1;
            Health();
        }
    }
    void Health()
    {
        HealthText();
        //player is dead
        if (health <= 0 && gameOver == false)
        {
            print("Game Over");

            gameOver = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        HealthText();
    }
}
