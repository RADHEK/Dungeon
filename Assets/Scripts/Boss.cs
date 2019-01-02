using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    public Rigidbody2D enemyRb;

    public float EnemyMoveSpeed;
    public int health, damage;
    public bool IsDead = false;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Chase();
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemyMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            health -= damage;
    }


}
