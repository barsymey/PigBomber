using UnityEngine;

public class ChaoticEnemyBehaviour : BasicEnemyBehaviour
{
    void FixedUpdate()
    {
        if(!actorMovement.IsBusyNow()) DecideNextMove();
    }

    public override void DecideNextMove()
    {
        base.DecideNextMove();
        int direction = Random.Range(0,4);
        switch(direction)
        {
            case 0:
                actorMovement.MoveHorizontaly(1);
                break;
            case 1:
                actorMovement.MoveHorizontaly(-1);
                break;
            case 2:
                actorMovement.MoveVertically(1);
                break;
            case 3:
                actorMovement.MoveVertically(-1);
                break;
        }
    }
    
}
