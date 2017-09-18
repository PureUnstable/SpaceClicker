using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {

    private double maxGold;
    private double totalGold;
    private double totalGoldPerSecond;
    private double totalMultiplier;
    [SerializeField]
    private GameTime time;
    [SerializeField]
    private Text goldText;
    [SerializeField]
    private NumberConverter numberConverter;
    private double goldPerClickMultiplier;
    private double goldFromClick;

	void Start ()
    {
        maxGold = 0;
        totalGold = 0;
        totalMultiplier = 1;
        goldFromClick = 1f;
        goldPerClickMultiplier = 1f;
        goldText.text = "Palonium: " + numberConverter.ConvertNumberToString(totalGold);
	}
	
	void LateUpdate ()
    {
        totalGold += time.GetTimeSinceLastFrame() * totalGoldPerSecond;
        goldText.text = "Palonium: " + numberConverter.ConvertNumberToString(totalGold);
    }

    /*void OnGUI()
    {
        goldText.text = "Palominium: " + numberConverter.ConvertNumberToString(totalGold);
    }*/

    public void IncreaseGoldFromClick()
    {
        totalGold += goldFromClick;
        maxGold += goldFromClick;
    }

    public void IncreaseTotalGold(double amt)
    {
        totalGold += amt;
        maxGold += amt;
    }

    public void DecreaseTotalGold(double amt)
    {
        totalGold -= amt;
    }

    public void IncreaseTotalGoldPerSecond(double amt)
    {
        totalGoldPerSecond += amt;
    }

    public void DecreaseTotalGoldPerSecond(double amt)
    {
        totalGoldPerSecond -= amt;
    }

    /*public void IncreaseGoldPerSecond(double amt)
    {
        totalGoldPerSecond += amt;
    }

    public void IncreaseMultiplierBonus(double amt)
    {
        totalMultiplier += amt;
    }*/

    public double GetMaxGold()
    {
        return maxGold;
    }

    public double GetTotalGold()
    {
        return totalGold;
    }

    public double GetTotalGoldPerSecond()
    {
        return totalGoldPerSecond;
    }

    public double GetGoldPerClick()
    {
        return goldFromClick * goldPerClickMultiplier;
    }
}
