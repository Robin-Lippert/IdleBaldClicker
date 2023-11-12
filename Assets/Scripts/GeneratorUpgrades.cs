using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneratorUpgrades : MonoBehaviour
{ 

    public GameObject genObject;
    Generator generator;
    TMP_Text buttonText;
    EggsCounter eggsCounter;

    public double multiplier = 1;
    void Start()
    {
        generator = genObject.GetComponent<Generator>();
        buttonText = gameObject.GetComponentInChildren<TMP_Text>();
        eggsCounter = FindObjectOfType<EggsCounter>();
        buttonText.text = $"{genObject.name}\nupgrade";
    }

    public void OnClick()
    {
        generator.upgradeMultiplier *= multiplier;
        generator.totalCurrentEPS = generator.updateGenEPS();
        eggsCounter.EPS = eggsCounter.UpdateCurrentEPS();
        gameObject.SetActive(false);
    }
}
