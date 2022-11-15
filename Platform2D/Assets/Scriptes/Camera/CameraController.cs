using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform PlayerTransform;
    [SerializeField] float minX, maxX;

    private void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(PlayerTransform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }
}
