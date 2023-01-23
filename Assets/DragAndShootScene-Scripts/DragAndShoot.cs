using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(Force: mousePressDownPos - mouseReleasePos);
    }

    [SerializeField] float forceMultiplier = 3;
    void Shoot(Vector3 Force)
    {
        if(isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, z: Force.y)*forceMultiplier);
        isShoot = true;
        SpawnBall.Instance.NewSpawnRequest();
    }
}
