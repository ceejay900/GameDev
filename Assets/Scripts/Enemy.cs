using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform[] wayPoint;
    int wayPointIndex = 0;
    public float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        //check the position and distance of our waypoints
        if (Vector3.Distance(transform.position, wayPoint[wayPointIndex].transform.position) < .1f)
        {
            wayPointIndex++;
            if (wayPointIndex >= wayPoint.Length)
            {
                wayPointIndex = 0;
            }
        }
        //move the game object to the assign waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPoint[wayPointIndex].transform.position, speed * Time.deltaTime);
    }
    // get called if the enemy and player get collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checking the gameObject with "Player" Tag!
        if (collision.gameObject.CompareTag("Player"))
        {
            //retrieving GameOver from PlayerMove when collision trigger!
            collision.gameObject.GetComponent<PlayerMove>().GameOver();
        }
    }
}
