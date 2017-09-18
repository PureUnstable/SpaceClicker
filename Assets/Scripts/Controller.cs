using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField]
    private Building one;
    [SerializeField]
    private Building two;
    [SerializeField]
    private Building three;
    [SerializeField]
    private Building four;
    [SerializeField]
    private Building five;
    [SerializeField]
    private Building six;
    [SerializeField]
    private Building seven;
    [SerializeField]
    private Building eight;
    [SerializeField]
    private Building nine;
    [SerializeField]
    private GameObject organizer;
    [SerializeField]
    private AchievementHandler achievementHandler;
    [SerializeField]
    private QuestHandler questHandler;
    private float originPos;
    private float speedModifier;

    void Start()
    {
        originPos = organizer.transform.position.y;
        speedModifier = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (organizer.transform.position.z != 0)
        {
            Vector3 pos = organizer.transform.position;
            pos.z = 0f;
            //organizer.transform.position = pos;
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                one.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                two.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                three.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                four.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                five.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                six.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                seven.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                eight.BuyBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                nine.BuyBuilding();
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector2 pos = organizer.transform.position;
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //Debug.Log(pos.y + " || " + originPos);
            pos.y += scroll * speedModifier;
            /*if (pos.y < originPos)
                pos.y = originPos;*/
            
            /*else
                pos.y = originPos;*/
            organizer.transform.position = pos;
        }
    }
}
