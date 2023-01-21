using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRigidBodiesSensor : MonoBehaviour
{
    [HideInInspector] public CarryRigidBodies carrier;
    [HideInInspector] public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private void OnTriggerEnter(Collider ob)
    {
        Rigidbody rb = ob.GetComponent<Rigidbody>();
        if (rb != null && rb != carrier._rigidbody)
        {
            if (!rigidbodies.Contains(rb))
                rigidbodies.Add(rb);

            carrier.Add(rb);
        }
    }

    private void OnTriggerExit(Collider ob)
    {
        Rigidbody rb = ob.GetComponent<Rigidbody>();
        if (rb != null && rb != carrier._rigidbody)
        {
            if (rigidbodies.Contains(rb))
                rigidbodies.Remove(rb);

            carrier.TryRemoveBasedOnSensors(rb);
        }
    }
}
