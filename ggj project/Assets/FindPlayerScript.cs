using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerScript : MonoBehaviour
{
    public Animator animator;
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

    public Transform particlePosition;

    void Start()
    {
        animator.ResetTrigger("idle");
        animator.ResetTrigger("attack");
        animator.ResetTrigger("jump");
        animator.ResetTrigger("run");
        // idle animation
        animator.SetTrigger("idle");


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

        if (Vector3.Distance(transform.position, Player.position) <= noticed_range)
        {
            Chase();
        }
        else
        {
            //idle 
            animator.ResetTrigger("idle");
            animator.ResetTrigger("attack");
            animator.ResetTrigger("jump");
            animator.ResetTrigger("run");
            animator.SetTrigger("idle");
            noticed_range = 10;
            player_chasing = false;
        }
    }

    private void Chase()
    {
        if (udarioPlayera == false)
        {
            // run animation
            animator.ResetTrigger("idle");
            animator.ResetTrigger("attack");
            animator.ResetTrigger("jump");
            animator.ResetTrigger("run");
            animator.SetTrigger("run");
            Vector3 forward = transform.forward;
            forward.y = 0;
            transform.position += forward * rabbit_speed * Time.deltaTime;
            noticed_range = 15;
            player_chasing = true;

        }
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
            FindObjectOfType<particlesPlayer>().deathParticles.Play();
            FindObjectOfType<playerSounds>().crunchSound.Play();
            TakeLife();
        }
    }
    private void Jump()
    {
        // jump
        animator.ResetTrigger("idle");
        animator.ResetTrigger("attack");
        animator.ResetTrigger("jump");
        animator.ResetTrigger("run");
        animator.SetTrigger("jump");
        rb.AddForce(jump * 2, ForceMode.Impulse);
        isgrounded = false;

    }
    public bool udarioPlayera;
    private void TakeLife()
    {
            GameObject objToIns = FindObjectOfType<particlesPlayer>().attackParticli;
            Instantiate(objToIns, particlePosition.position, Quaternion.identity);
            Destroy(GameObject.Find("mrkva karakter"));
            Destroy(FindObjectOfType<PlayerAnimationControler>());
        if (udarioPlayera == false)
        {
            udarioPlayera = true;
            // zvekanje
            animator.ResetTrigger("idle");
            animator.ResetTrigger("attack");
            animator.ResetTrigger("jump");
            animator.ResetTrigger("run");
            animator.SetTrigger("attack");
            health_script.healthCounter--;
            //Player.position = new Vector3(0, 0, 0);
            Debug.Log("Health: " + health_script.healthCounter);

            Invoke("ResetTriggers", 1f);

        }


    }

    public void ResetTriggers()
    {

        animator.ResetTrigger("idle");
        animator.ResetTrigger("attack");
        animator.ResetTrigger("jump");
        animator.ResetTrigger("run");
        animator.SetTrigger("idle");
    }
}
