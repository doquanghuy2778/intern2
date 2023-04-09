using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AIActionList : MMReorderableArray<AIAction> { }
[System.Serializable]
public class AITransitionList : MMReorderableArray<AITransion> { }

[System.Serializable]
public class AIState 
{
    public string StateName;

    //[MMReorderableAttribute(null, "Action", null)]
    public AIActionList Action;
    //[MMReorderableAttribute(null, "Transition", null)]
    public AITransitionList Transion;
    protected AiBrain _brain;

    public virtual void SetBrain(AiBrain brain)
    {
        _brain = brain; 
    }

    public virtual void EnterState()
    {
        foreach(AIAction action in Action)
        {
            action.OnEnterState();
        }
        foreach(AITransion transion in Transion)
        {
            if(transion.decision != null)
            {
                transion.decision.OnEnterState();
            }
        }
    }

    public virtual void ExitState()
    {
        foreach (AIAction action in Action)
        {
            action.OnExitState();
        }
        foreach (AITransion transion in Transion)
        {
            if (transion.decision != null)
            {
                transion.decision.OnExitState();
            }
        }
    }

    public virtual void PerformActions()
    {
        if (Action.Count == 0) { return; }
        for (int i = 0; i < Action.Count; i++)
        {
            if (Action[i] != null)
            {
                Action[i].PerformAction();
            }
        }
    }

    public virtual void EvaluateTransitions()
    {
        if (Transion.Count == 0) { return; }
        for (int i = 0; i < Transion.Count; i++)
        {
            if (Transion[i].decision != null)
            {
                if (Transion[i].decision.Decide())
                {
                    if (!string.IsNullOrEmpty(Transion[i].TrueState))
                    {
                        _brain.TransitionToState(Transion[i].TrueState);
                        break;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Transion[i].FalseState))
                    {
                        _brain.TransitionToState(Transion[i].FalseState);
                        break;
                    }
                }
            }
        }
    }
}