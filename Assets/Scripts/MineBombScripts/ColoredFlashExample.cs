using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFlashExample : MonoBehaviour
{
    [SerializeField] private ColoredFlash flashEffect;
    [SerializeField] private Color[] colors;
    [SerializeField] private KeyCode flashKey;

    private void Update()
    {
        if (Input.GetKeyDown(flashKey))
        {
            Color randomColor = colors[Random.Range(0, colors.Length)];
            flashEffect.Flash(randomColor);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == ("Player"))
        //{
        //    Color randomColor = colors[Random.Range(0, colors.Length)];
        //    flashEffect.Flash(randomColor);
        //}
    }
}
