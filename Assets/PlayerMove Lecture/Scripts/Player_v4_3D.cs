using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_v4_3D: MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotSpeed = 60f;  

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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

        _characterController.SimpleMove(transform.forward * moveInput * moveSpeed);

        float rotDelta = rotInput * rotSpeed * Time.deltaTime;
        transform.Rotate(0f, rotDelta, 0f, Space.Self);
    }
}
