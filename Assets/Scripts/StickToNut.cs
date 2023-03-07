using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToNut : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isGrounded = false;
    private Transform currentNut;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collider2D other)
    {
        if (other.CompareTag("nut") && other.transform != currentNut)
        {
            currentNut = other.transform;
            isGrounded = true;
            transform.parent = currentNut;
        }
    }

    void OnCollisionExit2D(Collider2D other)
    {
        if (other.transform == currentNut)
        {
            isGrounded = false;
            transform.parent = null;
        }
    }

}
