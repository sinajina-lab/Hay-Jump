using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfOnGround : MonoBehaviour
{
    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] float Time;
    [SerializeField] AnimationCurve animCurve;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SurfaceAlignment();
    }
    private void SurfaceAlignment()
    {
        Ray ray= new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();

        if(Physics.Raycast(ray, out info, WhatIsGround))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, info.normal), animCurve.Evaluate(Time));
        }
    }
}
