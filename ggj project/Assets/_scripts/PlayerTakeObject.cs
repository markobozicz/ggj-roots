using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ECM.Controllers;
public class PlayerTakeObject : MonoBehaviour
{
    public CarrotPowerUps carrotPowerups;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TakeableObject>().isTakeable)
        {
            carrotPowerups.SetPickableObject(collision.gameObject.GetComponent<TakeableObject>());

        }
    }
    public void SetTakeable(TakeableObject obj)
    {
        carrotPowerups.SetPickableObject(obj);
    }

    public void Unset()
    {
        carrotPowerups.UnsetPickableObj();

    }

    public void Jump()
    {
        Debug.LogError("ajde");
        carrotPowerups.GetComponent<BaseFirstPersonController>().PublicJump();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<TakeableObject>().isTakeable)
    //    {
    //        carrotPowerups.SetPickableObject(other.gameObject.GetComponent<TakeableObject>());

    //    }

    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<TakeableObject>().isTakeable)
    //    {
    //        carrotPowerups.UnsetPickableObj();

    //    }

    //}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<TakeableObject>().isTakeable)
        {
            carrotPowerups.UnsetPickableObj();

        }

    }
}
