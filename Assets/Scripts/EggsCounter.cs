using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EggsCounter : MonoBehaviour
{
    public float currentTotalEggs = 0f;
    public float clickIncrement = 1f;
    public float EPS = 0f;
    public TMP_Text eggsText;

    // Start is called before the first frame update
    void Start()
    {
        eggsText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
    
        eggsText.text = $"{Math.Floor(currentTotalEggs)} Eggs";
    }
}
