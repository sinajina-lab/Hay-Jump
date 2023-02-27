using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableScript : MonoBehaviour
{
    [SerializeField] Rigidbody throwableObj;
    [SerializeField] float speed = 30f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "target")
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody instantiatedThrowable = Instantiate(throwableObj, transform.position, transform.rotation);
            instantiatedThrowable.velocity = transform.forward * speed;
        }
    }
}
