using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float liveTime = 2f;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        _time = liveTime;
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        if(_time < 0 )
        {
            GameObject.DestroyImmediate(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.tag.Equals("Player"))
        {
            _time = -1f;
        }
    }
}
