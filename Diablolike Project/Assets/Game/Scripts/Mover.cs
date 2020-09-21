using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    private const string FORWARD_SPEED = "forwardSpeed";
    private NavMeshAgent _navMeshAgent;
    private Animator _anim;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();          
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        Vector3 velocity = _navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        _anim.SetFloat(FORWARD_SPEED, localVelocity.z);
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
       if (hasHit)
        {
            _navMeshAgent.destination = hit.point;
            //Debug.DrawRay(lastRay.origin, lastRay.direction * 100f, Color.red);
        }
    }
}
