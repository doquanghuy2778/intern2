using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionRotate : AIAction
{
    [SerializeField] private GameObject[] Enemy;
    public override void Initialization()
    {

    }
    public override void PerformAction()
    {
        for(int i = 0; i < Enemy.Length; i++) 
        {
            if (Enemy[i].activeInHierarchy)
            {
                Rotate(i);
            }
        }
    }   

    private void Rotate(int index)
    {
        transform.LookAt(Enemy[index].transform.position);
    }                        
}                            
