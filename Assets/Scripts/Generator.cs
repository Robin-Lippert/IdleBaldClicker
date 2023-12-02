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
    public double costMultiplier = 1.1;// the multiplier that gets aplied to the cost each time a new gen is bought

    bool unlocked = false;
    public GameObject greyObject;
    string costColor = "\"red\"";

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
        genText.text = $"<color={costColor}>${cost}</color>\n???????: {numberOfGenerators}"; // format text of button
        toolTip();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalCurrentEPS = updateGenEPS();

        // get the colour that the cost text needs to be
        if (cost <= eggsCounter.currentTotalEggs)
        {
            greyObject.SetActive(false);
            costColor = "#006400";
        }
        else
        {
            greyObject.SetActive(true);
            costColor = "\"red\"";
        }

        genText.text = $"<color={costColor}>${eggsCounter.formatNumber(cost)}</color>\n{gameObject.name}: {numberOfGenerators}";

        //change color of cost and format text
        if (cost <= eggsCounter.totalEggs && !unlocked)
        {
           
            unlocked = true;
            greyObject.SetActive(false);
        }


        toolTip();

    }

    /// <summary>
    /// add 1 gen and update the total eps based on the value of that gen
    /// </summary>
    public void ClickButton()
    {
        if (cost <= eggsCounter.currentTotalEggs)
        {
            eggsCounter.currentTotalEggs -= cost;
            numberOfGenerators++;
            cost *= costMultiplier;
            

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

    /// <summary>
    /// Formats tool tip of genorator and gets the percent of the eps it contributes
    /// </summary>
    void toolTip()
    {
        double percent;
        if(totalCurrentEPS == 0)
        {
            percent = 0;
        }
        else
        {
            percent = (totalCurrentEPS / eggsCounter.EPS) * 100;
        }

        string name;

        if (!unlocked)
        {
            name = "???????";
        }
        else
        {
            name = gameObject.name;
        }

        tooltipTrigger.header = $"{name}";
        tooltipTrigger.content = $"each makes <b>{individualEPS} eggs</b> per second \n" +
            $"{numberOfGenerators} {name} make <b>{totalCurrentEPS} eggs</b> per second" +
            $"\n {percent.ToString("f0")}% of total EPS";
    }
}
