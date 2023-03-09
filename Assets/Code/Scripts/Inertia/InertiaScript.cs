using System.Collections;
using UnityEngine;

namespace Inertia
{
    public class InertiaScript : MonoBehaviour
    {
        [SerializeField] private float followSpeed;

        public void UpdatePosition(Transform followedObject, bool isFollowStart)
        {
            StartCoroutine(StartFollowingToLastPosition(followedObject, isFollowStart));
        }

        private IEnumerator StartFollowingToLastPosition(Transform followedObject, bool isFollowStart)
        {
            while (isFollowStart)
            {
                yield return new WaitForEndOfFrame();
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedObject.position.x, followSpeed * Time.deltaTime),
                    transform.position.y,
                    Mathf.Lerp(transform.position.z, followedObject.position.z, followSpeed * Time.deltaTime));
            }
        }
    }
}