using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketScript : MonoBehaviour
{
    //TWEAKABLES
    public float basketEnterRange;
    public float basketEnterSpeed;

    //STATE TRACKERS
    public bool inBasket;
    bool clicking;
    public bool closeToBasket;
    bool moveFrozenY;
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
                    ExitBasket();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    EnterBasket();
                }
            }
        }
        else
        {
            closeToBasket = false;
        }

        if (moveFrozenY)
        {
            //player.GetComponent<Transform>().SetParent(transform);
        }


        /*
        if (clicking)
        {
            playerStartPos = transform.position;
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
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlatformFollow>().Platform = transform;
        //player.GetComponent<Rigidbody>().isKinematic = false;
        //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        //moveFrozenY = true;
        inBasket = true;
        player.transform.position = transform.position - new Vector3(0, 1.4f, 0);
        player.GetComponent<CharacterController>().enabled = true;
    }

    void ExitBasket()
    {
        player.GetComponent<CharacterController>().enabled = false;
        //player.GetComponent<Rigidbody>().isKinematic = true;
        inBasket = false;
        player.transform.position += player.GetComponent<Transform>().GetChild(0).transform.forward * 3;
        player.GetComponent<CharacterController>().enabled = true;
    }
}

