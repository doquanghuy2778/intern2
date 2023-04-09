using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Linh : MonoBehaviour
{
    private float hp_linh;

    private void Start()
    {
        hp_linh = 60;
    }

    public void OnHit_linh(float dame_linh)
    {
        hp_linh -= dame_linh;
        if(hp_linh < dame_linh)
        {
            hp_linh = 0;
            OnDespon();
        }
    }

    private void OnDespon()
    {
        gameObject.SetActive(false);
    }
}
