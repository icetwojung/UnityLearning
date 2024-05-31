using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBinding : MonoBehaviour
{
    public Toggle toggle;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleChanged(bool toggleValue)
    {
        light.SetActive(toggleValue);
    }
}
