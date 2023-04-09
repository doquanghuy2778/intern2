using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDecisionMissionDefense : AIDecision
{
    private Vector3 mousepos;

    public override bool Decide()
    {
        return Active_Mission();
    }

    protected virtual bool Active_Mission()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousepos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Tru")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
