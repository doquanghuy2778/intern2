using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionRunAway : AIAction
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] Boss;
    
    private Rigidbody rb_hero;
    private Vector3 direction;
    private float distance;
    public override void Initialization()
    {
        rb_hero = gameObject.GetComponent<Rigidbody>(); 
    }

    public override void PerformAction()
    {
        for(int i = 0; i < Boss.Length; i++) 
        {
            RunAway(i);
            CheckDistance(i);
        }
    }

    private void RunAway(int index)
    {
        direction = Boss[index].transform.position - transform.position;
        rb_hero.velocity = -direction.normalized * speed;
    }
    
    private void CheckDistance(int index)
    {
        distance = Vector3.Distance(transform.position, Boss[index].transform.position);
        if(distance <= 5f)
        {
            rb_hero.velocity = Vector3.zero;
        }
    }
}
