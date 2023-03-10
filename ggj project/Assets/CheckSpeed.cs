using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class CheckSpeed : MonoBehaviour
{
    public PosterCounter poster_counter_script;

    public GameObject destroyParticles;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(KeyCode.LeftShift) && collision.gameObject.tag == "Player")
        {
            Instantiate(destroyParticles, transform.position, Quaternion.identity);
            FindObjectOfType<playerSounds>().posterDestroy.Play();
            GameObject.Destroy(gameObject);
            poster_counter_script.poster_counter+=1;
            Debug.Log("Poster counter: " + poster_counter_script.poster_counter);
        }
    }
}
