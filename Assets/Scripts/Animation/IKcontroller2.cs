using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKcontroller2 : MonoBehaviour
{
    [SerializeField] private Transform _handPoint;
    [SerializeField] private Transform _headPoint;

    [SerializeField, Range(0f, 1f)] private float _handWeight;
    [SerializeField] private Vector3 _handOffSet;
    [SerializeField, Range(0f, 1f)] private float _lookIKWeight;

    [Range(0f, 1f)] public float eyesWeight;
    [Range(0f, 1f)] public float headWeight;
    [Range(0f, 1f)] public float bodyWeight;
    [Range(0f, 1f)] public float clumpWeight;
  


    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_handPoint)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _handWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _handWeight);

            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _handPoint.position + _handOffSet);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _handPoint.rotation);


        }
            
        if (_headPoint)
        {
            _animator.SetLookAtWeight(_lookIKWeight, bodyWeight, headWeight, eyesWeight, clumpWeight);
            _animator.SetLookAtPosition(_headPoint.position);
        }
    }
}