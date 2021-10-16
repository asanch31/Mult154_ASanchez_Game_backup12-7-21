using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerCtrl;
   
    private Rigidbody rbPlayer;

    float verticalInput;


    public float speed = 15.0f;
    public float turnSpeed = 400.0f;
  



    void Start()
    {

       

        playerCtrl = GameObject.Find("Player").GetComponent<PlayerHealth>();



        rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        


    }
    
}
