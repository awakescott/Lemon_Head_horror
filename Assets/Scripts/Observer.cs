using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool isPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            isPlayerInRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
            Debug.Log("Player lost");
        }
    }

    void Update()
    {
        if(isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    //gameEnding.CaughtPlayer();
                    Debug.Log("Player caught");
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
