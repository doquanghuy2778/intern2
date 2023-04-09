using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    public abstract bool Decide();

    public string Label;
    public bool DecisionInProgress { get; set; }
    protected AiBrain _brain;
    protected virtual void Awake()
    {
        _brain = this.gameObject.GetComponentInParent<AiBrain>();
    }
    public virtual void Initialization()
    {

    }
    public virtual void OnEnterState()
    {
        DecisionInProgress = true;
    }
    public virtual void OnExitState()
    {
        DecisionInProgress = false;
    }
}
