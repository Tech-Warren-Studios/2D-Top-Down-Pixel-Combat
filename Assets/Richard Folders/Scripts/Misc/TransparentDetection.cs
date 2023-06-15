using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentDetection : MonoBehaviour
{
    [Range(0, 1)] 
    [SerializeField] private float transparencyAmount = 0.8f;
    [SerializeField] private float fadeTime = 0.4f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {

        }
    }
}
