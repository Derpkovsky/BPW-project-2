using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketScript : MonoBehaviour
{
    //TWEAKABLES
    public float basketEnterRange;
    public float basketEnterSpeed;

    //STATE TRACKERS
    bool inBasket;
    bool clicking;
    public bool closeToBasket;
    Vector3 playerStartPos;


    //OBJECT CACHING
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("FPSController");
        
    }

    void Update()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) <= basketEnterRange)
        {
            closeToBasket = true;
            if (inBasket)
            {
                closeToBasket = false;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.GetComponent<CharacterController>().enabled = false;
                    ExitBasket();
                    player.GetComponent<CharacterController>().enabled = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.GetComponent<CharacterController>().enabled = false;
                    playerStartPos = transform.position;
                    EnterBasket();
                    player.GetComponent<CharacterController>().enabled = true;
                }
            }
        }
        else
        {
            closeToBasket = false;
        }


        /*
        if (clicking)
        {

            float recallSpeedCounter = 1 / basketEnterSpeed;
            while (recallSpeedCounter < 1)
            {
                Debug.Log(transform.position);
                recallSpeedCounter += Time.deltaTime * recallSpeedCounter;
                player.transform.position = Vector3.Lerp(playerStartPos, transform.position - new Vector3(0, 1.4f, 0), recallSpeedCounter * Time.deltaTime);
            }
            clicking = false;
            Debug.Log("niet klikken");
        }
        */
    }


    void EnterBasket()
    {
        inBasket = true;
        // LERP POSITIE NAAR BASKET
        player.transform.position = transform.position - new Vector3(0, 1.4f, 0);
    }

    void ExitBasket()
    {
        inBasket = false;
        //LERP SPELER UIT DE BASKET
        player.transform.position += player.GetComponent<Transform>().GetChild(0).transform.forward * 2;
    }
}

