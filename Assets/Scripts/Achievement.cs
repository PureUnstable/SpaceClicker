using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AchievementType
{
    Basic,
    Pacifist,
    War
}

public class Achievement : MonoBehaviour {

    [SerializeField]
    private string achievementName;
    [SerializeField]
    private Building parentBuilding;
    [SerializeField]
    private double multiplierBonus;
    [SerializeField]
    private string description;
    [SerializeField]
    private int revealLevel;
    [SerializeField]
    private double cost;
    private bool isActive;
    private bool isShowing;
    [SerializeField]
    private AchievementHandler ah;
    [SerializeField]
    private Gold gold;
    [SerializeField]
    private AchievementType achievementType;
    private Texture texture;
    private Color activeColor;
    private Color inactiveColor;

    void Start()
    {
        isActive = false;
        isShowing = false;
        /*spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = parentBuilding.GetComponent<SpriteRenderer>().color;
        if (spriteRenderer.color.a != 1f)
        {
            inactiveColor = spriteRenderer.color;
            activeColor = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, 1f);
        }
        else
        {
            activeColor = spriteRenderer.color;
            inactiveColor = new Color(activeColor.r, activeColor.g, activeColor.b, 0.25f);
        }*/
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        
    }

    void Update()
    {
        if(!isActive)
        {
            if(parentBuilding.GetNumberOwned() >= revealLevel)
                RevealAchievement();
        }
        if (isShowing && gold.GetTotalGold() < cost)
        {
            isShowing = false;
            //spriteRenderer.color = inactiveColor;
        }
        else if (!isShowing && gold.GetTotalGold() >= cost)
        {
            isShowing = true;
            //spriteRenderer.color = activeColor;
        }
    }

    private void RevealAchievement()
    {
        isActive = true;
        ah.SetAchievementVisible(this);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public string GetName()
    {
        return achievementName;
    }

    public string GetDescription()
    {
        return description;
    }

    public double GetCost()
    {
        return cost;
    }

    public void BuyAchievement(double totalGold)
    {
        if(totalGold >= cost)
        {
            parentBuilding.IncreaseMultiplierBonus(multiplierBonus);
            gold.DecreaseTotalGold(cost);
            ah.RemoveAchievement(this);
            Destroy(this.gameObject);
        }
    }
}
