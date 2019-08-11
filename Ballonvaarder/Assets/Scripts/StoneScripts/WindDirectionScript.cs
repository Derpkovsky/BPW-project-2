using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDirectionScript : MonoBehaviour
{
    public float pickupRange = 2.2f;
    [Range(1,3)]
    public int direction;

    GameObject player;
    GameObject rightHand;
    GameObject windterface;
    RayCastScript lookCheck;
    public GameObject stonePickupImage;


    [HideInInspector]
    public Vector3 wind1;
    [HideInInspector]
    public Vector3 wind2;
    [HideInInspector]
    public Vector3 wind3;
    private Vector3 identifier;
    [HideInInspector]
    public Vector3 windDirection;
    [HideInInspector]
    public bool isPickedUp;
    [HideInInspector]
    public bool isPlaced;
    [HideInInspector]
    public bool ableToPickup;


    void Start()
    {
        windterface = GameObject.FindGameObjectWithTag("Windterface");
        player = GameObject.Find("FPSController");
        rightHand = GameObject.Find("RightHand");
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
        wind1 = new Vector3(0, 0, 1);
        wind2 = new Vector3(1, 0, -0.333333333333f);
        wind3 = new Vector3(-1, 0, -0.33333333333f);
        if (direction == 1)
        {
            identifier = wind1;
        }
        else if (direction == 2)
        {
            identifier = wind2;
        }
        else
        {
            identifier = wind3;
        }

    }


    void Update()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) <= pickupRange)
        {
            if (lookCheck.WDStoneHit)
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
                if (!isPickedUp && lookCheck.WDStoneHit)
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
                        transform.position = windterface.transform.Find("WindDirectionPos").transform.position;
                        transform.rotation = windterface.transform.Find("WindDirectionPos").transform.rotation;
                        isPlaced = true;
                        isPickedUp = false;
                    }
                    else
                    {
                        GetComponent<Collider>().enabled = true;
                        GetComponent<Rigidbody>().isKinematic = false;
                        GetComponent<Rigidbody>().AddForce(player.transform.forward * 2);
                        transform.SetParent(null);
                        isPickedUp = false;
                    }
                }
            }
        }

        if (isPlaced)
        {
            windDirection = identifier;
        }
    }
}
