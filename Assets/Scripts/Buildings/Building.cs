using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour {

    [SerializeField]
    protected double goldPerOwned;
    [SerializeField]
    protected double baseGoldPerSecond;
    [SerializeField]
    protected double multiplierBonus;
    [SerializeField]
    protected double prestigeBonus;
    [SerializeField]
    protected double cost;
    [SerializeField]
    protected int numberOwned;
    [SerializeField]
    protected List<Achievement> achievementList;
    [SerializeField]
    protected Gold gold;
    [SerializeField]
    protected Text info;
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    protected bool isShowing;
    [SerializeField]
    protected NumberConverter numberConverter;

    void Start()
    {
        baseGoldPerSecond = 0f;
        numberOwned = 0;
        isShowing = false;
    }

    void Update()
    {
        gold.IncreaseTotalGold(baseGoldPerSecond * multiplierBonus * prestigeBonus * Time.deltaTime);
    }

    public void IncreaseMultiplierBonus(double amt)
    {
        gold.DecreaseTotalGoldPerSecond(baseGoldPerSecond * multiplierBonus * prestigeBonus);
        multiplierBonus += amt;
        gold.IncreaseTotalGoldPerSecond(baseGoldPerSecond * multiplierBonus * prestigeBonus);
    }

    public void IncreaseBase(double amt)
    {
        gold.DecreaseTotalGoldPerSecond(baseGoldPerSecond * multiplierBonus * prestigeBonus);
        baseGoldPerSecond += amt;
        gold.IncreaseTotalGoldPerSecond(baseGoldPerSecond * multiplierBonus * prestigeBonus);
    }

    public double GetGoldPerSecond()
    {
        return baseGoldPerSecond;
    }

    public double GetMultiplierBonus()
    {
        return multiplierBonus;
    }

    public double GetPrestigeBonus()
    {
        return prestigeBonus;
    }

    public int GetNumberOwned()
    {
        return numberOwned;
    }

    public void BuyBuilding()
    {
        if(gold.GetTotalGold() >= cost)
        {
            gold.DecreaseTotalGold(cost);
            numberOwned++;
            cost *= 1.15f;
            double oldGPS = baseGoldPerSecond * multiplierBonus * prestigeBonus;
            baseGoldPerSecond += goldPerOwned;
            gold.DecreaseTotalGoldPerSecond(oldGPS);
            gold.IncreaseTotalGoldPerSecond(baseGoldPerSecond * multiplierBonus * prestigeBonus);
        }
    }
}
