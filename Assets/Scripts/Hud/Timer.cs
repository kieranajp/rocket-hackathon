﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float RoundTime = 45;
    public float TimeLeft = 0;

    public Text text;
    private bool _isDone = false;

    // Use this for initialization
    void Start () {
        TimeLeft = RoundTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (_isDone) { return; }

        TimeLeft -= Time.deltaTime;
        text.text = GenerateTime(TimeLeft);
        if (TimeLeft < 0)
        {
            _isDone = true;
            gameObject.BroadcastMessage("OnTimerExpire");
        }
    }

    private void Reset()
    {
        _isDone = false;
        TimeLeft = RoundTime;
    }

    private string GenerateTime(float timeLeft)
    {
        var minutes = (int)(timeLeft / 60);
        var seconds = 0;
        if (minutes != 0) {
            seconds = Mathf.CeilToInt(timeLeft - minutes * 60);
        } else {
            seconds = Mathf.CeilToInt(timeLeft);
        }
        var str = string.Format(minutes.ToString().PadRight(2, '0') + ":" + seconds.ToString().PadRight(2, '0'));
        return str;
    }
}