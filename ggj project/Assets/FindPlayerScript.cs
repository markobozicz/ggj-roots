using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerScript : MonoBehaviour
{
    public int MoveSpeed = 4;
    public int noticed_range = 10;
    public int chase_range = 20;
    public bool player_chasing = false;
    public int rabbit_speed = 2;
    private Vector3 jump;
    public float jump_height = 4.5f;
    private bool isGrounded = false;

    Rigidbody rb;
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jump_height, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= noticed_range)
        {
            Chase();
        }
        else
        {
            noticed_range = 10;
            player_chasing = false;
        }
    }

    private void Chase()
    {
        transform.position += transform.forward * rabbit_speed * Time.deltaTime;
        noticed_range = 15;
        player_chasing = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
        if (player_chasing && collision.gameObject.tag == "Fence" && isGrounded)
        {
            rb.AddForce(jump * 2, ForceMode.Impulse);
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Player")
        {
            rabbit_speed = 0;
        }
    }
}
