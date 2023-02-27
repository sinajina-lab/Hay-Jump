using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log(Input.mousePosition);
        }
    }

    void MyInputs()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }
}
