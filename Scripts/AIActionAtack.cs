using MoreMountains.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{

    public class AIActionAtack : AIAction
    {
        [SerializeField] private float radius;
        [SerializeField] private GameObject[] Enemy;
        [SerializeField] private GameObject bullet_Pf;
        [SerializeField] private float timeShoot;
        [SerializeField] private float timeNext;
        [SerializeField] private float speed_bullet;
        [SerializeField] private Transform spawn;
        [SerializeField] private LayerMask boss_layer;

        private Vector3 direction_bullet;
        private GameObject bullet;
        private Collider[] colliders;
        public override void Initialization()
        {
            colliders = new Collider[10];
        }

        public override void PerformAction()
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (Enemy[i].activeInHierarchy)
                {
                    AtackBoss(i);
                }
            }
        }

        //ve vong phat hien
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    
        private void Shooting(int index)
        {
            direction_bullet = Enemy[index].transform.position - transform.position;
            bullet = Instantiate(bullet_Pf, spawn.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = direction_bullet.normalized * speed_bullet;
        }

        private void AtackBoss(int index)
        {
            colliders = Physics.OverlapSphere(transform.position, radius, boss_layer);
            foreach (Collider collider in colliders)
            {
                if (Time.time < timeNext)
                {
                    return;
                }
                timeNext = Time.time + timeShoot;
                Shooting(index);
            }
        }
    }
}