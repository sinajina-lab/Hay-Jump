using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParent : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] bool isParent;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the desired parent object
        if (other.gameObject == parentObject)
        {
            if (!isParent)
            {
                // Make this object a child of the parent object
                transform.parent = parentObject.transform;
                //transform.SetParent(parentObject.transform);
                rb.isKinematic = true;
                isParent = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collision is with the current parent object
        if (other.gameObject == parentObject)
        {
            // Remove the parent
            transform.SetParent(null);
            rb.isKinematic = false;
            isParent = false;
        }
    }
}
