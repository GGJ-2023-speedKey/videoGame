using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Sprite spriteRoot;
    public Sprite spriteRoot2;
    public Sprite spriteVoid;
    public Sprite spriteError;
    public Sprite spriteUpRoot;

    public bool isGameplay = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
