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
        //enabling vr

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
                    displaySubsystem.Start();  
                }
            }
        }

        Debug.Log("enablingVR");

    }

    private void disableVr()
    {
        // disabling vr
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
                    displaySubsystem.Stop();  
                }
            }
        }

        Debug.Log("disablingVR");

    }

    void SetVRFullScreen()
    {
        //sometimes the phone was misaligning the center point so custom resolution set 
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

}
