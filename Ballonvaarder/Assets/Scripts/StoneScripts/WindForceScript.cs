using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForceScript : MonoBehaviour
{
    public float pickupRange = 2.2f;
    public int force;



    GameObject player;
    GameObject rightHand;
    GameObject windterface;
    RayCastScript lookCheck;
    public GameObject stonePickupImage;


    [HideInInspector]
    public float windStrength;
    [HideInInspector]
    public bool isPickedUp;
    [HideInInspector]
    public bool isPlaced;
    [HideInInspector]
    bool ableToPickup;


    void Start()
    {
        windterface = GameObject.FindGameObjectWithTag("Windterface");
        player = GameObject.Find("FPSController");
        rightHand = GameObject.Find("RightHand");
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
    }

    void Update()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) <= pickupRange)
        {
            if (lookCheck.WFStoneHit)
            {
                stonePickupImage.SetActive(!isPickedUp);
                ableToPickup = true;
            }
            else
            {
                stonePickupImage.SetActive(false);
                ableToPickup = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (!isPickedUp && lookCheck.WFStoneHit)
                {
                    transform.position = rightHand.GetComponent<Transform>().position;
                    GetComponent<Collider>().enabled = false;
                    GetComponent<Rigidbody>().isKinematic = true;
                    transform.SetParent(rightHand.GetComponent<Transform>());
                    transform.rotation = rightHand.transform.rotation;
                    isPlaced = false;
                    isPickedUp = true;
                }
                else
                {
                    if (lookCheck.windterfaceHit)
                    {
                        transform.SetParent(windterface.GetComponent<Transform>());
                        GetComponent<Collider>().enabled = true;
                        transform.position = windterface.GetComponent<Transform>().GetChild(3).transform.position;
                        transform.rotation = windterface.GetComponent<Transform>().GetChild(3).transform.rotation;
                        isPlaced = true;
                        isPickedUp = false;
                    }
                    else
                    {
                        GetComponent<Collider>().enabled = true;
                        GetComponent<Rigidbody>().isKinematic = false;
                        transform.SetParent(null);
                        isPickedUp = false;
                    }
                }
            }
        }


        if (isPlaced)
        {
            windStrength = force;
        }
        else
        {
            windStrength = 2f;
        }
    }
}
