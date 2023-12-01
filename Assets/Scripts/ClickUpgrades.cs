using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickUpgrades : MonoBehaviour, IPointerEnterHandler
{
    public bool bought = false;
    public double cost = 100;
    string costColor = "\"red\"";



    TMP_Text buttonText;
    EggsCounter eggsCounter;

    TooltipTrigger tooltipTrigger;
    string tooltipContent;

    public GameObject greyObject;

    public double multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
        buttonText = gameObject.GetComponentInChildren<TMP_Text>();
        eggsCounter = FindObjectOfType<EggsCounter>();
        buttonText.text = $"{gameObject.name}";
        tooltipContent = tooltipTrigger.content;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cost <= eggsCounter.currentTotalEggs)
        {
            greyObject.SetActive(false);
        }
        else
        {
            greyObject.SetActive(true);
        }
    }

    public void OnClick()
    {
        if (eggsCounter.currentTotalEggs >= cost && !bought)
        {
            eggsCounter.clickIncrement *= multiplier;
            eggsCounter.EPS = eggsCounter.UpdateCurrentEPS();
            eggsCounter.currentTotalEggs -= cost;
            bought = true;
            gameObject.SetActive(false);

        }
    }

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
}
