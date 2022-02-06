using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Movement movement;
    [SerializeField] private GameObject bomb;
    private float reloadTime = 3;
    private bool reloading = false;

    void Awake()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        ControlPlayer();
    }

    private void ControlPlayer()
    {
        if (CustomInputSystem.horizontal != 0) movement.MoveHorizontaly(CustomInputSystem.horizontal);
        else if (CustomInputSystem.vertical != 0) movement.MoveVertically(CustomInputSystem.vertical);

        if(CustomInputSystem.action)
        {
            if(!reloading)
            {
                Instantiate(bomb, transform.position, transform.rotation, transform.parent);
                StartCoroutine(Reload());
            } 
        }    
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}
