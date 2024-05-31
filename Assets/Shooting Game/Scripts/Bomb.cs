using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explotionTime = 1f;
    public float destroyTime = 1f;

    private AudioSource _audioSource;
    private bool _isExplosion = false;
    private float _time;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _time = explotionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isExplosion)
        {
            _time -= Time.deltaTime;
            if(_time < 0 )
            {
                _audioSource.Play();
                Invoke("DestroyBomb", destroyTime);
                _isExplosion = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            _isExplosion = true;
        }
    }

    void DestroyBomb()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
