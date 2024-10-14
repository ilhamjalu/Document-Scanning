using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEdit : MonoBehaviour
{
    public Button mainButton;
    public GameObject editPanel;
    public EditManager editManager;

    // Start is called before the first frame update
    void Start()
    {
        editManager = FindObjectOfType<EditManager>();
        editPanel =  editManager.editPanel;
        gameObject.GetComponent<Button>().onClick.AddListener(SetEditPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetEditPanel()
    {
        editManager.OpenPanel(editPanel);
        editManager.button = mainButton;
    }
}
