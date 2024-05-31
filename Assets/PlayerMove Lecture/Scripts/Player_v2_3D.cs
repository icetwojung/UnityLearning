using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_v2_3D: MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotInput = Input.GetAxis("Horizontal");

        float moveDelta = moveInput * moveSpeed * Time.deltaTime;
        float rotDelta = rotInput * rotSpeed * Time.deltaTime;

        transform.Translate(0f, 0f, moveDelta, Space.Self);
        transform.Rotate(0f, rotDelta, 0f, Space.Self);
    }
}
