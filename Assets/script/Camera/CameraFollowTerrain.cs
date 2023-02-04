using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTerrain : MonoBehaviour
{
    [SerializeField] private GameObject _focusObj;


    public void CameraMove(Vector3 pos)
    {
        StartCoroutine(StarCameraMove(pos));
    }

    IEnumerator StarCameraMove(Vector3 pos)
    {
        float t = 0;
        Vector2 starPos = _focusObj.transform.position;
        Vector2 endPos = pos;
        while (t < 1)
        {
            t += Time.deltaTime;
            _focusObj.transform.position = Vector2.Lerp(starPos,endPos,t);
            yield return new WaitForEndOfFrame();
        }
    }
 }
