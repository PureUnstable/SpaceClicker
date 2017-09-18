using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freighter : Building
{

    void Start()
    {
        isShowing = false;
        //cost = 500f;
        cost = 100f;
        multiplierBonus = 1f;
        prestigeBonus = 1f;
        goldPerOwned = 1f;
        //goldPerOwned = 1000f;
        spriteRenderer.color = new Color(0.19922f, 0.71094f, 0.8125f, 0.25f);
        info.text = "Freighter\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }

    void Update()
    {
        //gold.IncreaseTotalGold(baseGoldPerSecond * multiplierBonus * prestigeBonus * Time.deltaTime);
        if (isShowing && gold.GetTotalGold() < cost)
        {
            isShowing = false;
            spriteRenderer.color = new Color(0.19922f, 0.71094f, 0.8125f, 0.25f);
        }
        else if (!isShowing && gold.GetTotalGold() >= cost)
        {
            isShowing = true;
            spriteRenderer.color = new Color(0.19922f, 0.71094f, 0.8125f, 1f);
        }
    }

    void OnGUI()
    {
        info.text = "Freighter\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }
}
