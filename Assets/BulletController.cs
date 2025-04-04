using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject? target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            transform.LookAt(target.transform.position);
            rb.velocity = transform.forward * rb.velocity.magnitude;
        }
    }
}
