using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBasketImage : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
