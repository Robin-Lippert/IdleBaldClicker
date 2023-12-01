using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;

public class GeneratorUpgrades : MonoBehaviour, IPointerEnterHandler
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
        buttonText.text = $"{gameObject.name}";
        tooltipContent = tooltipTrigger.content;
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
    }

    /// <summary>
    /// format the tooltip based on the cost and change color of text
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
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
}
