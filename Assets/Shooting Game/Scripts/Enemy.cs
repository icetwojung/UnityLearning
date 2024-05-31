using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        health--;
        if(health == 0)
        {
            _audioSource.Play();
            Invoke("DestroyEnemy", destroyTime);
        }
    }

    void DestroyEnemy()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
