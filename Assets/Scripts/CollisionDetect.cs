using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{

    //code not really used 
    //If two object collide (i.e. bullet and enemy} both object are destroyed
    // if player comes in contact with enemy player is moved backwards (in GameConditions more is added)

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -2);
        }

    }
}
