using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class RadDollcontroller2 : MonoBehaviour
{
    private Rigidbody[] _rbs;
    private Collider[] _colliders;

    private Animator _animator;
    private NavMeshAgent _agent;

    private AICharacterControl _control;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _control = GetComponent<AICharacterControl>();

        _rbs = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Kill();
        if (Input.GetKeyDown(KeyCode.L))
            Revive();
    }

    private void SetRagDoll(bool isActive)
    {
        foreach (var rb in _rbs)
        {
            rb.isKinematic = !isActive;
            if (isActive)
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

        }

        foreach (var collider in _colliders)
        {
            collider.enabled = isActive;
        }
        _rbs[0].isKinematic = isActive;
        _colliders[0].enabled = !isActive;

        }

    public void Kill()
    {
        SetRagDoll(true);
        _animator.enabled = false;
        _agent.enabled = false;
        _control.enabled = false;


    }

    public void Revive()
    {
        SetRagDoll(false);
        _animator.enabled = true;
        _agent.enabled = true;
        _control.enabled = true;
    }



}
