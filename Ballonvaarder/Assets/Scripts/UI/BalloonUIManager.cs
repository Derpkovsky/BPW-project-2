using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonUIManager : MonoBehaviour
{

    private GameObject player;
    public GameObject enterBasket;
    public GameObject windterface;
    public GameObject rope;
    InputStoneScript stoneScript;
    RayCastScript lookCheck;
    BasketScript basketScript;

    void Start()
    {
        player = GameObject.Find("FPSController");
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
        basketScript = GameObject.Find("basket").GetComponent<BasketScript>();
        stoneScript = GameObject.Find("inputsteen").GetComponent<InputStoneScript>();
    }

    void Update()
    {
        if (basketScript.closeToBasket)
        {
            enterBasket.SetActive(true);
            enterBasket.transform.LookAt(player.transform);
        }
        else
        {
            enterBasket.SetActive(false);
        }


        if (lookCheck.windterfaceHit && !stoneScript.isPlaced && stoneScript.isPickedUp)
        {
            windterface.SetActive(true);
            //windterface.transform.LookAt(player.transform);
        }
        else 
        {
            windterface.SetActive(false);
        }



            if (lookCheck.ropeHit)
        {
            rope.SetActive(true);
            rope.transform.LookAt(player.transform);
        }
        else
        {
            rope.SetActive(false);
        }
    }
}
