using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EggsCounter : MonoBehaviour
{
    public double currentTotalEggs = 0f;
    public double clickIncrement = 1f;
    public double EPS = 0f;
    public TMP_Text eggsText;
    string strCurrentTotalEggs;
    double[] bigNumberList = {Math.Pow(10,3), Math.Pow(10, 6), Math.Pow(10, 9), Math.Pow(10, 12), Math.Pow(10, 15), Math.Pow(10, 18) };

    // Start is called before the first frame update
    void Start()
    {
        eggsText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTotalEggs += EPS * Time.fixedDeltaTime;
        eggsText.text = $"{formatNumber(currentTotalEggs)} Eggs";
       
        /*
        if(currentTotalEggs < bigNumberList[0])
        {
            strCurrentTotalEggs = Math.Floor(currentTotalEggs).ToString();
        }
        else if (currentTotalEggs >= bigNumberList[0] &&  currentTotalEggs < bigNumberList[1]) 
        {
            strCurrentTotalEggs = RoundDown(currentTotalEggs / bigNumberList[0], 2).ToString() + "k";
        }
        else if (currentTotalEggs >= bigNumberList[1] && currentTotalEggs < bigNumberList[2])
        {
            strCurrentTotalEggs = RoundDown(currentTotalEggs / bigNumberList[1], 2).ToString() + "m";
        }
        else if (currentTotalEggs >= bigNumberList[2] && currentTotalEggs < bigNumberList[3])
        {
            strCurrentTotalEggs = RoundDown(currentTotalEggs / bigNumberList[2], 2).ToString() + "b";
        }
        else if (currentTotalEggs >= bigNumberList[3] && currentTotalEggs < bigNumberList[4])
        {
            strCurrentTotalEggs = RoundDown(currentTotalEggs / bigNumberList[3], 2).ToString() + "t";
        }
        else if (currentTotalEggs >= bigNumberList[4] && currentTotalEggs < bigNumberList[5])
        {
            strCurrentTotalEggs = RoundDown(currentTotalEggs / bigNumberList[4], 2).ToString() + "aa";
        }
        else if (currentTotalEggs >= bigNumberList[5])
        {
            strCurrentTotalEggs = RoundDown(currentTotalEggs / bigNumberList[5], 2).ToString() + "ab";
        }

        eggsText.text = $"{strCurrentTotalEggs} Eggs";
        */


    }

    string formatNumber(double number)
    {
        string[] bigNumberNotations = { "k", "m", "b", "t", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax","ay", "az" };
        bool highNumber = false;
        double bigNumber = 1000D;
        int tabPosition = -1;
        string notation;
        if (number >= bigNumber)
        {
            highNumber = true;
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


    public double RoundDown(double number, int decimalPlaces)
    {
        return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
    }
}
