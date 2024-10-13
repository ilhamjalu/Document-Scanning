using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResetDirectory : MonoBehaviour
{
    public SaveFile[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ResetPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("TEST RESET")]
    void ResetPath()
    {
        buttons = FindObjectsOfType<SaveFile>();

        foreach (SaveFile button in buttons)
        {
            button.saveDirectory = "";
        }
    }
}
