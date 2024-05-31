using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotSpeed = 60f;
    public float destroyTime = 1f;

    private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotSpeed * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        Invoke("DestroyItem", destroyTime);
    }

    void DestroyItem()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
