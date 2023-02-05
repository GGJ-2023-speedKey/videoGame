using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableKey : MonoBehaviour
{
    public bool isActive = false;
    public int nRoots;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nRoots <= 0 && isActive)
        {
            Debug.Log(gameObject.name);
            GameManager.instance.generateTableRoots();
            isActive = false;
        }
    }
}
