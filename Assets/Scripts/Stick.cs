using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Stick : MonoBehaviour
{

    public string StuckObjectTag = "target";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(StuckObjectTag))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

}
