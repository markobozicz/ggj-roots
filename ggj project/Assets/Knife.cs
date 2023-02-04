using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class Knife : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerTakeObject>())
        {
            //Debug.LogError("noz udara");
            //other.gameObject.GetComponent<PlayerTakeObject>().Jump();
            //GetComponent<Animator>().SetTrigger("udarac");
        }
    }

}
