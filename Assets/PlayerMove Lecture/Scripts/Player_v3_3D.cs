using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_v3_3D: MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotSpeed = 60f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotInput = Input.GetAxis("Horizontal");

        Vector3 moveDelta = transform.forward * moveInput * moveSpeed;
        float rotDelta = rotInput * rotSpeed * Time.deltaTime;

        _rigidbody.velocity = moveDelta;
        transform.Rotate(0f, rotDelta, 0f, Space.Self);
    }
}
