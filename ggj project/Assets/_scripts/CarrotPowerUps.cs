using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class CarrotPowerUps : MonoBehaviour
{
    public Animator carrotAnimator;
    public float timeInRotation;
    public bool isInGround;
    [Range(0f, 100f)]
    public float speedIncreaserPercent;
    public float fastBeingDuration;
    public bool isFastCurrently;
    public bool couldPickSomething;
    public bool pickedSomething;
    public PlayerTakeObject playerTakeObj;
    public playerSounds playerSounds;
    public ParticleSystem rotationParrticles;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateRotation();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DeactivateRotation();

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInGround)
            {
                DeactivateGrounded();
            }
            else
            {
                ActivateGrounded();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (couldPickSomething)
            {
                PickObject();
            }
            else if(pickedSomething)
            {
                PlacePickedObj();

            }
        }

        
    }

    TakeableObject objToPick;
    public Transform positionToPlacePicked;


    private void PickObject()
    {
        objToPick.GetComponent<Collider>().enabled = false;
        objToPick.gameObject.transform.parent = positionToPlacePicked;
        objToPick.gameObject.transform.position = positionToPlacePicked.position;
        objToPick.GetComponent<Rigidbody>().isKinematic = true;
        pickedSomething = true;
        playerSounds.pickSound.Play();
        couldPickSomething = false;
    }

    private void PlacePickedObj()
    {
        objToPick.gameObject.transform.parent = null;
        objToPick.GetComponent<Rigidbody>().isKinematic = false;
        pickedSomething = false;
        playerSounds.placeSound.Play();
        objToPick.GetComponent<Collider>().enabled = true;
        playerTakeObj.gameObject.SetActive(false);
        Invoke("ActivatePlayerTakeObj", 1f);

    }
    private void ActivatePlayerTakeObj()
    {
        playerTakeObj.gameObject.SetActive(true);

    }


    public void SetPickableObject(TakeableObject objectToPick)
    {
        if (pickedSomething == false)
        {
            objToPick = objectToPick;
            couldPickSomething = true;

        }
    }

    public void UnsetPickableObj()
    {
        objToPick = null;
        couldPickSomething = false;

    }
    float tempSpeed;
    BaseFirstPersonController fpc;

    private void OnEnable()
    {
        fpc = GetComponent<BaseFirstPersonController>();
    }




    public void SetToFast()
    {
        tempSpeed = fpc._forwardSpeed;
        fpc._forwardSpeed += fpc._forwardSpeed / 100 * speedIncreaserPercent;
        isFastCurrently = true;
        Invoke("SetToSlow", fastBeingDuration);
    }

    public void SetToSlow()
    {
        fpc = GetComponent<BaseFirstPersonController>();
        fpc._forwardSpeed = tempSpeed;
        isFastCurrently = false;

    }

    public void ActivateGrounded()
    {
        playerSounds.groundedSound.Play();
        if (carrotAnimator)
        {
            carrotAnimator.SetTrigger("grounded");
        }

    }
    public void DeactivateGrounded()
    {
        playerSounds.unGroundedSound.Play();
        if (carrotAnimator)
        {
            carrotAnimator.SetTrigger("grounded");
        }

    }
    public bool isRotating;
    public void ActivateRotation()
    {
        isRotating = true;
        playerSounds.rotatingSound.Play();
        rotationParrticles.Play();
        FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("spin");
        //Invoke("DeactivateRotation", timeInRotation);

        //if (carrotAnimator && isRotating == false)
        //{
        //    carrotAnimator.SetTrigger("rotating");
        //}

    }
    public void DeactivateRotation()
    {
        if (isRotating == true)
        {
            isRotating = false;
            rotationParrticles.Clear();
            rotationParrticles.Pause();
            if (carrotAnimator)
            {
                if (FindObjectOfType<CarrotLeanController>().isRunning)
                {
                FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("run");

                }
                else
                {

                    FindObjectOfType<PlayerAnimationControler>().animatorComponent.SetTrigger("idle");
                }
                carrotAnimator.ResetTrigger("rotating");
            }

        }

    }
}
