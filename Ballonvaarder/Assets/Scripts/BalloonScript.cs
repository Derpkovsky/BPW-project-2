using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    //tweakables
    public float upForce;
    public float upForceDiminish;



    //state trackers
    private float stableForce = 425;
    GameObject[] stonesPlaced;


    //imports
    Rigidbody playerRB;
    BasketScript basketScript;
    public Rigidbody balloonParent;
    InputStoneScript stoneScript;
    CloudDensityScript cloudDensityScript;
    CloudHeightScript cloudHeightScript;
    WindDirectionScript windDirectionScript;
    WindForceScript windForceScript;
    SunStoneScript sunStoneScript;
    StartStoneScript startStoneScript;



    void Start()
    {
        stoneScript = GameObject.Find("inputsteen").GetComponent<InputStoneScript>();
        cloudDensityScript = GameObject.FindGameObjectWithTag("CloudDensityStone").GetComponent<CloudDensityScript>();
        windDirectionScript = GameObject.FindGameObjectWithTag("WindDirectionStone").GetComponent<WindDirectionScript>();
        windForceScript = GameObject.FindGameObjectWithTag("WindForceStone").GetComponent<WindForceScript>();
        cloudHeightScript = GameObject.FindGameObjectWithTag("CloudHeightStone").GetComponent<CloudHeightScript>();
        sunStoneScript = GameObject.FindGameObjectWithTag("SunStone").GetComponent<SunStoneScript>();
        startStoneScript = GameObject.FindGameObjectWithTag("StartStone").GetComponent<StartStoneScript>();
        playerRB = GameObject.Find("FPSController").GetComponent<Rigidbody>();
        basketScript = GameObject.Find("basket").GetComponent<BasketScript>();
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
        if (startStoneScript.start)
        {
            balloonParent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            balloonParent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //horizontale beweging
            if (windDirectionScript.isPlaced || windForceScript.isPlaced)
            {
                balloonParent.AddForce(windDirectionScript.windDirection * windForceScript.windStrength);
                Debug.Log("windfore is active");
            }
        }
        else
        {
            balloonParent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

    }
}
