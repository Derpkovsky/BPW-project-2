using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string leftScene;
    public string rightScene;
    public string topScene;
    public string bottomScene;
    public string upScene;


    GameObject luchtBallon;

    private void Start()
    {
        luchtBallon = GameObject.FindGameObjectWithTag("Balloon");
        if(upScene == null)
        {
            upScene = "SkyArea";
        }
    }


    private void Update()
    {


        if (luchtBallon.transform.position.y > 660)
        {
            SceneManager.LoadScene(upScene);
        }
        if (luchtBallon.transform.position.x > 1000)
        {
            SceneManager.LoadScene(rightScene);
        }
        if (luchtBallon.transform.position.x < 0)
        {
            SceneManager.LoadScene(leftScene);
        }
        if (luchtBallon.transform.position.z > 1000)
        {
            SceneManager.LoadScene(topScene);
        }
        if (luchtBallon.transform.position.z < 0)
        {
            SceneManager.LoadScene(bottomScene);
        }

    }
}
