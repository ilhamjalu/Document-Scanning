using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    public string deviceName;
    WebCamTexture wct;

    public RawImage test;

    // For photo varibles
    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);

    // For saving to the _savepath
    string _SavePath = Application.streamingAssetsPath + "/"; //Change the path here!
    int _CaptureCounter = 0;

    // Use this for initialization
    void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        deviceName = devices[0].name;
        wct = new WebCamTexture(deviceName, 400, 300, 12);
        GetComponent<Renderer>().material.mainTexture = wct;
        wct.Play();
   }
 
   public void TakeSnapshot()
   {
        Debug.Log("TEST");
        Texture2D snap = new Texture2D(wct.width, wct.height);
        Sprite tesSnap = Sprite.Create(snap, new Rect(0,0,wct.width, wct.height), new Vector2(0.5f, 0.5f));
        snap.SetPixels(wct.GetPixels());
        snap.Apply();

        test.GetComponent<RawImage>().texture = snap;
        heightmap = snap;

        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
   }

}
