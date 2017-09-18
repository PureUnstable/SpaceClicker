using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClick : MonoBehaviour {

    [SerializeField]
    private double goldPerClick;
    [SerializeField]
    private double multiplierBonus;
    [SerializeField]
    private double prestigeBonus;
    [SerializeField]
    private List<Achievement> achievementList;
    [SerializeField]
    private Gold gold;

    void Start()
    {
        goldPerClick = 1f;
        multiplierBonus = 1f;
        prestigeBonus = 1f;
    }

    public void IncreaseMultiplierBonus(double amt)
    {
        multiplierBonus += amt;
    }

    public void IncreaseBase(double amt)
    {
        goldPerClick += amt;
    }

    public double GetGoldPerClick()
    {
        return goldPerClick;
    }

    public double GetMultiplierBonus()
    {
        return multiplierBonus;
    }

    public double GetPrestigeBonus()
    {
        return prestigeBonus;
    }

    public void ClickPalonium()
    {
        gold.IncreaseTotalGold(goldPerClick * multiplierBonus * prestigeBonus);
    }
}
