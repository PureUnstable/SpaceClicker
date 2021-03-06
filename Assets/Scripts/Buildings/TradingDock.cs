﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingDock : Building {

    void Start()
    {
        isShowing = false;
        cost = 1500000f;
        multiplierBonus = 1f;
        prestigeBonus = 1f;
        goldPerOwned = 1500f;
        //goldPerOwned = 50000f;
        spriteRenderer.color = new Color(0.23047f, 0.34766f, 0.90234f, 0.25f);
        info.text = "Trading Station\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }

    void Update()
    {
        //gold.IncreaseTotalGold(baseGoldPerSecond * multiplierBonus * prestigeBonus * Time.deltaTime);
        if (isShowing && gold.GetTotalGold() < cost)
        {
            isShowing = false;
            spriteRenderer.color = new Color(0.23047f, 0.34766f, 0.90234f, 0.25f);
        }
        else if (!isShowing && gold.GetTotalGold() >= cost)
        {
            isShowing = true;
            spriteRenderer.color = new Color(0.23047f, 0.34766f, 0.90234f, 1f);
        }
    }

    void OnGUI()
    {
        info.text = "Trading Station\nGenerating Per Second: " + numberConverter.ConvertNumberToString(baseGoldPerSecond * multiplierBonus * prestigeBonus) + "\nTotal: " + numberOwned + " Cost: " + numberConverter.ConvertNumberToString(cost);
    }
}
