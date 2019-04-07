using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class LedgeMovement : MonoBehaviour
{    
    public float rightLimit = 2.5f;
    public float leftLimit = -2.5f;
    public float speed = 1f;

    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= rightLimit)
        {
            direction = -1;
        }

        if (transform.position.x <= leftLimit)
        {
            direction = 1; 
        }

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
}
