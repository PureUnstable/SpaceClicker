using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Building
{

    void Start()
    {
        isShowing = false;
        cost = 1000f;
        multiplierBonus = 1f;
        prestigeBonus = 1f;
        //goldPerOwned = 0.5f;
        goldPerOwned = 10f;
        spriteRenderer.color = new Color(0.19922f, 0.71094f, 0.8125f, 0.25f);
        info.text = "Scout\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
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
        info.text = "Scout\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }


}
