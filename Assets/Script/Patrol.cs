using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    bool right = true, left = false;
    public float length;
    public float start;
    private Vector3 localScale;

    private void Start()
    {
        localScale = transform.localScale;
    }
    void Update()
    {
        float pos = GetComponent<Transform>().position.x;
        float posLimit = start - length;
        float posLimit2 = start + length;
        if (pos <= posLimit)
        {
            right = true;
            left = false;
        }

        if (posLimit2 <= pos)
        {
            localScale.x *= -1;
            left = true;
            right = false;
        }

        if (right)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(posLimit2, transform.position.y), 0.1f);
        }


        if (left)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(posLimit, transform.position.y), 0.1f);
        }
   }

    private void LateUpdate()
    {
        if(((right) && (localScale.x < 0)) || ((!right && (localScale.x>0))))
            {
                localScale.x *= -1;
            }
        transform.localScale = localScale;
    }
}
