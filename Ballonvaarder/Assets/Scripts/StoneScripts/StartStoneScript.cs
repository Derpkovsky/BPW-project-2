using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStoneScript : MonoBehaviour
{
    public float pickupRange = 2.2f;


    GameObject player;
    GameObject rightHand;
    GameObject windterface;
    RayCastScript lookCheck;
    public GameObject stonePickupImage;


    [HideInInspector]
    public bool start;
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
            if (lookCheck.StartStoneHit)
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
                if (!isPickedUp && lookCheck.StartStoneHit)
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
                        transform.position = windterface.transform.Find("StartStonePos").transform.position;
                        transform.rotation = windterface.transform.Find("StartStonePos").transform.rotation;
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
            start = true;
        }
        else
        {
            start = false;
        }
    }
}
