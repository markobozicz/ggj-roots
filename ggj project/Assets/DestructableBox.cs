using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
