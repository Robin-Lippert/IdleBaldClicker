using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShower : MonoBehaviour
{
    public EggsCounter eggsCounter;

    private void FixedUpdate()
    {
        foreach (Transform upgrade in gameObject.transform)
        {
            

            if (upgrade.tag == "GenUpgrade")
            {
                
                GeneratorUpgrades genUpgrade = upgrade.GetComponent<GeneratorUpgrades>();
                if (genUpgrade.cost <= eggsCounter.totalEggs && !genUpgrade.bought)
                {
                    //rint("works");
                    upgrade.gameObject.SetActive(true);
                }
            }
            if (upgrade.tag == "ClickUpgrade")
            {
                ClickUpgrades clickUpgrade = upgrade.GetComponent<ClickUpgrades>();
                if (clickUpgrade.cost <= eggsCounter.totalEggs && !clickUpgrade.bought)
                {
                    upgrade.gameObject.SetActive(true);
                }
            }
        }
    }
}
