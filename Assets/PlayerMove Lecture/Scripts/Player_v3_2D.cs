using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_v3_2D: MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpForce = 1f;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        Vector2 moveDelta = new Vector2(moveInput * moveSpeed, _rigidbody.velocity.y);

        _rigidbody.velocity = moveDelta;

        if(_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            _isGrounded = false;
    }
}
