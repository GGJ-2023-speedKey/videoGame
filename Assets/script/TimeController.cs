using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    public float TimeExtra;
    public float timeLeft;

    private TextMeshPro textMesh;
    private bool isActive = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();

    }

    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
            int minutes = (int)timeLeft / 60;
            int seconds = (int)timeLeft % 60;
            textMesh.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            if (timeLeft < 0)
            {
                GameManager.instance.gameOver();
                isActive = false;
            }
        }
    }

    public void addTime()
    {
        this.timeLeft += TimeExtra;
    }
}
