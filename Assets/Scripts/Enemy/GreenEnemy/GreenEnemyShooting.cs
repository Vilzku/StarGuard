using UnityEngine;

public class GreenEnemyShooting : EnemyShooting
{
  [SerializeField] Transform firePoint1;
  [SerializeField] Transform firePoint2;

  [SerializeField] int burstAmount;
  [SerializeField] float bulletDelay;
  [SerializeField] float burstDelay;
  private int timesShot = 0;

  new void Start()
  {
    base.Start();
    WaitForBurst();
  }

  private void ShootBoth()
  {
    FireBullet(firePoint1);
    FireBullet(firePoint2);
    if (++timesShot % burstAmount == 0)
    {
      CancelInvoke(nameof(ShootBoth));
      WaitForBurst();
    }
  }

  private void WaitForBurst()
  {
    InvokeRepeating(nameof(ShootBoth), burstDelay, bulletDelay);
  }
}
