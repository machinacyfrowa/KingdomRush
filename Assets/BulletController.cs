using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //wie¿a która wystrzeli³a pocisk
    public GameObject tower;
    public GameObject? target;
    //obra¿enia jakie zada pocisk
    public int damage = 5;
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
        else
        {
            //TODO: czy to napewo jest dobry pomys³?
            Destroy(gameObject);
        }
    }
}
