using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip gunSound;

    [SerializeField] float bulletForce = 20f;

    [SerializeField] float bulletDelay;
    private GameObject bulletContainer;
    private bool shootSecondary = false;
    private bool allowShooting = false;
    private AudioSource audioSource;


    void Start()
    {
        bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartShooting();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke(nameof(Shoot));
        }
    }

    private void Shoot()
    {
        if (allowShooting)
        {
            Transform nextFirePoint = shootSecondary ? firePoint2 : firePoint1;
            GameObject bullet = Instantiate(bulletPrefab, nextFirePoint.position, nextFirePoint.rotation);
            bullet.transform.SetParent(bulletContainer.transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(nextFirePoint.up * bulletForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(gunSound);
            shootSecondary = !shootSecondary;
        }
    }

    private void StartShooting()
    {
        InvokeRepeating(nameof(Shoot), 0, bulletDelay);
    }

    public void SetAllowShooting(bool isAllowed)
    {
        allowShooting = isAllowed;
    }
}
