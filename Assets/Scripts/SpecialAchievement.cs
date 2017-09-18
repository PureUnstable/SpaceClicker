using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EffectType
{
    Remove,
    Enable
}

enum AffectType
{
    Remove,
    Enable,
    BoostBase,
    BoostMult
}

public class SpecialAchievement : MonoBehaviour {

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
    private SpriteRenderer spriteRenderer;
    private Color activeColor;
    private Color inactiveColor;
    [SerializeField]
    private AchievementType achievementType;
    [SerializeField]
    [Tooltip("What this special upgrade is going to affect (beginning)")]
    private AffectType affectType;
    [SerializeField]
    [Tooltip("What this special upgrade is going to effect (end)")]
    private EffectType effectType;
    [SerializeField]
    private List<GameObject> affectingObjects;
    [SerializeField]
    private List<GameObject> effectedObjects;
    


    void Start()
    {
        
        isActive = false;
        isShowing = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = parentBuilding.GetComponent<SpriteRenderer>().color;
        /*if (spriteRenderer.color.a != 1f)
        {*/
            inactiveColor = spriteRenderer.color;
            inactiveColor = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, 0.25f);
            activeColor = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, 1f);
            spriteRenderer.color = inactiveColor;

            foreach (GameObject go in affectingObjects)
                go.SetActive(false);
        /*}
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
        if (affectType == AffectType.Enable || affectType == AffectType.Remove)
        {
            if (!isActive)
            {
                if (parentBuilding.GetNumberOwned() >= revealLevel)
                    RevealSpecialAchievement();
            }
            if (isShowing && gold.GetTotalGold() < cost)
            {
                isShowing = false;
                spriteRenderer.color = inactiveColor;
            }
            else if (!isShowing && gold.GetTotalGold() >= cost)
            {
                isShowing = true;
                spriteRenderer.color = activeColor;
            }
        }
        else
        {
            if (!isActive)
            {
                if (parentBuilding.GetNumberOwned() >= revealLevel)
                    RevealSpecialAchievement();
            }
            if (isShowing && gold.GetTotalGold() < cost)
            {
                isShowing = false;
                spriteRenderer.color = inactiveColor;
            }
            else if (!isShowing && gold.GetTotalGold() >= cost)
            {
                isShowing = true;
                spriteRenderer.color = activeColor;
            }
        }
    }

    private void RevealSpecialAchievement()
    {
        isActive = true;
        ah.SetSpecialAchievementVisible(this);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void SpecialProperties()
    {
        if (affectType == AffectType.Remove)
        {
            foreach (GameObject go in affectingObjects)
            {
                Destroy(go);
            }
        }
        else if (affectType == AffectType.Enable)
        {
            foreach (GameObject go in affectingObjects)
            {
                go.SetActive(true);
            }
        }
        else if(affectType == AffectType.BoostBase)
        {
            foreach (GameObject go in affectingObjects)
            {
                go.GetComponent<Building>().IncreaseBase(multiplierBonus);
            }
        }
        else if (affectType == AffectType.BoostMult)
        {
            foreach (GameObject go in affectingObjects)
            {
                go.GetComponent<Building>().IncreaseMultiplierBonus(multiplierBonus);
            }
        }
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
        if (totalGold >= cost)
        {
            //parentBuilding.PurchaseUpgrade(cost);
            //parentBuilding.IncreaseMultiplierBonus(multiplierBonus);
            gold.DecreaseTotalGold(cost);
            SpecialProperties();
            if(effectType == EffectType.Remove)
            {
                foreach(GameObject go in effectedObjects)
                {
                    ah.RemoveSpecialAchievement(go.GetComponent<SpecialAchievement>());
                    Destroy(go);
                }
            }
            else
            {
                foreach(GameObject go in effectedObjects)
                {
                    ah.RemoveSpecialAchievement(go.GetComponent<SpecialAchievement>());
                    go.SetActive(true);
                }
            }
            ah.RemoveSpecialAchievement(this);
            Destroy(this.gameObject);
        }
    }
}
