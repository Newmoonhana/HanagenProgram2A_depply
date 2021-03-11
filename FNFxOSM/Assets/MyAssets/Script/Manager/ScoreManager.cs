using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//판정에 따른 점수.
public static class Score
{
    public static int miss = -10;
    public static int bad = 75;
    public static int good = 100;
    public static int cool = 125;
    public static int perfect = 150;
}

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  //점수 표시.
    public Text multiText;  //점수 배율 표시.

    //변수.
    public int currentScore    //점수.
    {
        get;
        set;
    }
    public int currentMultiplier   //콤보에 의한 점수 배율.
    {
        get;
        set;
    }
    //다음 승수로 이동해야하는 시기를 추적하는 방법.
    int _multiplierTracker = 0;
    public int multiplierTracker
    {
        get { return _multiplierTracker; }
        set
        {
            //점수 배율 계산.
            _multiplierTracker = value;
            if (currentMultiplier - 1 >= 0)
                if (currentMultiplier - 1 < multiplierThresholds.Length)
                {
                    if (multiplierThresholds[currentMultiplier - 1] <= _multiplierTracker)
                    {
                        _multiplierTracker = 0;
                        currentMultiplier++;
                    }
                }
            SetSMText();
        }
    }
    int[] multiplierThresholds = new int[3];  //임계값.

    public ScoreManager()
    {
        //초기값.
        multiplierThresholds[0] = 4;
        multiplierThresholds[1] = 8;
        multiplierThresholds[2] = 16;
    }

    public void SetSMText() //텍스트 새로고침.
    {
        scoreText.text = "Score : " + currentScore.ToString();   //점수 텍스트 새로고침.
        multiText.text = "Multiplier : x" + currentMultiplier.ToString();   //점수 배율 텍스트 새로고침.
    }
}