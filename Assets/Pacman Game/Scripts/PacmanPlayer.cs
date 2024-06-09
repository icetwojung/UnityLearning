using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanPlayer : MonoBehaviour
{
    public float moveSpeed = 3.0f;

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
        _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, _rigidbody.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            PacmanGame.instance.OnGameOver();
        }
    }
}
