using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehabiour : MonoBehaviour
{
    public float velocity = 1;
    public bool _isRight = true;


    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            velocity = !_isRight ? velocity * -1: velocity;

            transform.Translate(Vector3.right * velocity);

        }

    }

}
