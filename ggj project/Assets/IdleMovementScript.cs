using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovementScript : MonoBehaviour
{
    private Transform Player;
    private Vector3 targetPoint;
    private Rigidbody rb;
    public float man_speed = 1.25f;
    public float start_point;
    public float end_point;
    public int noticed_range;
    public float direction_point;
    public float idle_range;
    public float patrol_length;

    public enum State { GoingToStart, GoingToEnd, Chasing };
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody>();

        start_point = transform.position.x - patrol_length;
        end_point = transform.position.x + patrol_length;
    }

    bool IsInRange(Vector3 target, float range)
    {
        return Vector3.Distance(transform.position, target) <= range;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Chasing)
            targetPoint = Player.position;
        else if (state == State.GoingToStart)
            targetPoint = new Vector3(start_point, transform.position.y, transform.position.z);
        else
            targetPoint = new Vector3(end_point, transform.position.y, transform.position.z);

        transform.rotation = Quaternion.LookRotation(targetPoint - transform.position);
        transform.position += transform.forward * man_speed * Time.deltaTime;


        if (state != State.Chasing)
        {

            if (IsInRange(Player.position, noticed_range))
                state = State.Chasing;

            else if (IsInRange(targetPoint, idle_range))
                state = state == State.GoingToStart ? State.GoingToEnd : State.GoingToStart;
        }
        else
        {
            if (!IsInRange(Player.position, noticed_range * 1.2f))
                state = Random.value > 0.5f ? State.GoingToStart : State.GoingToEnd;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        man_speed = 0;
    }
}

