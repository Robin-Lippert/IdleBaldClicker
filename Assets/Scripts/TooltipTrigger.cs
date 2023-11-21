using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string header;
    
    [Multiline()]
    public string content;

    public bool pivotLeft = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        TooltipSystem.Show(content, pivotLeft, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
