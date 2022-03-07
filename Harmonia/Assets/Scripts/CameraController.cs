using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 offset;
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
