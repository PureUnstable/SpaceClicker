using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDestroyer : Building {

    void Start()
    {
        isShowing = false;
        cost = 350000000f;
        multiplierBonus = 1f;
        prestigeBonus = 1f;
        goldPerOwned = 45000f;
        //goldPerOwned = 500000000f;
        spriteRenderer.color = new Color(0.78516f, 0.16016f, 0.16016f, 0.25f);
        info.text = "Planet Destroyer\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }

    void Update()
    {
        //gold.IncreaseTotalGold(baseGoldPerSecond * multiplierBonus * prestigeBonus * Time.deltaTime);
        if (isShowing && gold.GetTotalGold() < cost)
        {
            isShowing = false;
            spriteRenderer.color = new Color(0.78516f, 0.16016f, 0.16016f, 0.25f);
        }
        else if (!isShowing && gold.GetTotalGold() >= cost)
        {
            isShowing = true;
            spriteRenderer.color = new Color(0.78516f, 0.16016f, 0.16016f, 1f);
        }
    }

    void OnGUI()
    {
        info.text = "Planet Destroyer\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }

}
