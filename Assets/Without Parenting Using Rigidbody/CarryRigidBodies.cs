using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CarryRigidBodies : MonoBehaviour
{
    [SerializeField] bool useTriggerAsSensor = false;
    [SerializeField] List<Rigidbody> rigidbodies = new List<Rigidbody>();

    Vector3 lastEulerAngles;
    Vector3 lastPosition;
    Transform _transform;
    [HideInInspector] public Rigidbody _rigidbody;
    List<CarryRigidBodiesSensor> sensors = new List<CarryRigidBodiesSensor>();

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        lastPosition = _transform.position;
        lastEulerAngles = _transform.eulerAngles;
        _rigidbody = GetComponent<Rigidbody>();

        if(useTriggerAsSensor)
        {
            foreach (CarryRigidBodiesSensor sensor in GetComponentsInChildren<CarryRigidBodiesSensor>())
            {
                sensor.carrier = this;
                sensors.Add(sensor);
            }

            //if we are supposed to use sensors but have non set up, its probably an oversight on our part
            if(sensors.Count == 0)
            {
                Debug.LogWarning("Rigidbody carrier" +name+ "is set to use sensors but no sensors were detected!");
            }
        }
    }

    private void LateUpdate()
    {
        if(rigidbodies.Count > 0)
        {
            Vector3 velocity = (_transform.position - lastPosition);
            Vector3 angularVelocity = _transform.eulerAngles - lastEulerAngles;
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                Rigidbody rb = rigidbodies[i];

                rb.transform.Translate(velocity, Space.World); //_transform
                RotateRigidBody(rb, angularVelocity.x);
            }
        }
        lastPosition = _transform.position;
        lastEulerAngles = _transform.eulerAngles;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (useTriggerAsSensor) return;

        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if(rb !=null)
        {
            Add(rb);
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (useTriggerAsSensor) return;

        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Remove(rb);
        }
    }

    public void Add(Rigidbody rb)
    {
        if (!rigidbodies.Contains(rb))
            rigidbodies.Add(rb);
    }

    public void Remove(Rigidbody rb)
    {
        if (rigidbodies.Contains(rb))
            rigidbodies.Remove(rb);
    }

    void RotateRigidBody(Rigidbody rb, float amount)
    {
        rb.transform.RotateAround(_transform.position, Vector3.up, amount);
    }

    public bool TryRemoveBasedOnSensors(Rigidbody rb)
    {
        for(int i = 0; i < sensors.Count; i++)
        {
            CarryRigidBodiesSensor sensor = sensors[i];
            if (sensor.rigidbodies.Contains(rb))
                return false;
        }

        //otherwise by this point, we know that no sensors are currently detecting this rigidbody
        Remove(rb);
        return true;
    }
}
