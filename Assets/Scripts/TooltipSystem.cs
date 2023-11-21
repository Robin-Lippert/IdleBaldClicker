using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem current;

    public Tooltip tooltip;

    public void Awake()
    {
        current = this; 
    }

    public static void Show(string content, bool pivotLeft, string header = "" )
    {
        current.tooltip.SetText(content, pivotLeft, header);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
