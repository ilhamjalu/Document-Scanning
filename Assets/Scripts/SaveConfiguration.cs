using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class Configuration
{
    public int totalButton;
    public List<string> buttonsName;
    public List<string> buttonsPath;
}

public class SaveConfiguration : MonoBehaviour
{
    private const string CONFIG_KEY = "dataConfig";
    ButtonManager buttonManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveConfig()
    {
        Configuration config = new Configuration();

        config.totalButton = buttonManager.buttonParent.childCount;
        
        for(int i = 0; i < buttonManager.buttonParent.childCount; i++)
        {
            config.buttonsName.Add(buttonManager.buttonParent.GetChild(i).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text);
        }

        for (int i = 0; i < buttonManager.buttonParent.childCount; i++)
        {
            config.buttonsName.Add(buttonManager.buttonParent.GetChild(i).GetComponentInChildren<SaveFile>().saveDirectory);
        }

        string jsonData = JsonUtility.ToJson(config);

        PlayerPrefs.SetString(CONFIG_KEY, jsonData);

        PlayerPrefs.Save();

        Debug.Log("Configuration saved to PlayerPrefs: " + jsonData);
    }

    void LoadConfiguration()
    {
        if (PlayerPrefs.HasKey(CONFIG_KEY))
        {
            string jsonData = PlayerPrefs.GetString(CONFIG_KEY);

            Configuration config = JsonUtility.FromJson<Configuration>(jsonData);

            Debug.Log("Configuration loaded from PlayerPrefs: " + jsonData);

            buttonManager.SpawnButton(config.totalButton);
            buttonManager.SetButtonName(config.buttonsName);
            buttonManager.SetButtonPath(config.buttonsPath);
        }
    }
}
