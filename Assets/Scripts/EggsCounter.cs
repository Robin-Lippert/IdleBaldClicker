using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EggsCounter : MonoBehaviour
{
    public double currentTotalEggs = 0f;
    public double totalEggs = 0f;
    public double clickIncrement = 1f;
    public double EPS = 0f;
    public float totalMultiplier = 1;
    public TMP_Text eggsText;
    public TMP_Text epsText;
   

    // Start is called before the first frame update
    void Start()
    {
        eggsText = GetComponent<TMP_Text>();
        EPS = UpdateCurrentEPS();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTotalEggs += EPS * Time.fixedDeltaTime;
        totalEggs += EPS * Time.fixedDeltaTime;
        eggsText.text = $"{formatNumber(currentTotalEggs)} Eggs";

    }

    public string formatNumber(double number)
    {
        string[] bigNumberNotations = { "k", "m", "b", "t", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax","ay", "az","ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl", "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx", "by", "bz", "ca" };
        //bool highNumber = false;
        double bigNumber = 1000D;
        int tabPosition = -1;
        string notation;
        if (number >= bigNumber)
        {
            //highNumber = true;
            while(number >= bigNumber) { bigNumber *= 1000; tabPosition++; }
            number /= (bigNumber /1000);
            notation = bigNumberNotations[tabPosition];
            return RoundDown(number, 2) + notation;
        }
        else 
        {
            notation = "";
            return RoundDown(number, 0) + notation;
        }
    }

    public double UpdateCurrentEPS()
    {
        double currentEPS = 0;
        GameObject[] generators = GameObject.FindGameObjectsWithTag("generator");
        foreach (GameObject generator in generators) 
        {
            Generator generator1 = generator.GetComponent<Generator>();
            currentEPS += generator1.totalCurrentEPS;
        }
        currentEPS *= totalMultiplier;
        epsText.text = currentEPS.ToString() + " EPS";
        print(currentEPS);
        return currentEPS;
    }


    public double RoundDown(double number, int decimalPlaces)
    {
        return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
    }
}
