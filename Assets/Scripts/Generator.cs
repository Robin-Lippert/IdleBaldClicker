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
    public double startingEPS = 1;
    public double individualEPS;
    public int numberOfGenerators = 0;
    public double upgradeMultiplier = 1;
    public double baseCost = 10;
    double cost;
    public double costMultiplier = 1.1;

    bool unlocked = false;
    public GameObject greyObject;

    EggsCounter eggsCounter;
    TMP_Text genText;
    TooltipTrigger tooltipTrigger;

    // Start is called before the first frame update
    void Start()
    {
        genText = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        eggsCounter = FindObjectOfType<EggsCounter>();
        tooltipTrigger = gameObject.GetComponent<TooltipTrigger>();
        cost = baseCost;
        genText.text = $"${cost}\n???????: {numberOfGenerators}";
        toolTip();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalCurrentEPS = updateGenEPS();
        if (cost <= eggsCounter.totalEggs && !unlocked)
        {
            genText.text = $"${cost}\n{gameObject.name}: {numberOfGenerators}";
            unlocked = true;
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
        toolTip();

    }

    public void ClickButton()
    {
        if (cost <= eggsCounter.currentTotalEggs)
        {
            eggsCounter.currentTotalEggs -= cost;
            numberOfGenerators++;
            cost *= costMultiplier;
            genText.text = $"${eggsCounter.formatNumber(cost)}\n{gameObject.name}: {numberOfGenerators}";

        }
        totalCurrentEPS = updateGenEPS();
        eggsCounter.EPS = eggsCounter.UpdateCurrentEPS();
        toolTip();
    }

    public double updateGenEPS()
    {
        individualEPS = startingEPS * upgradeMultiplier;
        return individualEPS * numberOfGenerators;
    }

    void toolTip()
    {
        tooltipTrigger.header = $"{gameObject.name}";
        tooltipTrigger.content = $"each makes <b>{individualEPS} eggs</b> per second \n" +
            $"{numberOfGenerators} {gameObject.name} make <b>{totalCurrentEPS} eggs</b> per second" +
            $"\n {((totalCurrentEPS / eggsCounter.EPS) * 100).ToString("f0")}% of total EPS";
    }
}
