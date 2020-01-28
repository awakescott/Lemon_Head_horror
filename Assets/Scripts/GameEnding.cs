using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //How long it takes for the gameover screen to fade in.
    public float displayImageDuration = 1f; //How long the gameover screen displays before the game actually ends.
    public GameObject player; //The game will only end if John Lemon himself enters the trigger collider.
    public CanvasGroup exitBackgroundImageCanvasGroup; //Reference to the UI (Canvas)
    public AudioSource exitAudio, caughtAudio;

    bool m_IsPlayerAtExit; //This boolean is a way to know when to start fading the UI
    float m_Timer; //A timer is needed to ensure that the game doesn't end before the fade is completed.
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other)
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
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
    }

    //Fades the screen then quits the game
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit(); //Reminder: This only works when playing the built version of the game (doesn't stop play mode in the editor).
        }
    }
}
