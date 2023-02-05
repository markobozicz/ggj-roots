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

    public bool isRunning;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SetLean();
            playerSounds.PlayWalkingLoop(true);
            walkParticles.Play();
            if (isRunning == false)
            {
                isRunning = true;
                if (FindObjectOfType<CarrotPowerUps>().isRotating == false)
                {
                    FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("run");
                }
            }

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            walkParticles.Clear();
            walkParticles.Pause();

            isRunning = false;
            if (FindObjectOfType<CarrotPowerUps>().isRotating == false)
            {
            FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("idle");
            }

            playerSounds.PlayWalkingLoop(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FindObjectOfType<CarrotPowerUps>().isRotating == false)
            {
            FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("jump");
            }
            playerSounds.PlayJumpSound();
            playerSounds.PlayWalkingLoop(false);
            Invoke("DeactivateJump", .7f);
            FindObjectOfType<particlesPlayer>().jumpParticles.Play();
            Invoke("DeactivateJumpParticles", .8f);

        }
    }
    private void DeactivateJumpParticles()
    {
        if (isRunning)
        {
            FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("run");

        }
        else
        {
            FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("idle");

        }
        FindObjectOfType<particlesPlayer>().jumpParticles.Clear();
        //FindObjectOfType<particlesPlayer>().jumpParticles.Pause();

    }

    private void DeactivateJump()
    {

        FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("idle");
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
