using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject[] BulletPrefabs;
    //element 0 is up
    //element 1 is left
    //element 2 is down
    //element 3 is right
    public int Direction;

    public float speed = 4f;
    public Rigidbody2D rb;

    void Start()
    {
        switch (Direction)
        {
            case 0:
                {
                    rb.velocity = transform.up * speed;
                    break;
                }
            case 1:
                {
                    rb.velocity = transform.right * speed;
                    break;
                }
            case 2:
                {
                    rb.velocity = -transform.up * speed;
                    break;
                }
            case 3:
                {
                    rb.velocity = -transform.right * speed;
                    break;
                }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.CompareTag("Walls"))||collision.CompareTag("Enemy")|| collision.CompareTag("Boss"))
        Destroy(this.gameObject);
    }



}
