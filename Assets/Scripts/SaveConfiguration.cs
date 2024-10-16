using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Configuration
{
    public int totalButton;
    public List<string> buttonsName;
    public List<string> buttonsPath;
}

public class SaveConfiguration : MonoBehaviour
{
    private const string CONFIG_KEY = "dataConfig";
    ButtonManager buttonManager;

    public Configuration config = new Configuration();

    // Start is called before the first frame update
    void Start()
    {
        buttonManager = GetComponent<ButtonManager>();
        LoadConfiguration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveConfig()
    {
        config.totalButton = buttonManager.buttonParent.childCount;

        config.buttonsName.Clear();

        for(int i = 0; i < buttonManager.buttonParent.childCount; i++)
        {
            Debug.Log(buttonManager.buttonParent.GetChild(i).GetChild(1).name);

            string name = buttonManager.buttonParent.GetChild(i).GetChild(1).transform.GetComponentInChildren<TextMeshProUGUI>().text;

            config.buttonsName.Add(name);
        }

        for (int i = 0; i < buttonManager.buttonParent.childCount; i++)
        {
            config.buttonsPath.Add(buttonManager.buttonParent.GetChild(i).GetComponentInChildren<SaveFile>().saveDirectory);
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

            config = JsonUtility.FromJson<Configuration>(jsonData);

            Debug.Log("Configuration loaded from PlayerPrefs: " + jsonData);

            buttonManager.SpawnButton(config.totalButton, config.buttonsName, config.buttonsPath);
            //buttonManager.SetButtonName(config.buttonsName);
            //buttonManager.SetButtonPath(config.buttonsPath);
        }
    }

    public void ResetConfiguration()
    {
        PlayerPrefs.DeleteKey(CONFIG_KEY);
    }
}
