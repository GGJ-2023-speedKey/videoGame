using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TableKey : MonoBehaviour
{
    public bool isActive = false;
    public bool TableClean = false;
    public int nRoots;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((nRoots <= 0 && isActive))
        {
            FinishTable();

        }
    }

    private void FinishTable()
    {
        Debug.Log(gameObject.name);
        GameManager.instance.generateTableRoots();
        isActive = false;
        TableClean = true;
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        bool tableCompleted = false;

        if (isActive)
        {
            int i = 0;
            List<RootKey> rootKey = GetComponentsInChildren<RootKey>().ToList();
            foreach (RootKey key in rootKey)
            {
                if (key.gameObject.GetComponent<SpriteRenderer>().sprite == GameManager.instance.spriteRoot ||
                    key.gameObject.GetComponent<SpriteRenderer>().sprite == GameManager.instance.spriteRoot2)
                    i++;
            }

            if (i == 0)
                tableCompleted = true;

        }

        if (tableCompleted)
        {
            FinishTable();
        }
        else
            StartCoroutine(delay());
    }
}
