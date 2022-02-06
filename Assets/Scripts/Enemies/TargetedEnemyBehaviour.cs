using UnityEngine;

public class TargetedEnemyBehaviour : BasicEnemyBehaviour
{
    void FixedUpdate()
    {
        if(!actorMovement.IsBusyNow()) DecideNextMove();
    }

    public override void DecideNextMove()
    {
        base.DecideNextMove();
        Vector3Int targetDistance = moveTarget.GetCurrentPosition() - actorMovement.GetCurrentPosition();
        int direction = Random.Range(0,2);
        switch(direction)
        {
            case 0:
                if(targetDistance.x > 0) actorMovement.MoveHorizontaly(1);
                else if(targetDistance.x < 0) actorMovement.MoveHorizontaly(-1);
                break;
            case 1:
                if(targetDistance.y > 0) actorMovement.MoveVertically(1);
                else if(targetDistance.y < 0) actorMovement.MoveVertically(-1);
                break;
        }
    }
    
}
