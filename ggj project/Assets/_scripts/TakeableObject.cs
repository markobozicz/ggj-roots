using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeableObject : MonoBehaviour
{
    public bool isTakeable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerTakeObject>())
        {
            other.gameObject.GetComponent<PlayerTakeObject>().SetTakeable(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerTakeObject>())
        {
            other.gameObject.GetComponent<PlayerTakeObject>().Unset();
        }

    }
}
