using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float range = 10f;
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
        List<Collider> targetCollidersInRange = Physics.OverlapSphere(bulletSpawn.position, range).ToList();
        //odfiltruj elementy bez taga enemy
        targetCollidersInRange = targetCollidersInRange.Where(x => x.CompareTag("Enemy")).ToList();
        //posortuj wed³ug odleg³oœci od wie¿y
        targetCollidersInRange = targetCollidersInRange.OrderBy(x => Vector3.Distance(bulletSpawn.position, x.transform.position)).ToList();
        if(targetCollidersInRange.Count == 0)
        {
            return;
        }
        GameObject target = targetCollidersInRange.First().gameObject;
        bulletSpawn.LookAt(target.transform.position+target.transform.forward*1.5f);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<BulletController>().target = target;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;
        //to ju¿ nie jest potrzebne - pocisk bez celu ulega samodestrukcji
        //Destroy(bullet, 2.0f);
    }
}
