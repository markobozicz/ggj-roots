using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grablje : MonoBehaviour
{
    public int bumperForce = 800;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerTakeObject>())
        {
            //other.gameObject.GetComponent<PlayerTakeObject>().carrotPowerups.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
            //GetComponent<Animator>().SetTrigger("udarac");
            //Debug.LogError("grablje udaraju");
        }
    }


}
