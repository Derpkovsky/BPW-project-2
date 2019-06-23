using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStoneScript : MonoBehaviour
{
    public float pickupRange = 2.2f;


    public bool isPickedUp;
    public bool isPlaced;
    bool ableToPickup;

    GameObject player;
    GameObject rightHand;
    GameObject windterface;
    RayCastScript lookCheck;
    public GameObject stonePickupImage;

    void Start()
    {
        windterface = GameObject.Find("Windterface");
        player = GameObject.Find("FPSController");
        rightHand = GameObject.Find("RightHand");
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
    }

    void Update()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) <= pickupRange)
        {
            if (lookCheck.stoneHit)
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
                if (!isPickedUp && lookCheck.stoneHit)
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
                        transform.position = windterface.GetComponent<Transform>().position + new Vector3(0, 0.3f, 0);
                        transform.rotation = windterface.GetComponent<Transform>().rotation;
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
    }
}