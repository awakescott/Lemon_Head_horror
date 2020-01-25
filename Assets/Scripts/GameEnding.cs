using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //How long the screen takes to fade to black.
    public GameObject player; //The game will only end if John Lemon himself enters the trigger collider.

    void OnTriigerEnter(Collider other)
    {
        //To check that John Lemon is what/who collided with the trigger.
        if(other.gameObject == player)
        {

        }
    }
}
