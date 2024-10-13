using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    GameObject successPanel, failurePanel, processingPanel, dialogTextPanel;
    private Coroutine vrChangeCoroutine;

    SceneTracker sceneTrackerScript;

    //to track progress
    private void Awake()
    {
        successPanel = GameObject.Find("Success");
        failurePanel = GameObject.Find("Failed");
        processingPanel = GameObject.Find("Processing");
        dialogTextPanel = GameObject.Find("DialogBoxGrp");
        sceneTrackerScript = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
    }

    private void Start()
    {
        successPanel.SetActive(false);
        failurePanel.SetActive(false);
        processingPanel.SetActive(false);

        activatePanel(0);

        if(sceneTrackerScript.LastScene== "CloudScene" || sceneTrackerScript.LastScene == "EnvSelection" || sceneTrackerScript.LastScene == "EnvScene" || sceneTrackerScript.LastScene == "RoomScene" || sceneTrackerScript.LastScene == "VoidScene")
        {
            activatePanel(2);
        }
    }

    public void activatePanel(int number)
    {
        switch (number)
        {
            case 0:
                Debug.Log("failed Active");
                successPanel.SetActive(false);
                failurePanel.SetActive(true);
                processingPanel.SetActive(false);
                break;
            case 1:
                Debug.Log("processing Active");
                successPanel.SetActive(false);
                failurePanel.SetActive(false);
                processingPanel.SetActive(true);
                StartCoroutine(changeToFailed());
                break;
            case 2:
                Debug.Log("success Active");
                successPanel.SetActive(true);
                failurePanel.SetActive(false);
                processingPanel.SetActive(false);
                break;
        }
    }

    public void changeToVRScene()
    {
        if (vrChangeCoroutine == null)
        {
            vrChangeCoroutine = StartCoroutine(changeVR());
        }
    }

    public void stopVRChange()
    {
        if (vrChangeCoroutine != null)
        {
            StopCoroutine(vrChangeCoroutine);
            vrChangeCoroutine = null; 
            Debug.Log("VR scene change stopped");
        }
    }

    IEnumerator changeToFailed()
    {
        yield return new WaitForSeconds(5);
        dialogTextPanel.SetActive(true);

        dialogTextPanel.GetComponent<UiScriptone>().enableDialog();
    }

    IEnumerator changeVR()
    {
        yield return new WaitForSeconds(8);
        Debug.Log("VR scene");
        activatePanel(2);
        SceneManager.LoadScene("EnvSelection");
    }
}
