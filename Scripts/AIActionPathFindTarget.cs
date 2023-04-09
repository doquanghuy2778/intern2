using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionPathFindTarget : AIAction
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private GameObject Hero;
    [SerializeField] private float Speed_movetarget;
    [SerializeField] private float Value_distance;

    private Rigidbody Hero_rb;
    private Vector3 direction;
    private float distance;

    public override void Initialization()
    {
        Hero_rb = gameObject.GetComponent<Rigidbody>();
    }

    public override void PerformAction()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].activeInHierarchy)
            {
                MoveTarget(i);
            }
        }
    }

    private void MoveTarget(int index)
    {
        direction = Enemy[index].transform.position - transform.position;
        Hero_rb.velocity = direction.normalized * Speed_movetarget * Time.deltaTime;
    }
}