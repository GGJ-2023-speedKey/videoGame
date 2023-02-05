using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> prefabs;
    public Sprite spriteRoot, spriteRoot2, spriteVoid, spriteError, spriteUpRoot;
    public GameObject gameObjectGenerateLvl;

    public GameObject finalMenu;
    public bool finishGame = false;

    public CameraFollowTerrain _cameraFollowTerrain;

    public GameObject currentTable;

    private GenerateLvl generateLvl;
    public int lvl = 1;
    private Vector3 positionLvl;
    private GameObject nextNextLvl;

    private Vector3 vectorDeltaLvl = new Vector3(0, 8, 0);





    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        this.generateLvl = gameObjectGenerateLvl.GetComponent<GenerateLvl>();
        this.positionLvl = transform.position;
        this.positionLvl += new Vector3(0, 9, 0);

    }


    private void deleteTableOld()
    {
        Destroy(prefabs[0]);
        prefabs.RemoveAt(0);
    }



    public void generateTableRoots()
    {
        this.positionLvl += vectorDeltaLvl;

        this.nextNextLvl = this.generateLvl.generateLvl(lvl, positionLvl + Vector3.forward);

        prefabs.Add(this.nextNextLvl);
        activeTablesCurrenet();

        _cameraFollowTerrain.CameraMove(currentTable.transform.position);

        this.lvl++;
        deleteTableOld();

    }

    public void activeTablesCurrenet()
    {
        this.currentTable = prefabs[3];
        currentTable.GetComponent<TableKey>().isActive = true;

    }

    internal void gameOver()
    {
        Debug.Log("GameOver");
        finalMenu.SetActive(true);
        finishGame = true;
    }
}
