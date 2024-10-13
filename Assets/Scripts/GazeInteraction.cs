using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // To handle exiting to a different scene

public class GazeInteraction : MonoBehaviour
{
    public Image gazeProgressImage; // UI Image to show the gaze progress (optional)
    public float gazeDuration = 2f; // Time in seconds to trigger interaction

    private float gazeTimer = 0f;
    private bool isGazing = false;

    // Call this when the gaze enters the button
    public void StartGaze()
    {
        Debug.Log("gaze start");
        isGazing = true;
    }

    // Call this when the gaze exits the button
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
                ExitVRMode(); // Trigger exit when gaze time is met
            }
        }
    }

    private void UpdateGazeProgress(float progress)
    {
        if (gazeProgressImage != null)
        {
            gazeProgressImage.fillAmount = progress; // Update progress bar if applicable
        }
    }

    private void ExitVRMode()
    {
        // Logic to exit VR mode or go to dashboard
        Debug.Log("Exiting VR Mode...");
        SceneManager.LoadScene("Dashboard");
        // For example, you can load a different scene or quit the app
        //SceneManager.LoadScene("DashboardScene"); // Replace with your actual dashboard scene
    }
}
