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

    // Start is called before the first frame update
    void Start()
    {
        resultImage = GameObject.Find("RawImage").GetComponent<RawImage>();
        gameObject.GetComponent<Button>().onClick.AddListener(OpenFolderPicker);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenFolderPicker()
    {
        if(saveDirectory == "")
        {
            var paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);

            if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
            {
                saveDirectory = paths[0];
                Debug.Log("Selected save directory: " + saveDirectory);

            }
        }

        if (resultImage.texture != null)
        {
            SaveTexture();
        }
    }

    public void SaveTexture()
    {
        Texture2D temp = resultImage.texture as Texture2D;

        byte[] bytes = temp.EncodeToPNG();

        string fullPath = Path.Combine(saveDirectory, GetUniqueFileName(gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text, ".PNG"));

        File.WriteAllBytes(fullPath, bytes);
        Debug.Log("Texture saved at: " + fullPath);
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
