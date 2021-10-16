using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    private float minX, maxX, minZ, maxZ;

    private float zWallBoundary = 16;
    private float xWallBoundary = 31;
    // Start is called before the first frame update
    void Start()
    {
        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector3 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        //print(Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance)));
        

        //set boundaries based on screen size
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minZ = bottomCorner.z;
        maxZ = topCorner.z;
        
        //if screen is wider/higher than wall set boundary to walls 
        if (maxX > xWallBoundary)
        {
            maxX = xWallBoundary;
            minX = -xWallBoundary;
        }
        if(maxZ > zWallBoundary)
        {
            maxZ = zWallBoundary;
            minZ = zWallBoundary;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) 
            pos.x = minX;
        if (pos.x > maxX) 
            pos.x = maxX;

        // vertical contraint
        if (pos.z < minZ) 
            pos.z = minZ;
        if (pos.z > maxZ) 
            pos.z = maxZ;

        // Update position
        transform.position = pos;

    }
}
