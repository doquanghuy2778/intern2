using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionCheckBoss : AIDecision
{
    [SerializeField] private GameObject[] Enemy;
    public override void Initialization() { }
  
    public override bool Decide()
    {
        return Check_InMap();
    }

    protected virtual bool Check_InMap()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].activeInHierarchy)
            {
                return true;
            }
        }        
        return false;   
    }
}
