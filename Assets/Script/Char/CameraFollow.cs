using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    float t;
    private void Start()
    {
        target_Offset = transform.position - target.position;
        t = target.position.x;
    }
    void Update()
    {
        if (Char.dirX > 0 && target.position.x > t)
        {
            transform.position = new Vector3(target.position.x + target_Offset.x, target.position.y + target_Offset.y, transform.position.z);
            t = target.position.x;
        }

        transform.position = new Vector3(transform.position.x, target.position.y + target_Offset.y, transform.position.z);
    }
}
