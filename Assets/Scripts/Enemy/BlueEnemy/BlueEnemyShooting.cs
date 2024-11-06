using UnityEngine;

public class BlueEnemyShooting : EnemyShooting
{
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] Transform firePoint3;

    [SerializeField] float shotDelay;
    private bool doubleShot = false;
    private bool tripleShot = false;


    new void Start()
    {
        base.Start();
        WaitForShot();
    }

    private void Shoot()
    {
        if (tripleShot)
        {
            FireBullet(firePoint1, true);
            FireBullet(firePoint2, false);
            FireBullet(firePoint3, false);
            tripleShot = false;
        }
        else if (doubleShot)
        {
            FireBullet(firePoint2, true);
            FireBullet(firePoint3, false);
            tripleShot = true;
            doubleShot = false;
        }
        else
        {
            FireBullet(firePoint1, true);
            doubleShot = true;
        }
        WaitForShot();
    }

    private void WaitForShot()
    {
        Invoke(nameof(Shoot), Random.Range(0.95f, 1.05f) * shotDelay);
    }
}
