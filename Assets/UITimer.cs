using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text TimerText;
    public bool playing;
    public float Timer;
    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60f);
            int seconds = Mathf.FloorToInt(Timer % 60f);
            int milliseconds = Mathf.FloorToInt((Timer * 100) % 100f);
            TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
    }
}
