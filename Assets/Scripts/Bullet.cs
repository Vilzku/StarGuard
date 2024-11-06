using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    void Start()
    {
        StartCoroutine(nameof(AutoDestroy));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("EnemyBullet") && !other.CompareTag("Player")) return;
        if (gameObject.CompareTag("PlayerBullet") && !other.CompareTag("Enemy")) return;
        Health health = other.gameObject.GetComponent<Health>();
        health.TakeDamage(damage);
        Destroy(gameObject);
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
