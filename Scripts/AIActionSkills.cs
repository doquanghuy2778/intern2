using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionSkills : AIAction
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private GameObject Bullet_Skill;
    [SerializeField] private Transform spawn;
    [SerializeField] private float speed_skill;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask boss_layer;
    [SerializeField] private float timeShoot;
    [SerializeField] private float timeNext;

    private Vector3 direction_skill;
    private Collider[] colliders;
    private GameObject bullet_skill;
    public override void Initialization()
    {

    }

    public override void PerformAction()
    {
        for(int i = 0; i < Enemy.Length; i++) 
        {
            if (Enemy[i].activeInHierarchy)
            {
                Attack(i);
            }
        }
    }

    private void Skill_Readly(int index)
    {
        direction_skill = Enemy[index].transform.position - transform.position;
        bullet_skill = Instantiate(Bullet_Skill, spawn.position, Quaternion.identity);
        bullet_skill.GetComponent<Rigidbody>().velocity = direction_skill.normalized * speed_skill;
    }

    private void Attack(int index)
    {
        colliders = Physics.OverlapSphere(transform.position, radius, boss_layer);
        foreach (Collider collider in colliders)
        {
            //if (Time.time < timeNext)
            //{
            //    return;
            //}
            //timeNext = Time.time + timeShoot;
            Skill_Readly(index);
        }
    }
}