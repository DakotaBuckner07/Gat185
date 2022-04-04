using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : Movement
{
    NavMeshAgent navMeshAgent;

    public override Vector3 Velocity
    {
        get { return navMeshAgent.velocity; }
        set { navMeshAgent.velocity = value; }
    }

    public override void ApplyForce(Vector3 forces)
    {
        
    }

    public override void MoveTowards(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
        Debug.DrawLine(transform.position, target, Color.red);
    }

    public override void Stop()
    {
        navMeshAgent.isStopped = true;
    }

    public override void Resume()
    {
        navMeshAgent.isStopped = false;
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.speed = speedMax;
        navMeshAgent.angularSpeed = turnRate;
    }
}
