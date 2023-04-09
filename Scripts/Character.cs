using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //[SerializeField] private GameObject Boss;
    private float hp;

    //public bool IsDeath;
    private void Start()
    {
        hp = 500;
    }

    public void OnHit(float dame)
    {
        hp -= dame;
        if(hp < dame)
        {
            hp = 0;
            OnDeath();
        }
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
        Debug.Log("Death");
        //IsDeath = true;
    }
}
