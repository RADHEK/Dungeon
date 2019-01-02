using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    public Rigidbody2D enemyRb;
    public Vector2 PatrolA, PatrolB,Target;
    public float Distance, ChaseDistance, EnemyMoveSpeed;
    public int health,damage;
    public bool IsDead = false;
    public Animator anim;
    private int rand;
    public GameObject HP;


    void Start()
    {
        Target = PatrolA;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        /*
        Distance = Vector2.Distance(player.transform.position, enemy.transform.position);//获取和玩家之间的距离
        if (Distance < ChaseDistance)
            Chase();
        else Patrol();
        */
        Chase();
        if (health <= 0)
        {
            rand = Random.Range(0, 5);
            if(rand==1)
                Instantiate(HP, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Enemy Down");
        }//生命值为零时，消除目标敌人
    }

    /*
    private void Patrol()
    {
        if (Vector2.Distance(Target, enemy.transform.position) > 0.001 || Vector2.Distance(Target, enemy.transform.position) == 0)
        {
            enemy.transform.position = Vector2.MoveTowards(transform.position, Target, EnemyMoveSpeed * Time.deltaTime);
            if (Vector2.Distance(Target, enemy.transform.position) < 0.001)
            {
                if (Target == PatrolA)
                    Target = PatrolB;
                else Target = PatrolA;

            }
        }
    }
    */
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemyMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            health -= damage;
            //anim.SetTrigger("EnemyHurt");
            Debug.Log("hurt!");
            
        }
    }


}
