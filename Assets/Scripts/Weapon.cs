using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    private GameManager playerCtrl;

    //public GameObject weapon;
    public TextMeshProUGUI ammoText;
    public GameObject ammoIndicator;
    

    public float bulletSpeed = 20;
    public Rigidbody[] bulletPrefab;
    private string[] gunEquip = new string[] {"Pistol"};

    public int bulletIndex = 0;
    public int ammo = 50;
    private int maxAmmo = 200;
    private int reload=25;
    public int dmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (ammo > 0 && playerCtrl.gamePause ==false)
        {
            Rigidbody bullet = Instantiate(bulletPrefab[bulletIndex], transform.position + (transform.forward) + new Vector3 (0,1,0), Quaternion.identity);

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
        //if (playerCtrl.gamePause == false)
        //{
            if (ammo < 0)
            {
                ammo = 0;
            }

        //}
        //rotate weapon by pressing right click (right mouse button) 
        //shot weapon with left click (left mouse button)

        if (Input.GetKeyUp(KeyCode.Mouse0) && playerCtrl.gamePause == false)
        {
            Fire();
           
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ammo"))
        {
            IncAmmo(other.gameObject);

        }
    }
    void IncAmmo(GameObject other)
    {

        Destroy(other.gameObject);
        

        ammoIndicator.SetActive(true);
        //increase ammo amount
        ammo = ammo + reload;
        //ammo less than or equals ammoMax
        if (ammo> maxAmmo)
        {
            ammo = maxAmmo;

        }
        amountAmmo();

    }

}
