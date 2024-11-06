using UnityEngine;

public class YellowEnemyShooting : EnemyShooting
{
    [SerializeField] Transform firePoint;

    [SerializeField] float shotDelay;


    new void Start()
    {
        base.Start();
        WaitForShot();
    }

    private void Shoot()
    {
        FireBullet(firePoint);
        WaitForShot();
    }

    private void WaitForShot()
    {
        Invoke(nameof(Shoot), Random.Range(0.95f, 1.05f) * shotDelay);
    }
}
