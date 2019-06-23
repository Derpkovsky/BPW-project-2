using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    //tweakables
    public float upForce;
    public float upForceDiminish;



    //state trackers
    private float stableForce = 417;


    //imports
    public Rigidbody balloonParent;
    InputStoneScript stoneScript;
    CloudDensityScript cloudDensityScript;
    WindDirectionScript windDirectionScript;
    WindForceScript windForceScript;



    void Start()
    {
        stoneScript = GameObject.Find("inputsteen").GetComponent<InputStoneScript>();
        cloudDensityScript = GameObject.FindGameObjectWithTag("CloudDensityStone").GetComponent<CloudDensityScript>();
        windDirectionScript = GameObject.FindGameObjectWithTag("WindDirectionStone").GetComponent<WindDirectionScript>();
        windForceScript = GameObject.FindGameObjectWithTag("WindForceStone").GetComponent<WindForceScript>();
    }




    void Update()
    {

        //verticale beweging
        balloonParent.AddForce(transform.up * upForce);
        if (upForce > stableForce)
        {

            float recallSpeedCounter = 1 / upForceDiminish;
            while (recallSpeedCounter < 1)
            {
                recallSpeedCounter += Time.deltaTime * recallSpeedCounter;
                upForce = Mathf.Lerp(upForce, stableForce, upForceDiminish * Time.deltaTime);
            }
        }


        //horizontale beweging
        if (windDirectionScript.isPlaced || windForceScript.isPlaced)
        {
            balloonParent.AddForce(windDirectionScript.windDirection * windForceScript.windStrength);
        }

    }
}
