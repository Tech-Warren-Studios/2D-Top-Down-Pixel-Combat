using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLaser : MonoBehaviour
{
    private float laserRange;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        LaserFaceMouse();
        StartCoroutine(IncreaseLaserLengthRoutine());
    }

    public void UpdateLaserRange(float laserRange)
    {
        this.laserRange = laserRange;
    }

    private IEnumerator IncreaseLaserLengthRoutine()
    {

    }

    private void LaserFaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = transform.position - mousePosition;
        transform.right = -direction;
    }
}
