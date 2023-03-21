using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] thePlatform;
    [SerializeField] Transform generationPoint;
    [SerializeField] float distanceBetween;//Makes sure nuts don't overlap each other

    float platformWidth;

    public ObjectPooling[] theObjectPools;

    //public GameObject[] thePlatforms;
    int platformSelector;
    float[] platformWidths;

    private void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        //platformWidth = thePlatform.GetComponent<CircleCollider2D>().radius;

        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponentInChildren<CircleCollider2D>().radius;
            //platformWidths[i] = thePlatforms.GetComponent<CircleCollider2D>().radius;
        }
    }
    private void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            platformSelector = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2)
                + distanceBetween, transform.position.y, transform.position.z);

           // Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, Quaternion.identity);
           
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2),
                transform.position.y, transform.position.z);
        }
    }
}
