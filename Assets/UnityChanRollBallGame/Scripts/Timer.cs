using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static int min;
    private static float sec;
    private float oldSec;
    public Text timeText;

    public static int getMinites()
    {
        return min;
    }

    public static float getSeconds()
    {
        return sec;
    }

    // Start is called before the first frame update
    void Start()
    {
        min = getMinites();
        sec = getSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;

        if(sec >= 60f)
        {
            min++;
            sec -= 60;
        }

        // 秒数が変わった時のみUIを更新する
        if ((int)sec != (int)oldSec)
        {
            timeText.text = "Time: " + min.ToString("00") + ":" + ((int)sec).ToString("00");
        }

        oldSec = sec;
    }
}
