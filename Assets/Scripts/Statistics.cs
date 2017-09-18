using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour {

    [SerializeField]
    private NumberConverter numberConverter;
    [SerializeField]
    private Gold gold;
    [SerializeField]
    private Text statisticsText;
	
	// Update is called once per frame
	void OnGUI () {
        statisticsText.text = "Total Per Second: " + numberConverter.ConvertNumberToString(gold.GetTotalGoldPerSecond(), true) + "\nGenerating Per Click: " + gold.GetGoldPerClick() + "\nMax Gold: " + numberConverter.ConvertNumberToString(gold.GetMaxGold()) +  "\nTotal Play Time: " + numberConverter.ConvertTimeToString();
	}
}
