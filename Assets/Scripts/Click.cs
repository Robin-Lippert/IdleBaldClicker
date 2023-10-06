using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    Animator animator;
    public GameObject eggsCount;
    EggsCounter eggsCounter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        eggsCounter = eggsCount.GetComponent<EggsCounter>();
    }

    public void ClickButton()
    {
        animator.SetTrigger("Clicked");
        eggsCounter.currentTotalEggs += eggsCounter.clickIncrement;
        
    }
}
