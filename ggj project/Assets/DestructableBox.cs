using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class DestructableBox : MonoBehaviour
{

    public GameObject destroyParticles;
    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(KeyCode.LeftShift) && collision.gameObject.tag == "Player")
        {
            FindObjectOfType<playerSounds>().woodExplosion.Play();
            Vector3 pos = transform.position;
            Instantiate(destroyParticles, pos, Quaternion.identity);
            GameObject.Destroy(gameObject);
            pos.y += 2;
        }
    }
}
