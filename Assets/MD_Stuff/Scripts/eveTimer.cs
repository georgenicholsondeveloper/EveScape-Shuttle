using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class eveTimer : MInheretance {

    [SerializeField]
    private float timer = 0;
    [SerializeField]
    private int sec = 0;
    [SerializeField]
    private float mMin = 0;

    private string timeString;
    private bool hardReset = false;
    private float EndTimer;
    private bool endgame = false;

    public GameObject EndCanvas;
    public Text TextTimer;

    private void Start()
    {
        gameTimer = 900;
        timer = 0;
        sec = 0;
        timeKeeper = gameTimer;
    }

    void Update ()
    {
        if (endgame && Time.time > EndTimer)
        {
            SceneManager.LoadScene("Newmenu");
        }

        if (hardSetTimer)
        {
            timer= 0;
            gameTimer = 300;
            timeKeeper = gameTimer;
            hardSetTimer = false;
            hardReset = true;   
        }


        if (timeKeeper > 0 && !hardReset)
        {
            timeKeeper = gameTimer - timer;
            timer += Time.deltaTime;

            mMin = Mathf.FloorToInt(15 - timer / 60);
            sec = Mathf.FloorToInt(60 - (timer % 60));
            if (mMin < 0) { timeString = "0:00"; }
            else {timeString = string.Format("{0:0}:{1:00}", mMin, sec); }
        }

        if (timeKeeper > 0 && hardReset)
        {
            timeKeeper = gameTimer - timer;
            timer += Time.deltaTime;

            mMin = Mathf.FloorToInt(5 - timer / 60);
            sec = Mathf.FloorToInt(60 - (timer % 60));
            if (mMin < 0) { timeString = "0:00"; }
            else { timeString = string.Format("{0:0}:{1:00}", mMin, sec); }
        }

        if (timeKeeper <= 0 && !fiftPuzzleDone && !endgame)
        {
            EndCanvas.SetActive(true);
            EndTimer = Time.time + 3;
            endgame = true;
        }
        TextTimer.text = timeString;

    }
}
