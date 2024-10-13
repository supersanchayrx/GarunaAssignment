using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class heightScript : MonoBehaviour
{
    public int height = 12;
    TextMeshProUGUI heightText;

    private void Awake()
    {
        heightText = GetComponent<TextMeshProUGUI>();
    }
    public void increaseHeight()
    {
        height++;
        heightText.text = height.ToString();
    }

    public void decreaseHeight()
    {
        height--;
        heightText.text = height.ToString();
    }


}
