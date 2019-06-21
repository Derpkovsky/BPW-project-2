using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public float upForce;



    GameObject balloonParent;
    void Start()
    {
        balloonParent = GameObject.Find("Luchtballon v.4.4");
    }

    // Update is called once per frame
    void Update()
    {
        balloonParent.GetComponent<Rigidbody>().AddForce(new Vector3(0, upForce, 0));
    }
}
