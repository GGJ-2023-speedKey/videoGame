using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public Transform _posDown;
    public Transform _posUp;
    public GameObject _cloudRight;
    public GameObject _cloudLeft;
    public bool _isRight;


    private void Start()
    {
        StartCoroutine(SpawnClouds());
    }



    IEnumerator SpawnClouds()
    {
        while (true)
        {
            float posY = Random.RandomRange(_posDown.position.y, _posUp.position.y);

            var _cloud = _isRight ? _cloudRight : _cloudLeft;

            var newCloud = Instantiate(_cloud, new Vector3(transform.position.x, posY, transform.position.z), Quaternion.identity);

            newCloud.GetComponent<CloudBehabiour>()._isRight = _isRight;

            yield return new WaitForSeconds(1);
        }

    }

}
