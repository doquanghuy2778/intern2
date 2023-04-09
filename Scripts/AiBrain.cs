using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class AiBrain : MonoBehaviour
{
    public List<AIState> states;    

    public bool BrainActive = true;
    public AIState CurrentState; 
    public float TimeInThisState;

    public float ActionsFrequency = 0f;
    public float DecisionFrequency = 0f;
    protected float _lastActionsUpdate = 0f;
    protected float _lastDecisionsUpdate = 0f;

    protected AIDecision[] _decisions;
    protected AIAction[] _actions;
    protected AIState _initState;

    public virtual AIAction[] GetAttachedActions()
    {
        AIAction[] actions = this.gameObject.GetComponentsInChildren<AIAction>();
        return actions;
    }

    public virtual AIDecision[] GetAttachedDecisions()
    {
        AIDecision[] decisions = this.gameObject.GetComponentsInChildren<AIDecision>();
        return decisions;
    }

    protected virtual void Awake()
    {
        foreach (AIState state in states)
        {
            state.SetBrain(this);
        }
        _decisions = GetAttachedDecisions();
        _actions = GetAttachedActions();
       
    }
    protected virtual void Start()
    {
        ResetBrain();
    }

    protected virtual void Update()
    {
        int c = Convert.ToInt32(TimeInThisState);
        //Debug.Log(c);
        if (!BrainActive || (CurrentState == null) || (Time.timeScale == 0f))
        {
            return;
        }

        if (Time.time - _lastActionsUpdate > ActionsFrequency)
        {
            CurrentState.PerformActions();
            _lastActionsUpdate = Time.time;
        }

        if (!BrainActive)
        {
            return;
        }

        if (Time.time - _lastDecisionsUpdate > DecisionFrequency)
        {
            CurrentState.EvaluateTransitions();
            _lastDecisionsUpdate = Time.time;
        }
        TimeInThisState += Time.deltaTime;
        //StoreLastKnownPosition();
    }


    protected virtual void InitializeDecisions()
    {
        if (_decisions == null)
        {
            _decisions = GetAttachedDecisions();
        }
        foreach (AIDecision decision in _decisions)
        {
            decision.Initialization();
        }
    }

    protected virtual void OnExitState()
    {
        TimeInThisState = 0f;
    }

    protected virtual void InitializeActions()
    {
        if (_actions == null)
        {
            _actions = GetAttachedActions();
        }
        foreach (AIAction action in _actions)
        {
            action.Initialization();
        }
    }
    public virtual void ResetBrain()
    {
        InitializeDecisions();
        InitializeActions();
        BrainActive = true;
        this.enabled = true;

        if (CurrentState != null)
        {
            CurrentState.ExitState();
            OnExitState();
        }

        if (states.Count > 0)
        {
            CurrentState = states[0];
            CurrentState?.EnterState();
        }
    }

    protected AIState FindState(string stateName)
    {
        foreach (AIState state in states)
        {
            if (state.StateName == stateName)
            {
                return state;
            }
        }
        if (stateName != "")
        {
            Debug.LogError("You're trying to transition to state '" + stateName + "' in " + this.gameObject.name + "'s AI Brain, but no state of this name exists. Make sure your states are named properly, and that your transitions states match existing states.");
        }
        return null;
    }

    public virtual void TransitionToState(string newStateName)
    {
        if (CurrentState == null)
        {
            CurrentState = FindState(newStateName);
            if (CurrentState != null)
            {
                CurrentState.EnterState();
            }
            return;
        }
        if (newStateName != CurrentState.StateName)
        {
            CurrentState.ExitState();
            OnExitState();

            CurrentState = FindState(newStateName);
            if (CurrentState != null)
            {
                CurrentState.EnterState();
            }
        }
    }
}