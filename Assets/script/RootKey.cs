using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootKey : MonoBehaviour
{
    public int forceRoot;
    public KeyCode key;
    public bool isRoot = false;
    public bool isUpRoot = false;
    private bool isActive = true;
    private TableKey tableKey;



    private SpriteRenderer sprite;
    void Start()
    {
        tableKey = transform.parent.GetComponent<TableKey>();
        sprite = this.GetComponent<SpriteRenderer>();
        sprintDefault();
    }

    void Update()
    {
        if (tableKey.isActive)
        {
            if (!isActive)
                sprintDefault();

            if (Input.GetKeyDown(key))
            {
                if (isRoot)
                {
                    upRoot();
                }
                else
                {
                    if (isUpRoot) return;
                    keyError();
                }
            }
        }
        else if (!tableKey.isActive)
        {
            isActive = false;
            sprite.sprite = GameManager.instance.spriteError;
        }
    }

    void upRoot()
    {
        if (GameManager.instance.finishGame)
            return;

        if (forceRoot > 0)
        {
            forceRoot--;
        }
        sprite.sprite = GameManager.instance.spriteRoot2;

        if (forceRoot <= 0)
        {
            sprite.sprite = GameManager.instance.spriteUpRoot;
            transform.parent.GetComponent<TableKey>().nRoots--;
            GameManager.instance.numRoot++;
            this.isUpRoot = true;
            this.isRoot = false;
        }
        if (isUpRoot) return;
        Invoke("sprintDefault", 0.1f);
    }

    void keyError()
    {
        sprite.sprite = GameManager.instance.spriteError;
        Invoke("sprintDefault", 0.1f);
    }
    void sprintDefault()
    {
        isActive = true;
        if (isRoot) { sprite.sprite = GameManager.instance.spriteRoot; return; }
        if (isUpRoot) { sprite.sprite = GameManager.instance.spriteRoot; return; }

        sprite.sprite = GameManager.instance.spriteVoid;

    }



}
