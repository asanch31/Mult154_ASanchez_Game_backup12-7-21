using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    private GameManager playerCtrl;

    //public GameObject weapon;
    public TextMeshProUGUI ammoText;
    public GameObject ammoRefillIndicator;
    public TextMeshProUGUI grenadeText;


    private Animator anim;

    public Rigidbody[] bulletPrefab;
    public Rigidbody grenadePrefab;
    private string[] gunEquip = new string[] {"Pistol"};
    public int bulletIndex = 0;
    public int ammo = 50;
    private int maxAmmo = 200;
    private int reload = 25;

    public int grenadeAmmo = 5;
    private int maxSoundAmount = 5;
    public Vector3 grenadePos;

    
    public int dmg = 1;

    public delegate void GrenadeThrow(Vector3 pos);
    public static event GrenadeThrow GrenadeThrownDown;
    public bool grenadeThrown;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();

        amountAmmo();
        grenadeThrown = false;
    }

    void amountAmmo()
    {
        //how much ammo does player have
        ammoText.text = "Ammo: " + ammo.ToString();
        grenadeText.text = "Grenades: " + grenadeAmmo.ToString();
    }

    void Fire()
    {
        //if player has ammo which bullet prefab is equiped && pick is not equiped
        if (ammo > 0 && playerCtrl.gamePause ==false)
        {
            anim.SetTrigger("Attack"); 
            float bulletSpeed = 25;
            Rigidbody bullet = Instantiate(bulletPrefab[bulletIndex], transform.position + (transform.forward) + new Vector3 (0,1,0), Quaternion.identity);

            bullet.velocity = transform.forward * bulletSpeed;

            //Destroy bullet after 3 secs.
            Destroy(bullet.gameObject, 3f);

            ammo = ammo - 1;
            amountAmmo();
        }
       
    }
    void ThrowGrenade()
    {
        
        if (grenadeAmmo > 0 && grenadeThrown==false && playerCtrl.gamePause == false)
        {
            float grenadeSpeed = 1;
            grenadePos = transform.position + (transform.forward * 10);
            Rigidbody grenade = Instantiate(grenadePrefab, grenadePos, transform.rotation);
            grenade.velocity = transform.forward * grenadeSpeed;

            grenadePos = grenade.transform.position;
            GrenadeThrownDown?.Invoke(grenadePos);
            //Destroy bullet after 5 secs.
            Destroy(grenade.gameObject, 5f);
            StartCoroutine(GrenadeThrown());
            grenadeThrown = true;
            grenadeAmmo = grenadeAmmo - 1;
            amountAmmo();
        }
    }
    IEnumerator GrenadeThrown()
    {
        yield return new WaitForSeconds(5);
        grenadeThrown = false;
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

        if (Input.GetKeyUp(KeyCode.Mouse1) && playerCtrl.gamePause == false)
        {

            ThrowGrenade();

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
        

        ammoRefillIndicator.SetActive(true);
        //increase ammo amount
        ammo = ammo + reload;
        grenadeAmmo = grenadeAmmo + 1;
        //ammo less than or equals ammoMax
        if (ammo> maxAmmo)
        {
            ammo = maxAmmo;

        }
        amountAmmo();

    }

}
