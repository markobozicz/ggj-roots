using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerScript : MonoBehaviour
{
    public int MoveSpeed = 4;
    public int noticed_range = 10;
    public int chase_range = 20;
    public bool player_chasing = false;

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

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
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        noticed_range = 15;
        player_chasing = true;
    }


}
