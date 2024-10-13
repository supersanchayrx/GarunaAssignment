using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class DataStorage : MonoBehaviour
{
    new userData user = new userData();
    int height, genderInt;
    string bodyType, gender;
    UiScriptone bodyTypeScript;
    heightScript Height;

    private string filePath;

    private void Awake()
    {
        bodyTypeScript = GameObject.Find("BodyTypes").GetComponent<UiScriptone>();
        Height = GameObject.Find("heightText").GetComponent<heightScript>();
        genderInt = 0;

        filePath = Path.Combine(Application.persistentDataPath, "userdata.json");

    }
    public void updateData()
    {
        bodyType = bodyTypeScript.setBodyType();
        gender = setGender();
        height = Height.height;

        user.SetBodyType(bodyType);
        user.SetGender(gender);
        user.SetHeight(height);

        SaveUserData();
    }

    private void SaveUserData()
    {
        string json = JsonUtility.ToJson(user);  // Convert userData to JSON
        File.WriteAllText(filePath, json);  // Write the JSON string to a file
        Debug.Log("Data saved to " + filePath);
    }

    public void male()
    {
        genderInt = 1;
    }

    public void female()
    {
        genderInt = 2;
    }

    private string setGender()
    {
        string tempGender = null;
        switch(genderInt)
        {
            case 0:
                tempGender = "unspecified";
                break;
            case 1:
                tempGender = "Male";
                break;
            case 2:
                tempGender = "Female";
                break;
        }

        return tempGender;
    }
}

[System.Serializable]
class userData
{
    public int height;
    public string gender;
    public Texture2D photo;
    public string bodyType;

    public userData()
    {
        height = 12;
        bodyType = "Unknown";
        gender = "Unknown";
        photo = null;
    }

    public void SetHeight(int newHeight)
    {
        height = newHeight;
        Debug.Log("new Height set to" + height);
    }

    public void SetGender(string newGender) 
    {
        gender = newGender;
        Debug.Log("new Gender set to" + gender);

    }

    public void SetBodyType(string newBodyType)
    {
        bodyType = newBodyType;
        Debug.Log("new Body Type set to" + bodyType);

    }

}
