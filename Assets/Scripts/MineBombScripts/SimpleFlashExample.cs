using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlashExample : MonoBehaviour
{
    [SerializeField] private SimpleFlash flashEffect;
    //[SerializeField] private KeyCode flashKey;

    private void Update()
    {
        //if (Input.GetKeyDown(flashKey))
        //{
        //    flashEffect.Flash();
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            flashEffect.Flash();
        }
    }
}
