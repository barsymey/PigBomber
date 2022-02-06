using UnityEngine;

public abstract class BasicEnemyBehaviour : MonoBehaviour
{
    protected Movement moveTarget;
    protected Movement actorMovement;

    void Awake()
    {
        moveTarget = GameObject.FindWithTag("Player").GetComponent<Movement>();
        actorMovement = GetComponent<Movement>();
    }

    public virtual void DecideNextMove()
    {
        Vector3Int distanceToTarget = moveTarget.GetCurrentPosition() - actorMovement.GetCurrentPosition();
        if(distanceToTarget.magnitude < 5) actorMovement.animation.SetActiveQuadSprite("Angry");
        else actorMovement.animation.SetActiveQuadSprite("Normal");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) other.GetComponent<Movement>().BlowUp(transform.position);
    }
  
}
