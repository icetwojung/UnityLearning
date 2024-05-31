using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_v1_3D: MonoBehaviour
{
    public float speed = 1.0f;
    public Space space = Space.World;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 delta = new Vector3(input.x * speed * Time.deltaTime, 0f, input.z * speed * Time.deltaTime);

        transform.Translate(delta, space);
    }
}
