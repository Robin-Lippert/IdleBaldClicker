using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Generator : MonoBehaviour
{

    public double totalCurrentEPS = 0;
    public double indivdualEPS = 1;
    public int numberOfGenerators = 0;
    public double upgradeBonus = 1;
    public double baseCost = 10;
    double cost;
    public double costMultiplier = 1.1;

    public GameObject eggsCount;
    EggsCounter eggsCounter;
    TMP_Text genText;

    // Start is called before the first frame update
    void Start()
    {
        genText = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        eggsCounter = eggsCount.GetComponent<EggsCounter>();
        cost = baseCost;
        genText.text = $"${cost}\n{gameObject.name}: {numberOfGenerators}";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalCurrentEPS = indivdualEPS * numberOfGenerators * upgradeBonus;
    }
    
    public void ClickButton()
    {
        if(cost <= eggsCounter.currentTotalEggs)
        {
            eggsCounter.currentTotalEggs -= cost;
            numberOfGenerators++;
            cost *= costMultiplier;
            genText.text = $"${eggsCounter.formatNumber(cost)}\n{gameObject.name}: {numberOfGenerators}";
            
        }
        totalCurrentEPS = indivdualEPS * numberOfGenerators * upgradeBonus;
        eggsCounter.EPS = eggsCounter.UpdateCurrentEPS();
    }
}
