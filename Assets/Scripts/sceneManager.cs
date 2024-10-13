using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    OrientationManager orientationManagerScript;

    private void Awake()
    {
        orientationManagerScript = GameObject.Find("OrientationManager").GetComponent<OrientationManager>();
    }
    void Start()
    {
        orientationManagerScript.SetLandscape();
    }

    public void changeScene(int i)
    {
        switch(i)
        {
            case 0:
                Debug.Log("void");
                SceneManager.LoadScene("VoidScene");
                break;
            case 1:
                Debug.Log("Room");
                SceneManager.LoadScene("RoomScene");
                break;
            case 2:
                Debug.Log("Cloud");
                SceneManager.LoadScene("CloudScene");
                break;
            case 3:
                Debug.Log("Env");
                SceneManager.LoadScene("EnvScene");
                break;
        }
    }    
}
