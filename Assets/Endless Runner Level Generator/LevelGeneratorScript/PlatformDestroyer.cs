using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    [SerializeField] GameObject platformDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find("Nut");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
