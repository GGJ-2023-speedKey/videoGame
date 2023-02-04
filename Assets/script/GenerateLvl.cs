using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLvl : MonoBehaviour
{
    public GameObject gameObject;

    public int minForceRoot = 1, MaxForceRoot = 10;

    public int NRoots;


    private GameObject current;
    private RootKey rootKey = null;

    private Transform[] keys = null;
    private Vector3 positionLvl;




    public GameObject generateLvl(int lvl, Vector3 positionLvl)
    {
        current = (GameObject)Instantiate(gameObject, positionLvl, Quaternion.identity); ;
        Transform[] rows = current.GetComponentsInChildren<Transform>();
        int nRoots = getNRootsForLvl(GameManager.instance.lvl);
        current.GetComponent<TableKey>().nRoots = nRoots;
        List<int> listPosRoots = getKeysRoots(nRoots, rows.Length);

        foreach (int i in listPosRoots)
        {
            updateRootKey(rows[i], GameManager.instance.lvl);

        }


        return current;
    }

    private void blankKey(Transform gameObject)
    {
        rootKey = gameObject.GetComponent<RootKey>();
        rootKey.isRoot = false;
    }

    void updateRootKey(Transform gameObject, int lvl)
    {
        int force = Random.Range(minForceRoot, MaxForceRoot);
        rootKey = gameObject.GetComponent<RootKey>();
        rootKey.isRoot = true;
        rootKey.forceRoot = force;
    }

    int getNRootsForLvl(int lvl)
    {
        return NRoots * lvl;
    }

    List<int> getKeysRoots(int nRoots, int nKeys)
    {
        List<int> result = new List<int>();
        int random = 0;
        while (result.Count < nRoots)
        {
            random = Random.Range(0, nKeys);
            if (!result.Contains(random))
            {
                result.Add(random);
            }

        }
        return result;

    }


}
