using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CropScript : MonoBehaviour
{
    public TMP_InputField tinggi, lebar;
    int cTinggi, cLebar;
    public RawImage cropImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cTinggi = Int32.Parse(tinggi.text);
        cLebar = Int32.Parse(lebar.text);
        var a = cropImage.GetComponent<RectTransform>();
        a.sizeDelta = new Vector2(cLebar, cTinggi);
    }
}
