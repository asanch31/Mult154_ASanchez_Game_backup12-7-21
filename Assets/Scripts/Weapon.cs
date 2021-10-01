using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    private PlayerHealth playerCtrl;

    public GameObject weapon;
    public TextMeshProUGUI ammoText;

    public float bulletSpeed = 10;
    public Rigidbody[] bulletPrefab;
    private string[] gunEquip = new string[] {"Pistol"};

    public int bulletIndex = 0;
    public int ammo = 150;
    public int dmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerHealth>();
        amountAmmo();
    }

    void amountAmmo()
    {
        //how much ammo does player have
        ammoText.text = "Ammo: " + ammo.ToString();
    }

    void Fire()
    {
        //if player has ammo which bullet prefab is equiped && pick is not equiped
        if (ammo > 0)
        {
            Rigidbody bullet = Instantiate(bulletPrefab[bulletIndex], transform.position + (transform.forward) + (transform.up), Quaternion.identity);

            bullet.velocity = transform.forward * bulletSpeed;

            //Destroy bullet after 3 secs.
            Destroy(bullet.gameObject, 3f);

            ammo = ammo - 1;
            amountAmmo();
        }
    }
    void Update()
    {
        // Update is called once per frame
        if (playerCtrl.gameOver == false)
        {
            if (ammo < 0)
            {
                ammo = 0;
            }

        }
        //rotate weapon by pressing right click (right mouse button) 
        //shot weapon with left click (left mouse button)

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Fire();
           
        }


    }
    
}
