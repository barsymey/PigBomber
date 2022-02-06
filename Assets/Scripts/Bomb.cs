using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fuseLength;
    public float explosionRadius;
    private float detonationTime;
    [SerializeField]private GameObject explosionEffect;
    
    void Awake()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(fuseLength);
        Explode();
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation, transform.parent);
        Collider2D [] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach(Collider2D enemyColliderComponent in objectsInRadius)
        {
            try
            {
                enemyColliderComponent.GetComponent<Movement>().BlowUp(transform.position);
                Destroy(enemyColliderComponent);
            }catch{}
        }
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
