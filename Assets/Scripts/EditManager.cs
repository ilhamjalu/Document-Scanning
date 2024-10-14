using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditManager : MonoBehaviour
{
    public GameObject editPanel;
    public TMP_InputField buttonName;
    public GameObject cameraObj;
    public Button button;

    public GameObject successPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditButtonName()
    {
        button.GetComponentInChildren<TextMeshProUGUI>().SetText(buttonName.text);

        buttonName.text = "";

        ClosePanel(editPanel);
    }

    public void ClosePanel(GameObject hideObj)
    {
        hideObj.SetActive(false);
        cameraObj.SetActive(true);
    }
    
    public void OpenPanel(GameObject showObj)
    {
        showObj.SetActive(true);
        cameraObj.SetActive(false);
    }
}
