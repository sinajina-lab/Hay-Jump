using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchToTarget : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] bool isParent = false;
    private Rigidbody2D rb;
    public Vector2 touchPoint;
    public Transform feet;
    public LayerMask circleMask;
    //[SerializeField] float force = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collision is with the desired parent object
        if (Input.GetMouseButtonDown(0))
        {
            transform.parent = null;
            rb.isKinematic = false;
        }
    }
}
