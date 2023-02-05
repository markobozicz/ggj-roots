using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public GameObject collecatble;
    private WaterCounter collectable_script;
    // Start is called before the first frame update
    void Start()
    {
        collectable_script = collecatble.GetComponent<WaterCounter>();
    }
    //private void OnTriggerEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        GameObject.Destroy(gameObject);
    //        collectable_script.water_counter++;
    //        Debug.Log("Water counter: " + collectable_script.water_counter);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
            collectable_script.water_counter++;
            Debug.Log("Water counter: " + collectable_script.water_counter);
            FindObjectOfType<playerSounds>().waterSound.Play();
        }
    }
}
