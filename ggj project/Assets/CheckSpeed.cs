using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class CheckSpeed : MonoBehaviour
{
    public BaseCharacterController speed_script;
    public PosterCounter poster_counter_script;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (speed_script._speed >= 13 && collision.gameObject.tag == "Player")
        {
            poster_counter_script.poster_counter+=1;
            Debug.Log("Poster counter: " + poster_counter_script.poster_counter);
            GameObject.Destroy(gameObject);
        }
    }
}
