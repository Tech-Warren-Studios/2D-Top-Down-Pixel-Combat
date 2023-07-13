using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    private void Update()
    {
        MoveProjectile();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();   
        Indestructible indestructible = other.GetComponent<Indestructible>();

        if(!other.isTrigger && (enemyHealth || indestructible))
        {
        enemyHealth?.TakeDamage(1);
        Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
        Destroy(gameObject);
        }

    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
