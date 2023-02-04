using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootKey : MonoBehaviour
{
    public int forceRoot;
    public KeyCode key;
    public bool isRoot = false;
    public bool isUpRoot = false;


    private SpriteRenderer sprite;
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprintDefault();
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
                if (isUpRoot) return;
                keyError();
            }
        }
    }

    void upRoot()
    {
        forceRoot--;
        sprite.sprite = GameManager.instance.spriteRoot2;

        Debug.Log(forceRoot);
        if (forceRoot == 0)
        {
            sprite.sprite = GameManager.instance.spriteUpRoot;
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
