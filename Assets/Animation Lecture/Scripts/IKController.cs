using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKController : MonoBehaviour
{
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform lookObj = null;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // Set the look target position, if one has been assigned
        if (lookObj != null)
        {
            _animator.SetLookAtWeight(1);
            _animator.SetLookAtPosition(lookObj.position);
        }
        else
        {
            _animator.SetLookAtWeight(0);
        }

        // Set the right hand target position and rotation, if one has been assigned
        if (rightHandObj != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        }

        // Set the left hand target position and rotation, if one has been assigned
        if (leftHandObj != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
        }
    }
}
