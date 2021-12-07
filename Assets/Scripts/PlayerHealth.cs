using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public int health = 30;
    public int maxHealth = 30;
   
    private int mxHealthBoost = 5;

    public GameObject powerIndicator;
    public GameObject healthBuffUI;

    //audio control
    private AudioSource ASPlayer;
    public AudioClip zombieBite;
    //was supplyDropped called
    private GameManager supplyDrop;
    //what weapon is player using
    private Weapon playerWeapon;

    public TextMeshProUGUI healthText;

    public bool gameOver = false;
    private Animator enemyAnim;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = GameObject.Find("Player").GetComponent<Weapon>();
        ASPlayer = GetComponent<AudioSource>();
        supplyDrop =  GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();

        //Player health
        Health();
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        enemyAnim = other.GetComponent<Animator>();

        //player interaction with ememy or hazards
        if (other.gameObject.CompareTag("Enemy"))
            
        {
            //player is attack
            ASPlayer.PlayOneShot(zombieBite, 1.0f);
            enemyAnim.SetTrigger("Attack");
            health = health - 1;
            if (gameOver == false)
            {
                transform.Translate(Vector3.forward * -1);
            }

            Health();
        }
        if (other.gameObject.CompareTag("Boss"))

        {
            enemyAnim.SetTrigger("Attack");
            
            health = health - 1;
            transform.Translate(Vector3.forward * -1);
            Health();
        }

        //if player interacts with health potion
        if (other.CompareTag("health"))
        {
            HealthBuff(other.gameObject);

        }
    }
  
    
    void Health()
    {
        healthBar.fillAmount = (float)health / maxHealth;

        healthText.text = health.ToString() + " / " + maxHealth.ToString();

   
        //player is dead
        if (health <= 0)
        {
            
            health = 0;
            gameOver = true;
            anim.SetBool("Dead", true);
            print("dead");
            

        }
    }
    void HealthBuff(GameObject other)
    {

        other.SetActive(false);

        maxHealth = maxHealth + mxHealthBoost;
        powerIndicator.SetActive(true);
        //increase health 
        health = health + maxHealth / 2;
        //if health goes above maxhealth turn on Buff icon
        if (health > maxHealth)
        {
            health = maxHealth;

        }

        //maxHealth receives small boost with each potion, boost is permanent
        
        Health();

        //start timer for how long powerup last
        StartCoroutine(PowerUpCountdown());
    }
    // Update is called once per frame
    void Update()
    {
        Health(); 

        //lose health if supply dropped called
        if (supplyDrop.supplyDropped ==true)
        {
            health = health - 5;
            Health();
        }
        
        if (transform.position.y < -3)
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(20);

        //health increase for 20 secs if potion buff is acquired
        //after 20 secs stats return to maxHealth if health has more than maxhealth
        healthBuffUI.SetActive(false);
        powerIndicator.SetActive(false);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        Health();
    }

}
