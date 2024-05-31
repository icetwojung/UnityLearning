using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator _animator;
    private AudioSource _audioSource;
    private bool _oldDoorState = false;
    private bool _newDoorState = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_oldDoorState != _newDoorState)
        {
            _audioSource.Play();
            _animator.SetBool("DoorState", _newDoorState);
            _oldDoorState = _newDoorState;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            _newDoorState = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            _newDoorState = false;
    }
}
