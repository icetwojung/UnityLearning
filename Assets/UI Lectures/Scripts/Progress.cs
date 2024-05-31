using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Slider uiSlider;
    public TextMeshProUGUI text;
    public float doneTime = 5f;

    private bool _run = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_run)
        {
            float time = uiSlider.value * doneTime;
            time += Time.deltaTime;
            if(time > doneTime )
            {
                doneTime = time;
                _run = false;
            }
            uiSlider.value = time / doneTime;
            text.text = string.Format("{0:f0}%", uiSlider.value * 100f);
        }
    }

    public void Run()
    {
        _run = true;
        uiSlider.value = 0f;
    }
}
