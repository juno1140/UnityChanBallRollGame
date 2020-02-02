using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{

    private int _itemScore;
    private int _min;
    private int _sec;

    public int timeMaxScore = 2000;

    public Text itemScoreText;
    public Text timeText;
    public Text totalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        _itemScore = PlayerController.getScore();
        _min = Timer.getMinites();
        _sec = (int)Timer.getSeconds();

        int totalScore = _itemScore + timeMaxScore - ((_min * 60 + _sec) * 10);

        // 表示する
        itemScoreText.text = "ItemScore: " + _itemScore.ToString();
        timeText.text = "Time: " + _min.ToString("00") + ":" + _sec.ToString("00");
        totalScoreText.text = "TotalScore: " + totalScore;
    }
}
