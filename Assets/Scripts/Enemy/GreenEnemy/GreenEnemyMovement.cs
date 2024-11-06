using System.Collections;
using UnityEngine;

public class GreenEnemyMovement : EnemyMovement
{
    private int sidewaysMovement = 0;

    new void Update()
    {
        base.Update();
        MoveTowardsOrSideways();
    }

    private void MoveTowardsOrSideways()
    {
        if (!player) return;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        if (CheckIsPlayerClose())
        {
            if (sidewaysMovement == 0) StartCoroutine(RandomizeDirection());
            MoveSideways(direction);
        }
        else ApplyMovement(direction);
    }

    private void MoveSideways(Vector2 direction)
    {
        Vector2 sideways = new(direction.y * sidewaysMovement, direction.x * -sidewaysMovement);
        ApplyMovement(sideways, 1.2f);
    }

    IEnumerator RandomizeDirection()
    {
        sidewaysMovement = Random.value > 0.5f ? 1 : -1;
        yield return new WaitForSeconds(3.5f);
        sidewaysMovement = 0;
    }
}