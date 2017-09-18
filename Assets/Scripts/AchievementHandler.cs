using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementHandler : MonoBehaviour {

    private bool isActive;
    [SerializeField]
    private List<Achievement> achievementsAll;
    [SerializeField]
    private List<Achievement> achievementsBasic;
    [SerializeField]
    private List<Achievement> achievementsFromRoute;
    [SerializeField]
    private List<Achievement> achievementsVisible;
    [SerializeField]
    private List<SpecialAchievement> specialAchievementsAll;
    [SerializeField]
    private List<SpecialAchievement> specialAchievementsBasic;
    [SerializeField]
    private List<SpecialAchievement> specialAchievementsFromRoute;
    [SerializeField]
    private List<SpecialAchievement> specialAchievementsVisible;
    [SerializeField]
    private GameObject achievementTab;
    [SerializeField]
    private List<GameObject> achievements;
    [SerializeField]
    private QuestHandler quests;
    [SerializeField]
    private GameObject achievementOrganizer;
    private int numberActiveAchievements;
    private int numberActiveSpecialAchievements;


    // Use this for initialization
    void Start ()
    {
        SetActiveTab();
        foreach (Achievement a in achievementsBasic)
            achievementsAll.Add(a);
        foreach (SpecialAchievement s in specialAchievementsBasic)
            specialAchievementsAll.Add(s);
        numberActiveAchievements = 0;
        numberActiveSpecialAchievements = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool GetActiveSetting()
    {
        return isActive;
    }

    public void SetActiveTab()
    {
        quests.SetInactiveTab();
        isActive = true;
        achievementTab.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        //foreach(GameObject go in achievements)
        foreach (SpecialAchievement s in specialAchievementsVisible)
        {
            s.gameObject.SetActive(true);
        }
        foreach (Achievement a in achievementsVisible)
        {
            a.gameObject.SetActive(true);
        }
    }

    public void SetInactiveTab()
    {
        isActive = false;
        achievementTab.GetComponent<SpriteRenderer>().color = new Color(0.16f, 0.16f, 0.16f, 1f);
        foreach (SpecialAchievement s in specialAchievementsVisible)
        {
            s.gameObject.SetActive(false);
        }
        foreach (Achievement a in achievementsVisible)
        {
            a.gameObject.SetActive(false);
        }
    }

    public void SetAchievementVisible(Achievement ach)
    {
        numberActiveAchievements++;
        achievementsVisible.Add(ach);
        ach.gameObject.transform.parent = achievementOrganizer.transform;
        SortAchievementList();
    }

    public void SetSpecialAchievementVisible(SpecialAchievement ach)
    {
        numberActiveSpecialAchievements++;
        specialAchievementsVisible.Add(ach);
        ach.gameObject.transform.parent = achievementOrganizer.transform;
        SortAchievementList();
    }


    public void RemoveAchievement(Achievement ach)
    {
        achievementsAll.Remove(ach);
        if (achievementsBasic.Contains(ach))
            achievementsBasic.Remove(ach);
        else
            achievementsFromRoute.Remove(ach);
        //achievementsBasic.Remove(ach);
        
        achievementsVisible.Remove(ach);
        SortAchievementList();
    }

    public void RemoveSpecialAchievement(SpecialAchievement ach)
    {
        specialAchievementsAll.Remove(ach);
        if (specialAchievementsBasic.Contains(ach))
            specialAchievementsBasic.Remove(ach);
        else
            specialAchievementsFromRoute.Remove(ach);
        //specialAchievementsBasic.Remove(ach);

        specialAchievementsVisible.Remove(ach);
        SortAchievementList();
    }

    private void SortAchievementList()
    {
        Vector2 pos = achievementOrganizer.transform.position;
        int i = 0;
        int r = 0;
        foreach (SpecialAchievement s in specialAchievementsVisible)
        {
            Vector2 posNew = pos;
            if (i > 5)
            {
                r++;
                i = 0;
            }
            posNew.x += 0.75f * i;
            posNew.y += r * -0.75f;
            s.gameObject.transform.position = posNew;
            i++;
        }
        foreach (Achievement a in achievementsVisible)
        {
            Vector2 posNew = pos;
            if (i > 5)
            {
                r++;
                i = 0;
            }
            posNew.x += 0.75f * i;
            posNew.y += r * -0.75f;
            a.gameObject.transform.position = posNew;
            i++;
        }
    }

    public int GetNumberOfVisibleAchievements()
    {
        return achievementsVisible.Count;
    }

    public int GetNumberOfVisibleSpecialAchievements()
    {
        return specialAchievementsVisible.Count;
    }
}
