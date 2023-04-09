using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    [SerializeField] private float speed_move;
    [SerializeField] private GameObject[] Enemy;

    private Vector3 hitpos;
    private Rigidbody rb_hero;
    private Vector3 mouPos;
    private Vector3 direction;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        rb_hero = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].activeInHierarchy == false)
            {
                Move_Mouse();
                Check_Distance();
            }
        }
    }
    private void Move_Mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Plane")
                {
                    hitpos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                }
                if (hit.collider.gameObject.tag == "Tru")
                {
                    Debug.Log("Che do bao ve");
                    //dung sau tru
                    hitpos = new Vector3(hit.point.x - 3, 0.5f, hit.point.z - 3);
                }
            }
            Debug.Log("hit pos" + hitpos);
            //quay mat theo huong chuot
            transform.LookAt(hitpos);

            //di chuyen
            direction = hitpos - transform.position;
            rb_hero.velocity = direction.normalized * speed_move;
        }
    }

    private void Check_Distance()
    {
        //tinh khoang cach giua hero va diem nhan chuot
        float distance = Vector3.Distance(hitpos, transform.position);
        Debug.Log(distance);
        if (distance < 0.0001f)
        {
            rb_hero.velocity = Vector3.zero;
        }
    }
}