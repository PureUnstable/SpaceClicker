using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour {

    [SerializeField]
    private Gold gold;
    [SerializeField]
    private GameObject palominium;
    [SerializeField]
    private BaseClick baseClick;
    //private GameObject cameraInScene;
    //private Vector2 cameraPosition;
    //private Vector2 mousePosition;
    [SerializeField]
    private Camera c;
    [SerializeField]
    private Text achievementDescription;
    private string description;
    [SerializeField]
    private NumberConverter numberConverter;
    private bool isAchievementDesShowing;
    private Vector3 originalDesLocation;

    // Use this for initialization
    void Start()
    {
        isAchievementDesShowing = false;
        originalDesLocation = achievementDescription.transform.position;
        description = achievementDescription.text;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see where the mouse pointer is at. If it is over an achievement, it is shown
        Vector2 mousePos = c.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = new RaycastHit2D();
        hit = Physics2D.Raycast(mousePos, Vector3.forward, 5.0f);

        if (hit != null && hit.collider != null)
        {
            if (hit.collider.GetComponent<Achievement>())
            {
                isAchievementDesShowing = true;
                Achievement ach = hit.collider.GetComponent<Achievement>();
                ShowAchievementDescription(mousePos, ach.GetName(), ach.GetDescription(), ach.GetCost());
            }
            else if (hit.collider.GetComponent<SpecialAchievement>())
            {
                isAchievementDesShowing = true;
                SpecialAchievement ach = hit.collider.GetComponent<SpecialAchievement>();
                ShowAchievementDescription(mousePos, ach.GetName(), ach.GetDescription(), ach.GetCost());
            }

        }

        // If achievement is no longer being hovered over and is still being shown 
        else if (isAchievementDesShowing)
        {
            isAchievementDesShowing = false;
            achievementDescription.transform.position = originalDesLocation;
            achievementDescription.text = "";
        }

        // If mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (hit != null && hit.collider != null)
            {
                if (hit.collider.gameObject == palominium)
                    baseClick.ClickPalonium();
                else if (hit.collider.GetComponent<Building>())
                    hit.collider.GetComponent<Building>().BuyBuilding();
                else if (hit.collider.GetComponent<Achievement>())
                    hit.collider.GetComponent<Achievement>().BuyAchievement(gold.GetTotalGold());
                else if (hit.collider.GetComponent<AchievementHandler>())
                    hit.collider.GetComponent<AchievementHandler>().SetActiveTab();
                else if (hit.collider.GetComponent<QuestHandler>())
                    hit.collider.GetComponent<QuestHandler>().SetActiveTab();
                else if (hit.collider.GetComponent<SpecialAchievement>())
                    hit.collider.GetComponent<SpecialAchievement>().BuyAchievement(gold.GetTotalGold());
            }
        }

    }

    private void ShowAchievementDescription(Vector2 mousePos, string n, string des, double cost)
    {
        achievementDescription.transform.position = new Vector3(mousePos.x, mousePos.y, -9.15f);
        achievementDescription.text = n + "\n" + des + "\nCost: " + numberConverter.ConvertNumberToString(cost) + " Palominium";
    }
}
