using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //How long the screen takes to fade to black.
    public GameObject player; //The game will only end if John Lemon himself enters the trigger collider.
    public CanvasGroup exitBackgroundImageCanvasGroup; //Reference to the UI (Canvas)

    bool m_IsPlayerAtExit; //This boolean is a way to know when to start fading the UI
    float m_Timer; //A timer is needed to ensure that the game doesn't end before the fade is completed.

    void OnTriigerEnter(Collider other)
    {
        //To check that John Lemon is what/who collided with the trigger.
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    //Checks if John Lemon is has reached the end of the level (by touching the trigger)
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    //Fades the screen then quits the game
    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
    }
}
