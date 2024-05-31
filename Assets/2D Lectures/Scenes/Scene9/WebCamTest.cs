using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamTest : MonoBehaviour
{
    public int deviceIndex = 0;

    WebCamTexture camTexture;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }

        if (camTexture != null)
        {
            camTexture.Stop();
            camTexture = null;
        }
        WebCamDevice device = WebCamTexture.devices[deviceIndex];
        camTexture = new WebCamTexture(device.name);
        GetComponent<Renderer>().material.mainTexture = camTexture;
        camTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
