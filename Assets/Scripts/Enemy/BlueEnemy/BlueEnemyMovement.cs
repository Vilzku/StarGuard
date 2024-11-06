using UnityEngine;

public class BlueEnemyMovement : EnemyMovement
{
    new void Update()
    {
        base.Update();
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (!player) return;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        ApplyMovement(CheckIsPlayerClose() ? Vector2.zero : direction);
    }
}
