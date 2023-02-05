using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class DestructableBox : MonoBehaviour
{
    public BaseCharacterController speed_script;

    private void OnCollisionEnter(Collision collision)
    {
        if (speed_script._speed >= 13 && collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
