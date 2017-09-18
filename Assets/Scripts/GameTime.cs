using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

    private float timeSinceLastFrame;
    private float totalTime;
    private int s, m, h, d, w, y;

	// Use this for initialization
	void Start ()
    {
        timeSinceLastFrame = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastFrame = Time.deltaTime;
        totalTime += Time.deltaTime;
        s = Mathf.FloorToInt(totalTime) % 60;
        m = Mathf.FloorToInt(totalTime / 60) % 60;
        h = Mathf.FloorToInt(totalTime / 3600) % 24;
        d = Mathf.FloorToInt(totalTime / 86400) % 7;
        w = Mathf.FloorToInt(totalTime / 604800) % 56;
        y = Mathf.FloorToInt(totalTime / 33868800);
	}

    public float GetTimeSinceLastFrame()
    {
        return timeSinceLastFrame;
    }

    public int GetSeconds()
    {
        return s;
    }

    public int GetMinutes()
    {
        return m;
    }

    public int GetHours()
    {
        return h;
    }

    public int GetDays()
    {
        return d;
    }

    public int GetWeeks()
    {
        return w;
    }

    public int GetYears()
    {
        return y;
    }
}
