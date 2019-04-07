using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollision : MonoBehaviour
{
    public GameObject platform;
    public Collider2D platformCollider;
    public Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindWithTag("isPlatform");
        platformCollider = platform.GetComponentInChildren<Collider2D>();
        playerCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("isPlatform"))
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("isPlatform"))
        {
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }
    }
}
