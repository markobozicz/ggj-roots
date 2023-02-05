using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireJump : MonoBehaviour
{
    private Transform Player;
    Rigidbody rb;
    private bool tf = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = Player.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (tf) rb.AddForce(Vector3.up * 70, ForceMode.Impulse);
        if (Player.transform.position.y - transform.position.y >= 0.5 && Player.transform.position.y - transform.position.y <= 0.6)
        {
            rb.AddForce(Vector3.up * -70, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            tf = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tf = false;
        }
    }
}
