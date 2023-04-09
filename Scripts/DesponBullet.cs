using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesponBullet : MonoBehaviour
{
    [SerializeField] private float timeSpawnBullet;

    private void Start()
    {
        if (gameObject != null)
        {
            Invoke(nameof(OnDespown), timeSpawnBullet);
        }
    }

    private void OnDespown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            //moi khi ban trung se mat 20 mau
            other.GetComponent<Character>().OnHit(20f);
            OnDespown();    
        }
    } 
}
