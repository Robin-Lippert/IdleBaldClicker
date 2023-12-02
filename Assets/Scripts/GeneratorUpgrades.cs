using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;

public class GeneratorUpgrades : MonoBehaviour
{
    public bool bought = false;
    public double cost = 100;
    string costColor = "\"red\"";

    [Header("Objects")]
    public GameObject genObject;
    public Generator generator;

    TMP_Text buttonText;
    EggsCounter eggsCounter;

    TooltipTrigger tooltipTrigger;
    string tooltipContent;

    public GameObject greyObject;

    public double multiplier = 1;
    void Start()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
        buttonText = gameObject.GetComponentInChildren<TMP_Text>();
        eggsCounter = FindObjectOfType<EggsCounter>();
        buttonText.text = $"<color={costColor}>${eggsCounter.formatNumber(cost)}</color>\n{gameObject.name}";
        tooltipContent = tooltipTrigger.content;
        toolTip();
    }

    private void FixedUpdate()
    {
        if(cost <= eggsCounter.currentTotalEggs) // if cant afford upgrade grey it out
        {
            greyObject.SetActive(false);
        }
        else
        {
            greyObject.SetActive(true);
        }
        buttonText.text = $"<color={costColor}>${eggsCounter.formatNumber(cost)}</color>\n{gameObject.name}";
        toolTip();
    }


    public void OnClick()
    {
        if (eggsCounter.currentTotalEggs >= cost && !bought) // apply upgrade and remove disable it
        {
            generator.upgradeMultiplier *= multiplier;
            generator.totalCurrentEPS = generator.updateGenEPS();
            eggsCounter.EPS = eggsCounter.UpdateCurrentEPS();
            eggsCounter.currentTotalEggs -= cost;
            bought = true;
            gameObject.SetActive(false);
            
        }
    }

    /// <summary>
    /// format the tooltip based on the cost and change color of text
    /// </summary>
    void toolTip()
    {
        if (eggsCounter.currentTotalEggs >= cost)
        {
            costColor = "#006400";
        }
        else
        {
            costColor = "\"red\"";
        }

        tooltipTrigger.header = $"<color={costColor}>${cost}</color>";
    }
}
