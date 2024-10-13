using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using UnityEngine.XR;

public class VRSetup : MonoBehaviour
{
    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Dashboard" || SceneManager.GetActiveScene().name == "EnvSelection")
        {
            disableVr();
        }

        /*else
        {
            InitializeVR();
        }*/
    }

    public void InitializeVR()
    {
        // Add your VR initialization code here, like enabling VR settings
        // Example:
        //UnityEngine.XR.XRSettings.LoadDeviceByName("Cardboard");
        //UnityEngine.XR.XRSettings.enabled = true;
        SetVRFullScreen();

        XRGeneralSettings xrGeneralSettings = XRGeneralSettings.Instance;
        if (xrGeneralSettings != null)
        {
            XRManagerSettings xrManager = xrGeneralSettings.Manager;
            if (xrManager != null && xrManager.activeLoader != null)
            {
                XRDisplaySubsystem displaySubsystem = xrManager.activeLoader.GetLoadedSubsystem<XRDisplaySubsystem>();
                if (displaySubsystem != null && !displaySubsystem.running)
                {
                    displaySubsystem.Start();  // Enable VR
                }
            }
        }

        Debug.Log("enablingVR");

    }

    private void disableVr()
    {
        // Disable VR settings if needed when exiting the scene
        //UnityEngine.XR.XRSettings.enabled = false;

        XRGeneralSettings xrGeneralSettings = XRGeneralSettings.Instance;
        if (xrGeneralSettings != null)
        {
            XRManagerSettings xrManager = xrGeneralSettings.Manager;
            if (xrManager != null && xrManager.activeLoader != null)
            {
                XRDisplaySubsystem displaySubsystem = xrManager.activeLoader.GetLoadedSubsystem<XRDisplaySubsystem>();
                if (displaySubsystem != null && displaySubsystem.running)
                {
                    displaySubsystem.Stop();  // Disable VR
                }
            }
        }

        Debug.Log("disablingVR");

    }

    void SetVRFullScreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

}
