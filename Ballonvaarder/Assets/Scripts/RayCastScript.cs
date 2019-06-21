using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    public bool windterfaceHit;
    public bool ropeHit;
    public bool stoneHit;

    Collider windterface;
    Collider burnRope;
    Collider stone;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        windterface = GameObject.Find("curve2").GetComponent<Collider>();
        burnRope = GameObject.Find("BurnRope").GetComponent<Collider>();
        stone = GameObject.Find("inputsteen").GetComponent<Collider>();
    }


    void Update()
    {
        ray = new Ray(transform.position, transform.forward);


        if (windterface.Raycast(ray, out hit, 1.7f))
        {
            Debug.Log("Windterface seen");
            windterfaceHit = true;
        }
        else
        {
            windterfaceHit = false;
        }


        if (burnRope.Raycast(ray, out hit, 1.5f))
        {
            ropeHit = true;
        }
        else
        {
            ropeHit = false;
        }

        if (stone.Raycast(ray, out hit, 10))
        {
            stoneHit = true;
        }
        else
        {
            stoneHit = false;
        }
    }
}
