using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;

public class CheckSpeed : MonoBehaviour
{
    public GameObject speed;
    private BaseCharacterController speed_script;
    // Start is called before the first frame update
    void Start()
    {
        speed_script = speed.GetComponent<BaseCharacterController>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (speed_script._speed == 10 || speed_script._speed == 30 || speed_script._speed == 20)
        {
            GameObject.Destroy(gameObject);
            ;
        }
    }
}
