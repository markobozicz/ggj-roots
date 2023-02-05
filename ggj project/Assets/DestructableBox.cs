using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class DestructableBox : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(KeyCode.LeftShift) && collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
