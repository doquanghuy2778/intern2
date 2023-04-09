using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AIAction : MonoBehaviour
{
    public abstract void PerformAction();
    public string Label;
    public bool ActionInProgress { get; set; }  
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
        ActionInProgress = true;
    }
    public virtual void OnExitState()
    {
        ActionInProgress = false;
    }
}
