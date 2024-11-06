using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] public AudioClip gunSound;


    private GameObject bulletContainer;
    private readonly float shootingRangeX = 40f;
    private readonly float shootingRangeY = 22f;
    private GameObject player;
    private AudioSource audioSource;


    public void Start()
    {
        bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer");
        player = GameObject.FindWithTag("Player");
        audioSource = GetComponent<AudioSource>();

    }

    protected void FireBullet(Transform firePoint, bool playAudio = true)
    {
        if (CheckIsPlayerClose())
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.SetParent(bulletContainer.transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            if (playAudio) audioSource.PlayOneShot(gunSound);
        }
    }

    private bool CheckIsPlayerClose()
    {
        if (!player) return false;
        float distanceToPlayerX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distanceToPlayerY = Mathf.Abs(transform.position.y - player.transform.position.y);
        return distanceToPlayerX <= shootingRangeX && distanceToPlayerY <= shootingRangeY;
    }
}
