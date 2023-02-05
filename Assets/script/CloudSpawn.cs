using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public Transform _posDown;
    public Transform _posUp;
    public GameObject _cloudRight;
    public bool _isRight;
    public bool _isMainMenu;


    private void OnEnable()
    {
        if (_isMainMenu)
            StartCoroutine(SpawnCloudsInMainMenu());
        else
            StartCoroutine(SpawnClouds());
    }


    IEnumerator SpawnCloudsInMainMenu()
    {
        while (true)
        {
            float posY = Random.RandomRange(_posDown.position.y, _posUp.position.y);

            var _cloud = _cloudRight;

            var newCloud = Instantiate(_cloud, new Vector3(transform.position.x, posY, transform.position.z), Quaternion.identity);

            newCloud.GetComponent<CloudBehabiour>()._isRight = _isRight;

            yield return new WaitForSeconds(5f);
        }

    }

    IEnumerator SpawnClouds()
    {
        bool finishMove = false;

        while (!finishMove)
        {
            float posY = Random.RandomRange(_posDown.position.y, _posUp.position.y);

            var _cloud = _cloudRight;

            var newCloud = Instantiate(_cloud, new Vector3(transform.position.x, posY, transform.position.z), Quaternion.identity);

            newCloud.GetComponent<CloudBehabiour>()._isRight = _isRight;

            yield return new WaitForSeconds(5f);

            if (GameManager.instance != null)
                finishMove = GameManager.instance.finishGame;

        }

    }

}
