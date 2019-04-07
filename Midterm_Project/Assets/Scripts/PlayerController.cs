using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode jumpKey;

    private Rigidbody2D rb;

    public float speedMultiplier = 10f;
    public float jumpVelocity = 10f;
    public float fallMultiplier = 10f;
    
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        Jump();
        Fall();
    }

    void MoveHorizontal()
    {
        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speedMultiplier);
        }

        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speedMultiplier);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("isGround"))
        {
            isGrounded = true;
        }
    }

    private void Fall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}
