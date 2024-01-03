using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform followTarget;
    private Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        offset = transform.position - followTarget.position;
    }

    private void LateUpdate()
    {
        transform.position = followTarget.position + offset;
    }
}
