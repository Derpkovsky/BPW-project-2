using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public float pullSpeed;
    public float pullLength;

    Vector3 oldScale;
    Vector3 pulledScale;

    RayCastScript lookCheck;
    GameObject fire1;
    GameObject fire2;

    void Start()
    {
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCastScript>();
        oldScale = transform.localScale;
        pulledScale = transform.localScale - new Vector3(0, -pullLength, 0);
        fire1 = GameObject.Find("Magic fire pro orange");
        fire2 = GameObject.Find("Magic fire pro orange (1)");
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("PULL");
            fire1.SetActive(true);
            fire2.SetActive(true);
            float recallSpeedCounter = 1 / pullSpeed;
            while (recallSpeedCounter < 1)
            {
                recallSpeedCounter += Time.deltaTime * recallSpeedCounter;
                transform.localScale = Vector3.Lerp(transform.localScale, pulledScale, pullSpeed * Time.deltaTime);
            }
        }
        else
        {
            fire1.SetActive(false);
            fire2.SetActive(false);
        }
    }
    private void OnMouseUp()
    {
        transform.localScale = oldScale;
    }
}
