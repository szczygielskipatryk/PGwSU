using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 cel;
    private float speed = 3;
    private Rigidbody rb;
    private Vector3[] points = new Vector3[2];
    private int aktual = 0;
    private bool czyjest = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points[0] = transform.position;
        points[1] = cel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
            czyjest = true;
        }
            
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
            czyjest = false;
        }
    }

    void FixedUpdate()
    {
        if (czyjest)
        { 
            if (transform.position != points[aktual])
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, points[aktual], Time.deltaTime * speed);
                rb.MovePosition(pos);
            }
            else
            {
                aktual = (aktual + 1) % points.Length;
            }
        }
    }



}
