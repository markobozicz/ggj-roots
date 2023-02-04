using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerScript : MonoBehaviour
{
    public int noticed_range = 10;
    public bool player_chasing = false;
    public float rabbit_speed = 7f;
    private Vector3 jump;
    public float jump_height = 4.5f;
    private bool isgrounded = true;

    Rigidbody rb;
    private Transform Player;
    public GameObject health;
    private HealthCounterScript health_script;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jump_height, 0.0f);
        health_script = health.GetComponent<HealthCounterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        float y_difference = Mathf.Abs(transform.position.y - Player.position.y);

        if (Vector3.Distance(transform.position, Player.position) <= noticed_range && y_difference<=4.4)
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
        Vector3 forward = transform.forward;
        forward.y = 0;
        transform.position += forward * rabbit_speed * Time.deltaTime;
        noticed_range = 15;
        player_chasing = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Ground") isgrounded = true;

            else if (player_chasing && collision.gameObject.tag == "Fence" && isgrounded) Jump();

            else if (collision.gameObject.tag == "Box")
            {
                Vector3 forward = transform.forward;
                transform.LookAt(Player);
            }

        }
        else
        {
            TakeLife();
        }
    }
    private void Jump()
    {
        rb.AddForce(jump * 2, ForceMode.Impulse);
        isgrounded = false;

    }
    private void TakeLife()
    {
        health_script.healthCounter--;
        Player.position = new Vector3(0, 0, 0);
    }
}
