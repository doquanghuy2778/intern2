using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoVe_Move : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 target;
    private Vector3 mouPos;
    private Rigidbody rb_baove;
    
    // Start is called before the first frame update
    void Start()
    {
        rb_baove = gameObject.GetComponent<Rigidbody>();            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouPos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.gameObject.tag == "Plane")
                {
                    target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
                if(hit.collider.gameObject.tag == "Tru")
                {
                    Debug.Log("Che do bao ve");
                }
            }
            
            //xoay mat theo huong bam chuot
            transform.LookAt(target);   
            //di chuyen
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
    }
}
