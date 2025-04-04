using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    int gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + gold.ToString();
    }
    public void AddGold(int amount)
    {
        gold += amount;
    }
}
