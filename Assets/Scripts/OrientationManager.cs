using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrientationManager : MonoBehaviour
{
    //for forced orientations during different scenes

    CreatePlayer createPlayerScript;

    private void Awake()
    {
        createPlayerScript = GameObject.Find("PrefabInstatiator").GetComponent<CreatePlayer>();

    }

    private void Start()
    {
       // this.gameObject.SetActive(true);
        if(SceneManager.GetActiveScene().name == "RoomScene" || SceneManager.GetActiveScene().name == "EnvSelection" || SceneManager.GetActiveScene().name == "CloudScene" || SceneManager.GetActiveScene().name == "EnvScene" || SceneManager.GetActiveScene().name == "VoidScene")
        {
            SetLandscape();

            if(SceneManager.GetActiveScene().name == "RoomScene" || SceneManager.GetActiveScene().name == "CloudScene" || SceneManager.GetActiveScene().name == "EnvScene" || SceneManager.GetActiveScene().name == "VoidScene")
            {
                StartCoroutine(createPlayer());
            }
        }

        if (SceneManager.GetActiveScene().name == "Dashboard")
        {
            SetPortrait();
        }

    }
    public void SetLandscape()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    public void SetPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Debug.Log("Potrait");
    }

    
    public void EnableAutoRotation()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    IEnumerator createPlayer()
    {
        yield return new WaitForSeconds(1f);

        createPlayerScript.instantiatePlayer();
        Debug.Log("Player Created");
    }
}
