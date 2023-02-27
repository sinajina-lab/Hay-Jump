using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaserScript : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform laserPosition;

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

        if(hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 100);
        }

        //StartCoroutine(PowerLaser());
    }
    //IEnumerator TurnLaserOnAndOff()
    //{
    //    yield return new WaitForSeconds(.1f);
    //    GetComponent<LineRenderer>().enabled = true;
    //}
}
