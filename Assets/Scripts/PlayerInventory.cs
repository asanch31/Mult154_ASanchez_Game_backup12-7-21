using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    private int barrier1, barrier2, barrier3, barrier4;
    public GameObject[] barrier;
    public TextMeshProUGUI [] barrierText;

    private int arrayLength = 3;



    // Start is called before the first frame update
    void Start()
    {
        barrier1 = 1;

    }
    // Update is called once per frame
    void Update()
    {
        PlaceBarrier();
        barrierText[0].text = "ConcreteWall: " + barrier1;
        barrierText[1].text = "SandBags: " + barrier2;
        barrierText[2].text = "PlankWall: " + barrier3;
        barrierText[3].text = "BarbedWireWall: " + barrier4;

    }
    void PlaceBarrier()
    {
        if (barrier1 > 0)
        {
            if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1))
            {

                Instantiate(barrier[0], transform.position + (transform.forward * 2), transform.rotation);
                barrier1--;
            }
        }

        if (barrier2 > 0)
        {
            if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.Alpha2))
            {

                Instantiate(barrier[1], transform.position + (transform.forward * 2), transform.rotation);
                barrier2--;
            }
        }
        if (barrier3 > 0)
        {
            if (Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp(KeyCode.Alpha3))
            {

                Instantiate(barrier[2], transform.position + (transform.forward * 2), transform.rotation);
                barrier3--;
            }
        }
        if (barrier4 > 0)
        {
            if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.Alpha4))
            {

                Instantiate(barrier[3], transform.position + (transform.forward * 2), transform.rotation);
                barrier4--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //player interaction with barrier powerups
        if (other.gameObject.CompareTag("b1"))
        {
            print("POWERUP WALL)");
            barrier1++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("b2"))
        {
            print("POWERUP WALL)");
            barrier2++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("b3"))
        {
            print("POWERUP WALL)");
            barrier3++;
            Destroy(other.gameObject);
        }


        //if player interacts with barbedwire potion
        if (other.CompareTag("b4"))
        {
            print("POWERUP WALL)");
            barrier4++;
            Destroy(other.gameObject);
        }
    }

}
