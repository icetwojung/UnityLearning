using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jaehong : MonoBehaviour
{
    public GameObject cube;
    public GameObject cube2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1) == true)
        {
            cube.transform.Translate(0, 0.01f, 0);
            cube2.transform.Translate(0.01f, 0, 0);
        }        
    }
}

