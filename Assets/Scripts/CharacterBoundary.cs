using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
   
    private float zBoundary = 16;
    private float xBoundary = 31;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //so player doesnt flip 
        Quaternion.Euler(0, transform.rotation.y, 0);


        //prevents character from escaping boundary
        if (transform.position.z > zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary);
            
        }
        else if (transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundary);
            transform.Rotate(0, transform.rotation.y, 0);
        }

        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
            transform.Rotate(0, transform.rotation.y, 0);
        }
        else if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
            transform.Rotate(0, transform.rotation.y, 0);
        }
    }
}
