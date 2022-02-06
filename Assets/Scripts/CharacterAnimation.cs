using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private QuadSprite normal;
    [SerializeField] private QuadSprite angry;
    [SerializeField] private QuadSprite dirty;
    private QuadSprite activeQuadSprite;
    private Sprite activeSprite;
    string spriteDirection;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        activeQuadSprite = normal;
        spriteDirection = "Left";
        TurnSprite();
        animator.Play("MovementAnimation");
    }

    public void SetSpriteDirection(string direction)
    {
        spriteDirection = direction;
        TurnSprite();
    }

    private void TurnSprite()
    {
        switch(spriteDirection)
        {
            case "Up":
                activeSprite = activeQuadSprite.up;
                break;
            case "Down":
                activeSprite = activeQuadSprite.down;
                break;
            case "Left":
                activeSprite = activeQuadSprite.left;
                break;
            case "Right":
                activeSprite = activeQuadSprite.right;
                break;
        }
        RefreshActiveSprite();
    }

    public void SetActiveQuadSprite(string state)
    {
        switch(state)
        {
            case "Normal":
                activeQuadSprite = normal;
                break;
            case "Angry":
                activeQuadSprite = angry;
                break;
            case "Dirty":
                activeQuadSprite = dirty;
                break;
        }
        TurnSprite();
    }

    public void PlayMovementAnimation()
    {
        animator.speed = 1;
    }

    public void StopMovementAnimation()
    {
        animator.speed = 0;
    }

    private void RefreshActiveSprite()
    {
        spriteRenderer.sprite = activeSprite;
    }
}
