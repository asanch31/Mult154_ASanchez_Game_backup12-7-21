using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    private float minX, maxX, minZ, maxZ;

    
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
        minX = bottomCorner.x+1;
        maxX = topCorner.x-1;
        minZ = bottomCorner.z+1;
        maxZ = topCorner.z-1;
        
        
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
