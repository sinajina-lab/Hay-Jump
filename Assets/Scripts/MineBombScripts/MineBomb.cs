using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MineBomb : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] float countdown = 10f;
    [SerializeField] float blastRadius = 5f;
    [SerializeField] float explosionForce = 700f;

    [SerializeField] LayerMask explodableLayerMask;

    [SerializeField] GameObject explosionEffect;

    [SerializeField] Transform spawnPoint;
    [SerializeField] int damageAmount = 10;

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
            //Explode();
            hasExploded = true;
        }
    }

   /* void Explode()
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
    } */
    void Damage(GameObject hitObject)
    {
        // Check if the hit object has a PlayerHealth script attached
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Apply damage to the player
            playerHealth.TakeDamage(damageAmount);

            // Respawn the player at the spawn point
            playerHealth.Respawn(spawnPoint.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
}
