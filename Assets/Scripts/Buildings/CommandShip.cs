﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandShip : Building
{

    void Start()
    {
        isShowing = false;
        //cost = 500f;
        cost = 20000000f;
        multiplierBonus = 1f;
        prestigeBonus = 1f;
        goldPerOwned = 8000f;
        //goldPerOwned = 1000f;
        spriteRenderer.color = new Color(0.78516f, 0.16016f, 0.16016f, 0.25f);
        info.text = "Command Ship\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
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
        info.text = "Command Ship\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }
}