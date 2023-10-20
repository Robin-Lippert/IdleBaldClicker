using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPSController : MonoBehaviour
{
    public float EPS = 0f;
    public GameObject eggsCount;
    EggsCounter eggsCounter;

    // Start is called before the first frame update
    void Start()
    {
        eggsCounter = eggsCount.GetComponent<EggsCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        eggsCounter.currentTotalEggs += EPS * Time.deltaTime;
    }
}
