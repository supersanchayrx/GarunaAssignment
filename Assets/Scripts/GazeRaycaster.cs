using UnityEngine;

public class GazeRaycaster : MonoBehaviour
{
    public Camera vrCamera; // Assign the VR camera here
    public float maxDistance = 10f;

    private GazeInteraction currentGazeTarget;

    void Update()
    {
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            GazeInteraction gazeInteraction = hit.collider.GetComponent<GazeInteraction>();

            if (gazeInteraction != null)
            {
                if (gazeInteraction != currentGazeTarget)
                {
                    if (currentGazeTarget != null)
                    {
                        currentGazeTarget.StopGaze(); // Stop previous gaze
                    }
                    currentGazeTarget = gazeInteraction;
                    currentGazeTarget.StartGaze(); // Start new gaze
                }
            }
            else if (currentGazeTarget != null)
            {
                currentGazeTarget.StopGaze(); // Stop if no target
                currentGazeTarget = null;
            }
        }
        else if (currentGazeTarget != null)
        {
            currentGazeTarget.StopGaze(); // Stop if nothing is hit
            currentGazeTarget = null;
        }
    }
}
