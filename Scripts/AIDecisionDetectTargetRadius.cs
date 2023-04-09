using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionDetectTargetRadius : AIDecision
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask boss_layer;
    [SerializeField] private float timeNext;
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private float Value_distance;

    private float distance;
    private Rigidbody Hero_rb;

    public override void Initialization()
    {
        Hero_rb = gameObject.GetComponent<Rigidbody>(); 
    }

    public override bool Decide()
    {
        return Check_Boss();
    }

    protected virtual bool Check_Boss()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].activeInHierarchy)
            {
                distance = Vector3.Distance(transform.position, Enemy[i].transform.position);
                if (distance <= Value_distance)
                {
                    Hero_rb.velocity = Vector3.zero;
                    return true;
                }
            }
        }
        return false;
    }

    //vong phat hien
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
