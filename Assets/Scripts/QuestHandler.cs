using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour {

    private bool isActive;
    [SerializeField]
    private List<Quest> Quests;
    [SerializeField]
    private List<Quest> questsBasic;
    [SerializeField]
    private List<Quest> questsFromRoute;
    [SerializeField]
    private GameObject questTab;
    [SerializeField]
    private List<GameObject> questsFromActiveBuildings;
    [SerializeField]
    private AchievementHandler achievements;

    // Use this for initialization
    void Start()
    {
        SetInactiveTab();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetActiveSetting()
    {
        return isActive;
    }

    public void SetActiveTab()
    {
        achievements.SetInactiveTab();
        isActive = true;
        questTab.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        foreach (GameObject go in questsFromActiveBuildings)
        {
            go.SetActive(true);
        }
    }

    public void SetInactiveTab()
    {
        isActive = false;
        questTab.GetComponent<SpriteRenderer>().color = new Color(0.16f, 0.16f, 0.16f, 1f);
        foreach (GameObject go in questsFromActiveBuildings)
        {
            go.SetActive(false);
        }
    }

    public int GetNumberOfVisibleQuests()
    {
        return Quests.Count;
    }
}
