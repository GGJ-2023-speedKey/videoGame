using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTerrain : MonoBehaviour
{
    [SerializeField] private GameObject _focusObj;


    public void CameraMove(Vector2 pos)
    {
        _focusObj.transform.position = pos;
        StartCoroutine(StarCameraMove());
    }

    IEnumerator StarCameraMove()
    {
        float t = 0;
        Vector2 starPos = _focusObj.transform.position;
        Vector2 endPos = Vector2.zero;
        while (t >= 1)
        {
            t += Time.deltaTime;
            _focusObj.transform.position = Vector2.Lerp(starPos,endPos,t);
            yield return new WaitForEndOfFrame();
        }
    }
 }
