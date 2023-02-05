using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehabiour : MonoBehaviour
{
    public float velocity = 0.1f;
    public bool _isRight = true;

    public List<Sprite> sprites = new List<Sprite>();


    private void OnEnable()
    {
        int index = Random.Range(0,sprites.Count);
        int layer = Random.Range(-3,2);

        GetComponent<SpriteRenderer>().sprite = sprites[index];

        GetComponent<SpriteRenderer>().sortingOrder = layer; 



        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForEndOfFrame();

        velocity = _isRight ? velocity * -1 : velocity;

        while (true)
        {
            yield return new WaitForFixedUpdate();


            transform.Translate(Vector3.right * velocity);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn" && collision.gameObject.GetComponent<CloudSpawn>()._isRight != _isRight)
            Destroy(gameObject);
    }
}
