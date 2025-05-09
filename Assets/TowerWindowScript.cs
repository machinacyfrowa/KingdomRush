using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerWindowScript : MonoBehaviour
{
    LevelManager levelManager;
    public GameObject? tower;
    public TextMeshProUGUI towerName;
    public TextMeshProUGUI killCount;
    public TextMeshProUGUI rof;
    public TextMeshProUGUI damage;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(tower == null)
        {
            return;
        }
        towerName.text = tower.name;
        killCount.text = "Kill count: " + tower.GetComponent<TowerController>().GetKillCount().ToString();
        rof.text = "Rate of fire: " + tower.GetComponent<TowerController>().fireRate.ToString() + "/s";
        damage.text = "Damage: " + tower.GetComponent<TowerController>().damage.ToString();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void Upgrade()
    {
        if(levelManager.DeductGold(10))
        {
            tower.GetComponent<TowerController>().UpgradeRof();
            tower.GetComponent<TowerController>().UpgradeDamage();
        } 
    }
}
