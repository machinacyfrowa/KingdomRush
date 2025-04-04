using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("Fire", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");
        bulletSpawn.LookAt(target.transform.position+target.transform.forward*1.5f);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<BulletController>().target = target;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;
        Destroy(bullet, 2.0f);
    }
}
