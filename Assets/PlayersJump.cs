using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersJump : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpDelay = 0.2f;
    [SerializeField] float jumpGracePeriod = 0.1f;
    [SerializeField] float maxJumpDistance = 2f;

    private bool canJump = true;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Transform currentNut;
    private RigidbodyType2D originalRigidbodyType;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalRigidbodyType = rb.bodyType;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump && isGrounded)
        {
            JumpToNut();
        }
    }

    void JumpToNut()
    {
        isGrounded = false;
        canJump = false;
        rb.velocity = Vector2.zero;
        Vector2 direction = (currentNut.position - transform.position).normalized;
        float distance = Vector2.Distance(currentNut.position, transform.position);
        float jumpDistance = Mathf.Min(distance, maxJumpDistance);
        rb.AddForce(direction * jumpDistance * jumpForce, ForceMode2D.Impulse);
        Invoke("EnableJump", jumpDelay);
    }

    void EnableJump()
    {
        canJump = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nut") && collision.transform != currentNut)
        {
            currentNut = collision.transform;
            isGrounded = true;
            transform.SetParent(currentNut);
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nut"))
        {
            float distance = Vector2.Distance(collision.transform.position, transform.position);
            if (distance < maxJumpDistance + jumpGracePeriod)
            {
                currentNut = collision.transform;
                isGrounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == currentNut)
        {
            isGrounded = false;
            transform.SetParent(null);
            rb.bodyType = originalRigidbodyType;
        }
    }
}
