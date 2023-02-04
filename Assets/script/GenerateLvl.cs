using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLvl : MonoBehaviour
{
    public GameObject gameObject;

    public int randomRoots = 10, randomForceRoots = 10;




    private GameObject current;
    private int nLvl;
    private RootKey rootKey = null;

    private Transform[] keys = null;
    private Vector3 positionLvl;




    public GameObject generateLvl(int lvl, Vector3 positionLvl)
    {
        current = (GameObject)Instantiate(gameObject, positionLvl, Quaternion.identity); ;
        Transform[] rows = null;
        rows = current.GetComponentsInChildren<Transform>();
        foreach (Transform key in rows)
        {

            Debug.Log("key " + key.ToString());
            try
            {
                int random = Random.Range(0, 100);

                if (random % 2 == 0)
                {
                    updateRootKey(key.gameObject, lvl);
                }
                else
                {
                    blankKey(key.gameObject);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }

        }


        return current;
    }

    private void blankKey(GameObject gameObject)
    {
        rootKey = gameObject.GetComponent<RootKey>();
        rootKey.isRoot = false;
    }

    void updateRootKey(GameObject gameObject, int lvl)
    {
        Debug.Log("updateRootKey");
        int force = Random.Range(0, 2 * lvl);
        rootKey = gameObject.GetComponent<RootKey>();
        rootKey.isRoot = true;
        rootKey.forceRoot = force;
    }


}
