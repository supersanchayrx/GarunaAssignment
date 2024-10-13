using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public GameObject player;
    VRSetup vrsetupScript;

    private void Awake()
    {
        vrsetupScript = GameObject.Find("vrManager").GetComponent<VRSetup>();
    }
    public void instantiatePlayer()
    {
        GameObject.Instantiate(player, transform);

        vrsetupScript.InitializeVR();
    }
}
