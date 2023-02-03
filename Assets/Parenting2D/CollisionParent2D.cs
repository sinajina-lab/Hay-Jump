using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//Set parent to null and change kinematic to false when launching the player to next target(it will be the opposite)
public class CollisionParent2D : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] bool isParent = false;

    [SerializeField] float launchForce = 100f;
    private Rigidbody2D rb;
    
    public Vector2 touchPoint;
    public Transform feet;
    public Collider2D feetCollider;//ToDo:moving logic to feet collider
    public LayerMask circleMask;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with the desired parent object
        if (other.gameObject.tag == "target")
        {
            transform.SetParent(other.gameObject.transform);
            
            rb.isKinematic = true;
            //touchPoint = feet.position;
            Vector2 touchPoint = (transform.position);
            rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collision is with the desired parent object
        if (other.gameObject.tag == "target")
        {
            //get the normal angle
           Vector2 normalAngle = other.contacts[0].normal;
            Debug.Log(normalAngle);

            //set the player parent to be the gameobject we collided with
            transform.SetParent(other.gameObject.transform);

            //set the local rotation z to the normal angle
            Quaternion localAngles = Quaternion.Euler(0, 0, normalAngle.y);
            transform.localRotation = localAngles;

            rb.isKinematic = true;
            //touchPoint = feet.position;
            Vector2 touchPoint = (transform.position);
            rb.velocity = Vector2.zero;
        }
    }
    void LaunchToNextTarget()
    {
        rb.isKinematic = false;

        transform.SetParent(null);
        
        Vector2 launchDirection = (touchPoint - (Vector2)transform.position).normalized;
        
        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LaunchToNextTarget();
        }
        if (Physics2D.OverlapPoint(touchPoint, circleMask))
        {
            transform.position = touchPoint;
        }

        /*  if (Physics2D.OverlapPoint(feet.position, circleMask))
          {
              transform.position = feet.position;
          };*/
    }
}
