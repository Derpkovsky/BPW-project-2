using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollow : MonoBehaviour
{

    //When landing on a Platform, add its .transform to this.

    public Transform Platform
    {
        set
        {
            platform = value;
            //When we add a new Platform, get its starting position so our calculations correct
            prePos = platform.transform.position;
        }
        get { return platform; }
    }

    private Transform platform;
    private Vector3 prePos = Vector3.zero;

    void LateUpdate()
    {
        if (platform != null)
        {
            //We are calculating how much the platform moved by subtracting last frame's position, then ADDING it to our player's position.
            transform.position += Platform.position - prePos;
            prePos = Platform.position; //Set prePos for use next frame 
        }
    }
}
