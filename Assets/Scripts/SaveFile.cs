using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveFile : MonoBehaviour
{
    public string saveDirectory;
    public RawImage resultImage;

    public EditManager editManager;

    // Start is called before the first frame update
    void Start()
    {
        editManager = FindObjectOfType<EditManager>();

        resultImage = GameObject.Find("RawImage").GetComponent<RawImage>();
        gameObject.GetComponent<Button>().onClick.AddListener(SaveTexture);
    }

    public void OpenFolderPicker()
    {
        var paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);

        if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
        {
            saveDirectory = paths[0];
            Debug.Log("Selected save directory: " + saveDirectory); 
        }
    }

    public void SaveTexture()
    {
        if(saveDirectory != "" && resultImage.texture.isReadable)
        {
            Texture2D temp = resultImage.texture as Texture2D;

            byte[] bytes = temp.EncodeToPNG();

            string fullPath = Path.Combine(saveDirectory, GetUniqueFileName(gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text, ".PNG"));

            File.WriteAllBytes(fullPath, bytes);

            editManager.OpenPanel(editManager.successPanel);

            Debug.Log("Texture saved at: " + fullPath);
        }
        else
        {
            editManager.OpenPanel(editManager.failedPanel);
        }
        
    }

    string GetUniqueFileName(string baseName, string extension)
    {
        int number = 1;
        string fileName = baseName + number + extension;
        
        while (File.Exists(Path.Combine(saveDirectory, fileName)))
        {
            number++;
            fileName = baseName + number + extension;
        }

        return fileName;
    }
}
