using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FIMSpace;

public class CarrotLeanController : MonoBehaviour
{
    public LeaningAnimator ManualInformLeaning;
    public float currentSpeed;
    public float acceleration;
    public float speedRamp;
    public playerSounds playerSounds;
    public ParticleSystem walkParticles;



    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SetLean();
            playerSounds.PlayWalkingLoop(true);
            walkParticles.Play();

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            walkParticles.Clear();
            walkParticles.Pause();
            playerSounds.PlayWalkingLoop(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSounds.PlayJumpSound();
            playerSounds.PlayWalkingLoop(false);

        }
    }
    public void SetLean()
    {
        if (ManualInformLeaning)
        {
            if (currentSpeed < speedRamp)
            {
                currentSpeed += acceleration * Time.deltaTime;
                ManualInformLeaning.SetIsAccelerating = true;
            }
            else
            {
                ManualInformLeaning.SetIsAccelerating = false;
            }

        }

    }
        
}
