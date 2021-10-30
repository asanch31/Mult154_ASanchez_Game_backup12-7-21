using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerCtrl;

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    Rigidbody rgBody = null;
    float trans = 0;
    float rotate = 0;

    private Animator anim;

    private float time = 0;
    private float maxTime = 3;

    private int x;

    private void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();

        rgBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        trans += translation;
        rotate += rotation;

        anim.SetFloat("Movement", translation);
        
        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
        
        
        x = Random.Range(0, 2);
        anim.SetInteger("IdleAnim", x);
        time = 0;
        if (translation<.01 || translation>-.01)
        {
            InvokeRepeating("IdleAnim", 1, 1);
        }
    }


    private void IdleAnim()
    {
        
        //keep track of time while interacting with object(rock sample)
        if (time < maxTime)
        {
            time++;          
        }
        if (time == maxTime)
        {
            
            print(time);
            // idle timer-player does flip
            anim.SetTrigger("IdleTimer");
            time = 0;
            CancelInvoke();
        }
    }
    private void FixedUpdate()
    {
        
        if (playerCtrl.gameOver == false)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot.y += rotate * rotationSpeed * Time.deltaTime;
            rgBody.MoveRotation(Quaternion.Euler(rot));
            rotate = 0;

            Vector3 move = transform.forward * trans;
            rgBody.velocity = move * speed * Time.deltaTime;
            trans = 0;
        }
    }
}


