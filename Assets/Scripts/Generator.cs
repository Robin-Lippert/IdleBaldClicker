using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{

    public double totalCurrentEPS = 0;
    public double indivdualEPS = 1;
    public int numberOfGenerators = 0;
    public double upgradeBonus = 1;
    public double baseCost = 10;
    double cost;
    public double costMultiplier = 1.1;

    bool unlocked = false;
    public GameObject greyObject;

    //public GameObject eggsCount;
    EggsCounter eggsCounter;
    TMP_Text genText;

    // Start is called before the first frame update
    void Start()
    {
        genText = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        eggsCounter = FindObjectOfType<EggsCounter>();
        cost = baseCost;
        genText.text = $"${cost}\n???????: {numberOfGenerators}";
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        totalCurrentEPS = indivdualEPS * numberOfGenerators * upgradeBonus;
        if (cost <= eggsCounter.totalEggs && !unlocked) 
        {
            genText.text = $"${cost}\n{gameObject.name}: {numberOfGenerators}";
            unlocked=true;
            greyObject.SetActive(false);
        }

        if (cost <= eggsCounter.currentTotalEggs)
        {
            greyObject.SetActive(false);
        }
        else
        {
            greyObject.SetActive(true);
        }
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
