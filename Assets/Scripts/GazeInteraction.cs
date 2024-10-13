using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GazeInteraction : MonoBehaviour
{
    public Image gazeProgressImage; // coundlt find the files in figma
    public float gazeDuration = 2f; // how long will it take to exit the gaze button

    private float gazeTimer = 0f;
    private bool isGazing = false;

    // into init
    public void StartGaze()
    {
        Debug.Log("gaze start");
        isGazing = true;
    }

    // exiting init
    public void StopGaze()
    {
        isGazing = false;
        gazeTimer = 0f;
        Debug.Log("gaze stop");

        UpdateGazeProgress(0f);
    }

    private void Update()
    {
        if (isGazing)
        {
            gazeTimer += Time.deltaTime;
            UpdateGazeProgress(gazeTimer / gazeDuration);

            if (gazeTimer >= gazeDuration)
            {
                ExitVRMode();
            }
        }
    }

    private void UpdateGazeProgress(float progress)
    {
        if (gazeProgressImage != null)
        {
            gazeProgressImage.fillAmount = progress; // couldnt find the designs files for gaze button transitions and animations
        }
    }

    private void ExitVRMode()
    {
        // quit vr
        Debug.Log("Exiting VR Mode...");
        SceneManager.LoadScene("Dashboard");
        
        //SceneManager.LoadScene("DashboardScene"); // Replace with your actual dashboard scene
    }
}
