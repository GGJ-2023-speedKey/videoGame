using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;
    public Sprite spriteRoot;
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
