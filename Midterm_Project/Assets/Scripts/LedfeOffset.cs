using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedfeOffset : MonoBehaviour
{
    private GameObject target = null;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            offset = target.transform.position - transform.position;
        }
        else
        {
            target = null;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        target = null;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
}
