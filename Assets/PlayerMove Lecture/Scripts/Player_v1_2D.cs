using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_v1_2D: MonoBehaviour
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
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        Vector3 delta = new Vector3(input.x * speed * Time.deltaTime, input.y * speed * Time.deltaTime, 0f);

        transform.Translate(delta, space);
    }
}
