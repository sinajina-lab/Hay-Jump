using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParent2D : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject referencePoint;
    [SerializeField] bool isParent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with the desired parent object
        if (other.gameObject == parentObject)
        {
            if (!isParent)
            {
                // Make the reference point a child of the parent object
                referencePoint.transform.parent = parentObject.transform;
                isParent = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collision is with the current parent object
        if (other.gameObject == parentObject)
        {
            // Remove the parent
            referencePoint.transform.parent = null;
            isParent = false;
        }
    }
}
