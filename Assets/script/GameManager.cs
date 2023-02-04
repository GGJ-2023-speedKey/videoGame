using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> prefabs;
    public Sprite spriteRoot, spriteRoot2, spriteVoid, spriteError, spriteUpRoot;
    public GameObject gameObjectGenerateLvl;

    public float speedCamera = 100f;
    public bool isGameplay = false;
    public Camera camera;


    private GenerateLvl generateLvl;
    public int lvl = 1;
    private Vector3 positionLvl;
    private GameObject nextNextLvl;

    private Vector3 vectorDeltaLvl = new Vector3(0, 7, 0);





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
        this.positionLvl += new Vector3(0, 7, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.positionLvl += vectorDeltaLvl;
            camera.transform.position = Vector3.Lerp(camera.transform.position, camera.transform.position + vectorDeltaLvl, speedCamera);

            this.nextNextLvl = this.generateLvl.generateLvl(lvl, positionLvl + Vector3.forward);

            prefabs.Add(this.nextNextLvl);
            deleteTableOld();
            /*
            this.nextNextLvl.GetComponent<TableKey>().isActive = false;
            prefabs[1].GetComponent<TableKey>().isActive = true;
 
            prefabs[0].GetComponent<TableKey>().isActive = false;
            //Invoke("deleteTableOld", 1f);
            */
        }
    }


    private void deleteTableOld()
    {
        Destroy(prefabs[0]);
        prefabs.RemoveAt(0);
    }



    public void generateTableRoots()
    {

    }



}
