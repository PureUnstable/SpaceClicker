using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberConverter : MonoBehaviour {

    [SerializeField]
    private GameTime gameTime;

    public string ConvertNumberToString(double num, bool lessThanOne = false)
    {
        //num = Mathf.Floor((float)(num));
        string text = "0";
        double number = num;

        if (num >0 && num < 1 && lessThanOne)
        {
            number = Mathf.Floor((float)(number * 10));
            number /= 10;
            text = number.ToString();
        }
        else if (num >= 1 && num < 1000)
        {
            number = Mathf.Floor((float)(number));
            text = number.ToString();
        }
        else if (num >= 1000 && num < 1000000) // 1,000 to 1,000,000
        {
            number /= 100;
            number = Mathf.Floor((float)(number));
            number /= 10;
            text = NumToString(number, PadText(num)) + "K";
        }
        else if (num >= 1000000 && num < 1000000000) // 1,000,000 to 1,000,000,000
        {
            number /= 100000;
            number = Mathf.Floor((float)(number));
            number /= 10;
            text = NumToString(number, PadText(num)) + "M";
        }
        else if (num >= 1000000000 && num < 1000000000000) // 1,000,000,000 to 1,000,000,000,000
        {
            number /= 100000000;
            number = Mathf.Floor((float)(number));
            number /= 10;
            text = NumToString(number, PadText(num)) + "B";
        }
        else if (num >= 1000000000000 && num < 1000000000000000) // 1,000,000,000,000 to 1,000,000,000,000,000
        {
            number /= 100000000000;
            number = Mathf.Floor((float)(number));
            number /= 10;
            text = NumToString(number, PadText(num)) + "T";
        }

        return text;
    }

    private bool PadText(double n)
    {
        /*if((float)n - Mathf.Floor((float)(n))  == 0f)
        {
            return true;
        }*/
        return false;
    }

    private string NumToString(double num, bool pad)
    {
        if (pad)
            return (num.ToString() + "0");
        return (num.ToString());
    }

    public string ConvertTimeToString()
    {
        string timeText = "";
        if (gameTime.GetYears() > 0)
            timeText =+ gameTime.GetYears() + "y ";
        if(gameTime.GetWeeks() > 0)
            timeText += gameTime.GetWeeks() + "w ";
        if (gameTime.GetDays() > 0)
            timeText += gameTime.GetDays() + "d ";
        if (gameTime.GetHours() > 0)
            timeText += gameTime.GetHours() + "h ";
        if (gameTime.GetMinutes() > 0)
            timeText += gameTime.GetMinutes() + "m ";
        timeText += gameTime.GetSeconds() + "s";
        return timeText;
    }
}
