using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDurability : MonoBehaviour
{
    private float durability = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(durability <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))

        {
            durability = durability - 1;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))

        {
            durability = durability - .1f;
            
        }
    }
}
