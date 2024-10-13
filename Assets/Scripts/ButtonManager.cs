using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Windows.Forms;

public class ButtonManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public TMP_InputField totalButton;
    public Transform buttonParent;
    public int buttonIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnListener()
    {
        SpawnButton(int.Parse(totalButton.text));
    }

    public void SpawnButton(int increment)
    {
        foreach(Transform t in buttonParent.transform)
        {
            Destroy(t.gameObject);
        }

        for(int i = 0; i < increment; i++)
        {
            GameObject temp = Instantiate(buttonPrefab);

            temp.transform.parent = buttonParent;
            temp.transform.localScale = Vector3.one;
            temp.transform.localPosition = Vector3.zero;
        }
    }

    public void SetButtonName(List<string> buttonsName)
    {
        for(int i = 0;i < buttonsName.Count;i++)
        {
            buttonParent.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = buttonsName[i]; 
        }
    }

    public void SetButtonPath(List<string> buttonsPath)
    {
        for (int i = 0; i < buttonsPath.Count; i++)
        {
            buttonParent.transform.GetChild(i).GetComponentInChildren<SaveFile>().saveDirectory = buttonsPath[i];
        }
    }
}
