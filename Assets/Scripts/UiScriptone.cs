using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiScriptone : MonoBehaviour
{

    private RectTransform rTransform;
    [SerializeField] float transitionDuration = 1f;
    int leftCount;
    public string bodyType;


    GameObject basePanel, createNewPanel, dialogBoxPanel;

    RectTransform box;


    private void Awake()
    {
        leftCount = 0; 
        rTransform = GetComponent<RectTransform>();
        basePanel = GameObject.FindGameObjectWithTag("basePanel");
        createNewPanel = GameObject.FindGameObjectWithTag("createNewPanel");
        dialogBoxPanel = GameObject.Find("DialogBoxGrp");
        box = GameObject.Find("dialogPanel").GetComponent<RectTransform>();


        
        //GameObject basePanel = GameObject.FindGameObjectWithTag("basePanel");

    }

    private void Start()
    {
        if (this.gameObject.tag == "processingPanel" || this.gameObject.tag == "createNewPanel")
        {
            this.gameObject.SetActive(false);
        }

        dialogBoxPanel.SetActive(false);
    }

    public void moveUiLeft()
    {
        if (leftCount<=0 && leftCount>=-2)
        {
            Vector3 newPosition = new Vector3(rTransform.anchoredPosition.x - 410f, rTransform.anchoredPosition.y, 0);
            rTransform.LeanMove(newPosition, transitionDuration).setEaseOutQuart();
            leftCount--;
        }
    }

    public void moveUiRight()
    {
        if (leftCount>=-3 && leftCount<0) 
        {   Vector3 newPosition = new Vector3(rTransform.anchoredPosition.x + 410f, rTransform.anchoredPosition.y, 0);
            rTransform.LeanMove(newPosition, transitionDuration).setEaseOutQuart();
            leftCount++;
        }
    }

    public void movePanelUisLeft()
    {
        if(this.tag=="panelMover")
        {
            
            createNewPanel.SetActive(true);
            Vector3 newPosition = new Vector3(-650f, rTransform.anchoredPosition.y, 0);
            rTransform.LeanMove(newPosition, transitionDuration).setEaseOutQuart();
            //basePanel.SetActive(false);
        }
    }

    public void movePanelUisRight()
    {
        if (this.tag == "panelMover")
        {
            Vector3 newPosition = new Vector3(650f, rTransform.anchoredPosition.y, 0);
            rTransform.LeanMove(newPosition, transitionDuration).setEaseOutQuart();
            //createNewPanel.SetActive(false);
        }
    }

    public void scaleUpPanel()
    {
        if(this.tag=="processingPanel")
        {
            //GameObject basePanel = GameObject.FindGameObjectWithTag("basePanel");

            this.gameObject.SetActive(true);
            Vector3 newScale = new Vector3(1f,1f,1f);
            rTransform.LeanScale(newScale, transitionDuration);
            basePanel.SetActive(false);
        }
    }

    public void scaleDownPanel()
    {
        if (this.tag == "processingPanel")
        {
            //GameObject basePanel = GameObject.FindGameObjectWithTag("basePanel");

            Vector3 newScale = new Vector3(0f, 0f, 0f);
            rTransform.LeanScale(newScale, transitionDuration).setEaseInBack();
            this.gameObject.SetActive(false);

            basePanel.SetActive(true);
        }
    }

    public void rotateCircle()
    {
        if(this.tag == "loadingCircle")
        {

            LeanTween.rotateAroundLocal(rTransform.gameObject, Vector3.forward, 360f, 1f)
             .setLoopClamp();
        }
        
    }

    public void StopRotation()
    {
        if (this.tag == "loadingCircle")
        {
            LeanTween.cancel(rTransform.gameObject);  // Cancels the rotation}
        }
    }

    public string setBodyType()
    {
        switch(leftCount)
        {
            case 0:
                bodyType = "bodyType1";
                break;
            case -1:
                bodyType = "bodyType2";
                break;
            case -2:
                bodyType = "bodyType3";
                break;
            case -3:
                bodyType = "bodyType4";
                break;

        }

        return bodyType;
    }

    public void enableDialog()
    {
        if(this.name == "DialogBoxGrp")
        {
            dialogBoxPanel.GetComponent<CanvasGroup>().alpha = 0f;
            dialogBoxPanel.GetComponent <CanvasGroup>().LeanAlpha(1f,transitionDuration);

            Vector3 newPosition = new Vector3(0f, -220f, 0);
            box.LeanMove(newPosition, transitionDuration).setEaseOutQuart();
        }
    }

    public void diasbleDialog()
    {
        if (this.name == "DialogBoxGrp")
        {
            dialogBoxPanel.GetComponent<CanvasGroup>().alpha = 0f;
            dialogBoxPanel.GetComponent<CanvasGroup>().LeanAlpha(0f, transitionDuration);

            Vector3 newPosition = new Vector3(0f, -1600f, 0);
            box.LeanMove(newPosition, transitionDuration).setEaseOutQuart();

        }

        this.gameObject.SetActive(false);
    }
}
