using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionSkillReady : AIDecision
{
    private int timeCheck = 5;
    private AiBrain aiBrain;
    //AIDecisionTimeInState b = new AIDecisionTimeInState();
    private int timer;
    private int a;

    public override void Initialization()
    {
        aiBrain = gameObject.GetComponent<AiBrain>();   
    }
    public override bool Decide()
    {
        timer = Convert.ToInt32(aiBrain.TimeInThisState);
        Debug.Log(timer);
        return Decision_Skill();
    }

    protected virtual bool Decision_Skill()
    {
        if ((timer > 0) && timer % timeCheck == 0)
        {
            return true;
        }
        return false;
    }
}