using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggsCounter : MonoBehaviour
{
    public float currentTotalEggs = 0f;
    public float clickIncrement = 1f;
    public TMP_Text eggsText;

    // Start is called before the first frame update
    void Start()
    {
        eggsText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        eggsText.text = $"{currentTotalEggs} Eggs";
    }
}
