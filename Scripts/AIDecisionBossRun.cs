using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionBossRun : AIDecision
{
    [SerializeField] private GameObject[] Boss;

    private float distance;
    public override bool Decide()
    {
        return Check_Distance();
    }

    protected virtual bool Check_Distance()
    {
        for(int i = 0; i < Boss.Length; i++)
        {
            if (Boss[i].activeInHierarchy)
            {
                distance = Vector3.Distance(transform.position, Boss[i].transform.position);
                if(distance <= 5f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
