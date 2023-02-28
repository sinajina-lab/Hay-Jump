using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBomb : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] float countdown = 10f;
    [SerializeField] float blastRadius = 5f;
    [SerializeField] float explosionForce = 700f;

    [SerializeField] LayerMask explodableLayerMask;

    [SerializeField] GameObject explosionEffect;

    bool hasExploded = false;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded) // hasExploded = false
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Detach children
        transform.DetachChildren();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D nearbyObject in colliders)
        {
            if (explodableLayerMask == (explodableLayerMask | (1 << nearbyObject.gameObject.layer)))
            {
                Destroy(nearbyObject.gameObject);
            }

            // Add force
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(rb.velocity * explosionForce, ForceMode2D.Impulse);
            }
        }

        Destroy(gameObject);
    }

}
