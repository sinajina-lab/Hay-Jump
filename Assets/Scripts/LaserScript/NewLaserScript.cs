using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaserScript : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform laserPosition;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int damageAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        //lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        lineRenderer.SetPosition(0, laserPosition.position);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);

            // Check if the hit object has a PlayerHealth script attached
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Apply damage to the player
                playerHealth.TakeDamage(damageAmount);

                // Respawn the player at the spawn point
                playerHealth.Respawn(spawnPoint.position);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 100);
        }

        //StartCoroutine(PowerLaser());
    }

    // Apply damage to the hit object
    void Damage(GameObject hitObject)
    {
        // Check if the hit object has a Health script attached
        PlayerHealth health = hitObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            // Apply damage to the object
            health.TakeDamage(damageAmount);
        }
    }
}
