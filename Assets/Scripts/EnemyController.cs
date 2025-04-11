using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //path to jest obiekt zawierające kolejne waypointy jako obiekty potomne
    public GameObject path;
    public float speed = 5.0f;
    LevelManager levelManager;
    List<Transform> waypoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        //iteruj przez kolejne waypointy i dodaj je do listy waypoints
        for (int i = 0; i < path.transform.childCount; i++)
        {
            waypoints.Add(path.transform.GetChild(i).gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(waypoints.Count == 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.LookAt(waypoints.First());
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(Vector3.Distance(transform.position, waypoints.First().position) < 0.1f)
        {
            waypoints.RemoveAt(0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision!");
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.gameObject.GetComponent<BulletController>()
                                .tower.GetComponent<TowerController>().RegisterKill();
            levelManager.AddGold(1);
            Destroy(gameObject);
        }
    }
}
