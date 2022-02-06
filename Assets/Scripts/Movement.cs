using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector3Int currentPosition;
    private Vector3Int cellDestination;
    private Vector3 transformDestination;
    [SerializeField] private float baseMovementSpeed;
    private bool isMovingNow;
    private float flySpeed = 5;
    private float flyRotationSpeed = 1000;
    public CharacterAnimation animation;
    void Start()
    {
        animation = GetComponentInChildren<CharacterAnimation>();
        isMovingNow = false;
        transform.position = GridCellToWorld(currentPosition);
        animation.StopMovementAnimation();
    }

    public void MoveHorizontaly(float direction)
    {
        if(!isMovingNow)
        {
            cellDestination = new Vector3Int(currentPosition.x + (int)direction, currentPosition.y, currentPosition.z);
            if(!CheckCellBlocked(cellDestination))
            {
                if(direction == 1) animation.SetSpriteDirection("Right");
                else if(direction == -1) animation.SetSpriteDirection("Left");
                StartCoroutine(RelocateObject(cellDestination));
                currentPosition = cellDestination;
            }
        }
    }

    public void MoveVertically(float direction)
    {
        if(!isMovingNow)
        {
            cellDestination = new Vector3Int(currentPosition.x, currentPosition.y + (int)direction, currentPosition.z);
            if(!CheckCellBlocked(cellDestination))
            {
                if(direction == 1) animation.SetSpriteDirection("Up");
                else if(direction == -1) animation.SetSpriteDirection("Down");
                StartCoroutine(RelocateObject(cellDestination));
                currentPosition = cellDestination;
            }
        }
    }

    IEnumerator RelocateObject(Vector3Int destination)
    {
        Vector3 dest = GridCellToWorld(destination);
        animation.PlayMovementAnimation();
        isMovingNow = true;
        while(Vector3.Distance(transform.position, dest) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, baseMovementSpeed * Time.deltaTime);
            yield return null;
        }
        animation.StopMovementAnimation();
        transform.position = dest;
        isMovingNow = false;
    }

    private bool CheckCellBlocked(Vector3Int cellToCheck)
    {
        return Physics2D.OverlapPoint(GridCellToWorld(cellToCheck), 8);
    }

    public void BlowUp(Vector3 explosionPoint)
    {
        StartCoroutine(FlyAway(explosionPoint));
        animation.SetActiveQuadSprite("Dirty");
        Destroy(animation);
    }

    IEnumerator FlyAway(Vector3 flyFrom)
    {
        float disappearTime = Time.timeSinceLevelLoad + 1;
        while(disappearTime > Time.timeSinceLevelLoad)
        {
        Vector3 direction = transform.position - flyFrom;
        transform.position += direction * flySpeed * Time.deltaTime;
        transform.Rotate(0, 0, flyRotationSpeed * Time.deltaTime);
        yield return null;
        }
        if(gameObject.CompareTag("Player")) LevelManager.ShowGameOverScreen("Game Over");
        else if(gameObject.CompareTag("Enemy")) LevelManager.NotifyEnemyDestroyed();
        Destroy(gameObject);
    }

    private Vector3 GridCellToWorld(Vector3Int gridCoords)
    {
        return NavigationGrid.MainGrid.GetCellCenterWorld(gridCoords);
    }


    public Vector3Int GetCurrentPosition()
    {
        return currentPosition;
    }

    public bool IsBusyNow()
    {
        return isMovingNow;
    }
}
