using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    public float TimeExtra;
    public float timeLeft;

    public TMP_Text textMesh;
    private bool isActive = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (isActive)
        {
            if (GameManager.instance.finishTutorial)
                timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                GameManager.instance.gameOver();
                isActive = false;
                timeLeft = 0;
            }

            int minutes = (int)timeLeft / 60;
            int seconds = (int)timeLeft % 60;
            textMesh.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        }
    }

    public void addTime()
    {
        if (GameManager.instance.finishTutorial)
            this.timeLeft += TimeExtra;
        else
        {
            GameManager.instance.tutorial.SetActive(false);
            GameManager.instance.finishTutorial = true;
        }
    }
}
