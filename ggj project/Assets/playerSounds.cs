using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds : MonoBehaviour
{
    public AudioSource walking;
    public AudioSource jumpSound;
    public AudioSource ouchSound;
    public AudioSource pickSound;
    public AudioSource placeSound;
    public AudioSource groundedSound;
    public AudioSource unGroundedSound;
    public AudioSource rotatingSound;
    public AudioSource waterSound;

    public AudioSource posterDestroy;
    public AudioSource crunchSound;
    public AudioSource woodExplosion;
    
    


    public void PlayJumpSound()
    {
        jumpSound.Play();
    }

    public void PlayOuchSound()
    {
        ouchSound.Play();
    }
    public void PlayPickSound()
    {
        pickSound.Play();
    }
    public void PlayPlaceSound()
    {
        placeSound.Play();
    }


    public void PlayWalkingLoop(bool play)
    {
        if (play)
        {
            if (walking.isPlaying == false)
            {
                walking.Play();
            }
        }
        else
        {
            if (walking.isPlaying == true)
            {
                walking.Stop();
            }
        }
    }
    public void PlayRotationLoop(bool play)
    {
        if (play)
        {
            if (rotatingSound.isPlaying == false)
            {
                rotatingSound.Play();
            }
        }
        else
        {
            if (rotatingSound.isPlaying == true)
            {
                rotatingSound.Stop();
            }
        }
    }

}
