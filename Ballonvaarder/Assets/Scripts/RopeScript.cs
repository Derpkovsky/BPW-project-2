using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    //tweakables
    public float pullSpeed;
    public float pullLength;
    public float heightGain;
    public float heightLoss;


    // state managers
    Vector3 oldBurnScale;
    Vector3 oldVentScale;
    Vector3 pulledScale;


    // imports
    RayCastScript lookCheck;
    BalloonScript balloonScript;
    GameObject fire1;
    GameObject fire2;
    GameObject ventRope;





    void Start()
    {
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();

        pulledScale = transform.localScale - new Vector3(0, -pullLength, 0);
        fire1 = GameObject.Find("FireLeft");
        fire2 = GameObject.Find("FireRight");
        balloonScript = GameObject.Find("balloon").GetComponent<BalloonScript>();
        ventRope = GameObject.FindGameObjectWithTag("VentRope");
        oldBurnScale = transform.localScale;
        oldVentScale = ventRope.transform.localScale;
    }



    private void Update()
    {

        if (lookCheck.burnRopeHit && Input.GetKey(KeyCode.Mouse0))
        {

            balloonScript.upForce += heightGain;
            // play burn sound
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
            // stop burn sound
            transform.localScale = oldBurnScale;
        }




        if (lookCheck.ventRopeHit && Input.GetKey(KeyCode.Mouse0))
        {
            //play vent sound
            balloonScript.upForce -= heightLoss;
            float recallSpeedCounter = 1 / pullSpeed;
            while (recallSpeedCounter < 1)
            {
                recallSpeedCounter += Time.deltaTime * recallSpeedCounter;
                ventRope.transform.localScale = Vector3.Lerp(ventRope.transform.localScale, pulledScale, pullSpeed * Time.deltaTime);
            }
        }
        else
        {
            //stop vent sound
            ventRope.transform.localScale = oldVentScale;
        }
    }
}
