using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiActionEmBattle : AIAction
{
    [SerializeField] private GameObject BaoVe;
    [SerializeField] private float speed_target;

    private Vector3 toado;
    private Vector3 target;

    public override void Initialization() { }
   
    public override void PerformAction()
    {
        //chi sap xep duoc khi BaoVe co tren ban do
        if (BaoVe.activeInHierarchy)
        {
            //quay mat theo huong cua tuong Bao Ve
            transform.LookAt(BaoVe.transform.position);
            //di chuyen
            MoveTarget();
        }   
    }

    private void MoveTarget()
    {
        //set bien "toa do" bang toa do cua nhan vat "Bao Ve"
        toado = BaoVe.transform.position;

        //tinh huong di chuyen
        //TH1
        if (toado.z > 0)
        {
            target = new Vector3(toado.x + 2, 0.5f, toado.z - 4);
        }
        //TH2
        else if (toado.z < 0 && toado.x > 0)
        {
            target = new Vector3(toado.x + 2, 0.5f, toado.z - 4);
        }
        //Th3
        else if (toado.z < 0 && toado.x < 0)
        {
            target = new Vector3(toado.x - 2, 0.5f, toado.z - 4);
        }

        //di chuyen den vi tri da tinh toan
        transform.position = Vector3.MoveTowards(transform.position, target, speed_target * Time.deltaTime);
    }
}
