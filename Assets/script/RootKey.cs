using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootKey : MonoBehaviour
{
    public int forceRoot;
    public KeyCode key;
    public bool isRoot = false;
    public bool isUpRoot = false;

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
        if (Input.GetKeyDown(key) && tableKey.isActive)
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

    void upRoot()
    {
        if (forceRoot > 0)
        {
            forceRoot--;
        }
        sprite.sprite = GameManager.instance.spriteRoot2;

        if (forceRoot == 0)
        {
            sprite.sprite = GameManager.instance.spriteUpRoot;
            transform.parent.GetComponent<TableKey>().nRoots--;
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

        if (isRoot) { sprite.sprite = GameManager.instance.spriteRoot; return; }
        if (isUpRoot) { sprite.sprite = GameManager.instance.spriteRoot; return; }

        sprite.sprite = GameManager.instance.spriteVoid;

    }



}
