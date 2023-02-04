using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootKey : MonoBehaviour
{
    public int forceRoot;
    public KeyCode key;
    public bool isRoot = false;


    private SpriteRenderer sprite;
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        if (isRoot)
        {
            sprite.sprite = gameManager.instance.spriteRoot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (isRoot)
            {
                upRoot();

            }
            else
            {
                isVoid();
                Invoke("sprintDefault", 60);
            }
        }
    }

    void upRoot()
    {
        forceRoot--;
        Debug.Log(forceRoot);
        if (forceRoot == 0)
        {
            sprite.sprite = gameManager.instance.spriteUpRoot;
        }
    }

    void isVoid()
    {
        sprite.sprite = gameManager.instance.spriteError;
    }
    void sprintDefault()
    {
        if (isRoot)
        {
            sprite.sprite = gameManager.instance.spriteRoot;
        }
        else
        {
            sprite.sprite = gameManager.instance.spriteVoid;
        }
    }
}
