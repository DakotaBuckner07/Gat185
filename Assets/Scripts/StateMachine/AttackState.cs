﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public float attackTimeMin = 0.5f;
    public float attackTimeMax = 2.0f;
    public float meleeDistance = 4.0f;


    float timer;
    float attackTimer;
    Vector3 lastTargetPosition;

    public override void Enter(Agent owner)
    {
        Debug.Log(GetType().Name + " Enter\n");
        attackTimer = Random.Range(attackTimeMin, attackTimeMax);
    }

    public override void Execute(Agent owner)
    {
        GameObject[] gameObjects = owner.perception.GetGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

        if(player != null)
        {
            lastTargetPosition = player.transform.position;
            timer = 1;

            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                float distance = Vector3.Distance(owner.transform.position, player.transform.position);
                if (distance > meleeDistance)
                {
                    ((StateAgent)owner).StateMachine.SetState("AttackRangeState");
                }
                else
                {
                    ((StateAgent)owner).StateMachine.SetState("AttackMeleeState");
                }
            }
        }

        owner.movement.MoveTowards(lastTargetPosition);

        if (player == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ((StateAgent)owner).StateMachine.SetState("IdleState");
            }
        }
    }

    public override void Exit(Agent owner)
    {
        Debug.Log(GetType().Name + " Exit\n");
    }
}
