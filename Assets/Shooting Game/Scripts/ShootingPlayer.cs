using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingPlayer : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float lookSpeed = 300f;
    public float jumpForce = 1f;
    public float shootForce = 10f;
    public GameObject lookGameObject;
    public GameObject bulletPrefab;

    private float _xRotation = 0f;
    private float _yRotation = 0f;
    private Rigidbody _rigidbody;
    private bool _isGrounded = false;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);

        lookGameObject.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, _yRotation, 0f);       

        if (_isGrounded)
        {
            float moveV = Input.GetAxis("Vertical") * moveSpeed;
            float moveH = Input.GetAxis("Horizontal") * moveSpeed;

            Vector3 moveDelta = transform.forward * moveV + transform.right * moveH;
            moveDelta.y = _rigidbody.velocity.y;

            _rigidbody.velocity = moveDelta;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, lookGameObject.transform.position, Quaternion.identity);
            Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
            bulletRigidBody.AddForce(lookGameObject.transform.forward * shootForce, ForceMode.Impulse);
            _audioSource.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
             _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
             _isGrounded = false;
    }
}
