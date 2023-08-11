using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float PickUpDistance = 5f;
    [SerializeField] private float accelerationRate = .2f;
    [SerializeField] private float moveSpeed = 3f;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < PickUpDistance)
        {
            moveDir = (playerPos - transform.position).normalized;
            moveSpeed += accelerationRate;
        }
        else
        {
            moveDir = Vector3.zero;
            moveSpeed = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
            Debug.Log("pickuped coin");
        }
    }
}
