using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    [SerializeField]
    private string questName;
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

    void Start()
    {
        isActive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if (parentBuilding.GetNumberOwned() >= revealLevel)
        {
            RevealQuest();
        }
    }

    private void RevealQuest()
    {
        isActive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public string GetName()
    {
        return questName;
    }

    public string GetDescription()
    {
        return description;
    }

    public double GetCost()
    {
        return cost;
    }

    public void BuyQuest(double totalGold)
    {
        if (totalGold >= cost)
        {
            parentBuilding.IncreaseMultiplierBonus(multiplierBonus);
            Destroy(this.gameObject);
        }
    }
}
