using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirechecker : MonoBehaviour
{
    public bool tirecheck = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            tirecheck = true;
        }
    }

}
