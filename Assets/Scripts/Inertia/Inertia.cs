using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inertia : MonoBehaviour
{
    [SerializeField] private float followSpeed;

    public void UpdatePosition(Transform followedCube, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastPosition(followedCube, isFollowStart));
    }

    private IEnumerator StartFollowingToLastPosition(Transform followedCube, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCube.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedCube.position.z, followSpeed * Time.deltaTime));
        }
    }
}
