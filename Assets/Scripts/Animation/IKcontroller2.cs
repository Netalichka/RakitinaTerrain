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

    [Header("Foot")]
    public float footOffsetY;
    private Vector3 leftFootPos;
    private Vector3 rightFootPos;
    private Quaternion leftFootRot;
    private Quaternion rightFootRot;

    //private float leftFootWeight;
    private float rightFootWeight;

    //private Transform leftLowerLeg;
    //private Transform leftFoot;
    private Transform rightLowerLeg;
    private Transform rightFoot;

    public LayerMask mask;

    private int _rightFootWeighthash;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rightFootWeighthash = Animator.StringToHash("RightFoot");
        rightFoot = _animator.GetBoneTransform(HumanBodyBones.RightFoot);
        rightLowerLeg = _animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        rightFootRot = rightFoot.rotation;
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

        rightFootWeight = _animator.GetFloat(_rightFootWeighthash);
        if (Physics.Raycast(rightLowerLeg.position, Vector3.down, out var hitR, 2f, mask))
        {
            rightFootPos = Vector3.Lerp(rightFootPos, hitR.point + Vector3.up * footOffsetY, Time.deltaTime * 10f);
            rightFootRot = Quaternion.FromToRotation(transform.up, hitR.normal) * transform.rotation;
        }

        _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        _animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPos);
        _animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRot);
    }
}
