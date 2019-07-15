using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    GameObject lookCheck;
    public GameObject talkButton;
    public GameObject questText;

    void Start()
    {
        lookCheck = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (lookCheck.GetComponent<RayCastScript>().questGiverHit)
        {
            talkButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("quest");
                questText.SetActive(true);
                StartCoroutine(talkTimer());

            }
        }
        else
        {
            talkButton.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }


    private IEnumerator talkTimer()
    {
        yield return new WaitForSeconds(20);
        questText.SetActive(false);
    }
}
