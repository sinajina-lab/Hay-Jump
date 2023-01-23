using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObject : MonoBehaviour
{
    public Rigidbody2D thrownObject;
    public Transform rotatingObject;
    public float launchForce = 10f;
    public bool isLaunched = false;

    private FixedJoint2D joint;

    void Start()
    {
        joint = thrownObject.gameObject.AddComponent<FixedJoint2D>();
        joint.connectedBody = rotatingObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            joint.enabled = false;
            thrownObject.AddForce(rotatingObject.up * launchForce, ForceMode2D.Impulse);
            isLaunched = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nut"))
        {
            joint.enabled = true;
            joint.connectedBody = collision.rigidbody;
            isLaunched = false;
        }
    }
}
