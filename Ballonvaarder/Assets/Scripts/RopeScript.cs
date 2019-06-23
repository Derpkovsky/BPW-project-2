using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    //tweakables
    public float pullSpeed;
    public float pullLength;
    public float heightGain;


    // state managers
    Vector3 oldScale;
    Vector3 pulledScale;


    // imports
    RayCastScript lookCheck;
    BalloonScript balloonScript;
    GameObject fire1;
    GameObject fire2;





    void Start()
    {
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
        oldScale = transform.localScale;
        pulledScale = transform.localScale - new Vector3(0, -pullLength, 0);
        fire1 = GameObject.Find("FireLeft");
        fire2 = GameObject.Find("FireRight");
        balloonScript = GameObject.Find("balloon").GetComponent<BalloonScript>();
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && lookCheck.ropeHit)
        {
            balloonScript.upForce += heightGain;
            Debug.Log("PULL");
            fire1.SetActive(true);
            fire2.SetActive(true);
            float recallSpeedCounter = 1 / pullSpeed;
            while (recallSpeedCounter < 1)
            {
                recallSpeedCounter += Time.deltaTime * recallSpeedCounter;
                transform.localScale = Vector3.Lerp(transform.localScale, pulledScale, pullSpeed * Time.deltaTime);
            }
        }
        else
        {
            fire1.SetActive(false);
            fire2.SetActive(false);
            transform.localScale = oldScale;
        }
    }
}
