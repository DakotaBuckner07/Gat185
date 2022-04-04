using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgent : Agent
{
    public enum eStates
    {
        Idle,
        ActionStart,
        ActionInProgress,
        ActionComplete
    }

    eStates state = eStates.Idle;
    UtilityAgentGoal[] goals;
    UtilityObject utilityObject;

    void Start()
    {
        goals = GetComponentsInChildren<UtilityAgentGoal>();
    }

    void Update()
    {
        switch (state)
        {
            case eStates.Idle:

                break;
            case eStates.ActionStart:
                StartCoroutine(ExecuteUtilityObject(utilityObject));
                break;
            case eStates.ActionInProgress:

                break;
            case eStates.ActionComplete:
                StopCoroutine("ExecuteUtilityObject");
                utilityObject = null;
                state = eStates.Idle;
                break;
            default:
                break;
        }
    }

    IEnumerator ExecuteUtilityObject(UtilityObject utilityObject)
    {
        state = eStates.ActionInProgress;

        movement.MoveTowards(utilityObject.location.position);
        while(Vector3.Distance(transform.position, utilityObject.location.position) > 0.1f)
        {
            yield return null;
        }

        animator.SetTrigger(utilityObject.animationID);
        utilityObject.actionFX.SetActive(true);

        yield return new WaitForSeconds(utilityObject.duration);

        animator.SetTrigger("Idle");
        utilityObject.actionFX.SetActive(false);

        UpdateUtilityObjectScore(utilityObject);

        state = eStates.ActionComplete;
        yield return null;
    }

    public void StartUtilityObject(UtilityObject utilityObject)
    {
        if(state == eStates.Idle)
        {
            state = eStates.ActionStart;
            this.utilityObject = utilityObject;
        }
    }

    void UpdateUtilityObjectScore(UtilityObject utilityObject)
    {
        foreach(var goal in goals)
        {
            float score = utilityObject.GetScore(goal.id);
            goal.input += score;
        }
    }
}
