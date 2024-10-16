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
    public GameObject failedPanel;

    public TextMeshProUGUI directoryText;

    private void Update()
    {
        if(editPanel.activeInHierarchy)
        {
            SetDirectoryText();
        }
    }

    public void EditButtonName()
    {
        button.GetComponentInChildren<TextMeshProUGUI>().SetText(buttonName.text);

        buttonName.text = "";

        ClosePanel(editPanel);
    }

    public void SetDirectoryText()
    {
        string directory = button.GetComponent<SaveFile>().saveDirectory;
        if (directory != "")
        {
            directoryText.text = button.GetComponent<SaveFile>().saveDirectory;
        }
        else
        {
            directoryText.text = "Save Directory";
        }
    }

    public void EditDirectory()
    {
        button.GetComponent<SaveFile>().OpenFolderPicker();
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
