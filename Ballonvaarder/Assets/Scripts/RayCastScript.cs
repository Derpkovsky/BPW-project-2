using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [HideInInspector]
    public bool windterfaceHit;
    [HideInInspector]
    public bool burnRopeHit;
    [HideInInspector]
    public bool ventRopeHit;
    float stoneDistanceCheck = 5f;


    public bool stoneHit;
    public bool CDStoneHit;
    public bool CHStoneHit;
    public bool WDStoneHit;
    public bool WFStoneHit;
    public bool SunStoneHit;
    public bool StartStoneHit;



    GameObject windterface;
    Collider burnRope;
    Collider ventRope;

    Collider stone;
    Collider CDStone;
    Collider CHStone;
    Collider WDStone;
    Collider WFStone;
    Collider SunStone;
    Collider StartStone;

    Ray ray;
    RaycastHit hit;


    private void Start()
    {
        windterface = GameObject.FindGameObjectWithTag("Windterface");
        burnRope = GameObject.FindGameObjectWithTag("BurnRope").GetComponent<Collider>();
        ventRope = GameObject.FindGameObjectWithTag("VentRope").GetComponent<Collider>();
        stone = GameObject.Find("inputsteen").GetComponent<Collider>();
        CDStone = GameObject.FindGameObjectWithTag("CloudDensityStone").GetComponent<Collider>();
        CHStone = GameObject.FindGameObjectWithTag("CloudHeightStone").GetComponent<Collider>();
        WDStone = GameObject.FindGameObjectWithTag("WindDirectionStone").GetComponent<Collider>();
        WFStone = GameObject.FindGameObjectWithTag("WindForceStone").GetComponent<Collider>();
        SunStone = GameObject.FindGameObjectWithTag("SunStone").GetComponent<Collider>();
        StartStone = GameObject.FindGameObjectWithTag("StartStone").GetComponent<Collider>();
    }


    void Update()
    {
        ray = new Ray(transform.position, transform.forward);


        //Windterface check
        if (windterface.GetComponent<Collider>().Raycast(ray, out hit, 1.7f))
        {
            windterfaceHit = true;
        }
        else
        {
            windterfaceHit = false;
        }


        //Burnrope check
        if (burnRope.Raycast(ray, out hit, 1.5f))
        {
            burnRopeHit = true;
        }
        else
        {
            burnRopeHit = false;
        }


        if (ventRope.Raycast(ray, out hit, 1.5f))
        {
            ventRopeHit = true;
        }
        else
        {
            ventRopeHit = false;
        }


        //Standaard steen check
        if (stone.Raycast(ray, out hit, 10))
        {
            stoneHit = true;
        }
        else
        {
            stoneHit = false;
        }


        //Cloud Density steen check
        if (CDStone.Raycast(ray, out hit, stoneDistanceCheck))
        {
            CDStoneHit = true;
        }
        else
        {
            CDStoneHit = false;
        }


        //Cloud Height steen check
        if (CHStone.Raycast(ray, out hit, stoneDistanceCheck))
        {
            CHStoneHit = true;
        }
        else
        {
            CHStoneHit = false;
        }


        //Wind Direction steen check
        if (WDStone.Raycast(ray, out hit, stoneDistanceCheck))
        {
            WDStoneHit = true;
        }
        else
        {
            WDStoneHit = false;
        }


        //Wind Force steen check
        if (WFStone.Raycast(ray, out hit, stoneDistanceCheck))
        {
            WFStoneHit = true;
        }
        else
        {
            WFStoneHit = false;
        }


        //Sun steen check
        if (SunStone.Raycast(ray, out hit, stoneDistanceCheck))
        {
            SunStoneHit = true;
        }
        else
        {
            SunStoneHit = false;
        }


        //Start steen check
        if (StartStone.Raycast(ray, out hit, stoneDistanceCheck))
        {
            StartStoneHit = true;
        }
        else
        {
            StartStoneHit = false;
        }

    }
}
