using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    GameObject towerWindow;
    public float range = 10f;
    public float fireRate = 1f;
    public float damage = 5f;
    int killCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        towerWindow = GameObject.Find("Canvas").transform.Find("TowerWindow").gameObject;
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Fire()
    {
        while(true) {
            List<Collider> targetCollidersInRange = Physics.OverlapSphere(bulletSpawn.position, range).ToList();
            //odfiltruj elementy bez taga enemy
            targetCollidersInRange = targetCollidersInRange.Where(x => x.CompareTag("Enemy")).ToList();
            //posortuj wed³ug odleg³oœci od wie¿y
            targetCollidersInRange = targetCollidersInRange.OrderBy(x => Vector3.Distance(bulletSpawn.position, x.transform.position)).ToList();
            if(targetCollidersInRange.Count > 0)
            {
                GameObject target = targetCollidersInRange.First().gameObject;
                bulletSpawn.LookAt(target.transform.position+target.transform.forward*1.5f);
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<BulletController>().tower = gameObject;
                bullet.GetComponent<BulletController>().target = target;
                bullet.GetComponent<BulletController>().damage = (int)damage;
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;
            }
            yield return new WaitForSeconds(1f / fireRate);
        }
        
        //to ju¿ nie jest potrzebne - pocisk bez celu ulega samodestrukcji
        //Destroy(bullet, 2.0f);
    }
    private void OnMouseDown()
    {
        //Debug.Log("Clicked on tower: " + gameObject.name);
        //Debug.Log(towerWindow.ToString());
        //przeka¿ do okienka referencjê do wie¿y która je otworzy³a
        towerWindow.GetComponent<TowerWindowScript>().tower = gameObject;
        //otwórz okienko
        towerWindow.SetActive(true);
    }
    public void RegisterKill()
    {
        killCount++;
    }
    public int GetKillCount()
    {
        return killCount;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
    public void UpgradeRof()
    {
        fireRate *= 1.5f;
    }
    public void UpgradeDamage()
    {
        damage *= 1.2f;
    }
}
