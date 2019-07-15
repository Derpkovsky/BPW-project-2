using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHeightScript : MonoBehaviour
{
    public float pickupRange = 2.2f;
    [Range(1, 3)]
    public int height;


    GameObject player;
    GameObject rightHand;
    GameObject windterface;
    RayCastScript lookCheck;
    Transform cloudParent;
    public GameObject stonePickupImage;



    [HideInInspector]
    public bool isPickedUp;
    [HideInInspector]
    public bool isPlaced;
    [HideInInspector]
    public bool ableToPickup;
    Vector3 cloudHeight;
    Vector3 height1;
    Vector3 height2;
    Vector3 height3;



    void Start()
    {
        windterface = GameObject.FindGameObjectWithTag("Windterface");
        player = GameObject.Find("FPSController");
        rightHand = GameObject.Find("RightHand");
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
        cloudParent = GameObject.FindGameObjectWithTag("Clouds").GetComponent<Transform>();
        height1 = new Vector3(0, 100, 0);
        height2 = new Vector3(0, 200, 0);
        height3 = new Vector3(0, 400, 0);
        if (height == 1)
        {
            cloudHeight = height1;
        }
        else if (height == 2)
        {
            cloudHeight = height2;
        }
        else
        {
            cloudHeight = height3;
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) <= pickupRange)
        {
            if (lookCheck.CHStoneHit)
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
                if (!isPickedUp && lookCheck.CHStoneHit)
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
                        transform.position = windterface.transform.Find("CloudHeightPos").transform.position;
                        transform.rotation = windterface.transform.Find("CloudHeightPos").transform.rotation;
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
            cloudParent.position = cloudHeight;
        }
        else
        {
            cloudHeight = height1;
        }
    }
}
