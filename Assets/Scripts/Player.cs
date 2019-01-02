using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal, vertical;
    public float Player_Speed;  //控制玩家移动的参数
    public Rigidbody2D PlayerRb;
    public Transform player;    //获取玩家Rigidbody和transform
    private Bullets bullets;    //获取Bullets
    private float ShootCD=0.5f; 
    private float ShootCDTimer;      //攻击时间间隔
    public int CurrentHealth, damage=1,MaxHealth;
    public GameObject DeadUI;
    public Animator anim;
    public AudioSource aud;
    


    void Start()
    {
        bullets = GameObject.FindGameObjectWithTag("Bullets").GetComponent<Bullets>();
        CurrentHealth = MaxHealth;
        DeadUI.SetActive(false);
    }

    void Update()
    {
        Move();
        Shoot();
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            DeadUI.SetActive(true);
            Debug.Log("YOU DIED");
        }//生命值为零时，消灭玩家，游戏结束
    }
    private void Move()//移动脚本
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        PlayerRb.velocity = new Vector2(horizontal * Player_Speed, vertical * Player_Speed);
    }

    void Shoot()//射击脚本
    {
        if (ShootCDTimer < 0)
            ShootCDTimer = 0;
        else if (ShootCDTimer == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Instantiate(bullets.BulletPrefabs[0], this.transform.position, Quaternion.identity);
                ShootCDTimer = ShootCD;
                aud.Play();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Instantiate(bullets.BulletPrefabs[1], this.transform.position, Quaternion.identity);
                ShootCDTimer = ShootCD;
                aud.Play();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Instantiate(bullets.BulletPrefabs[2], this.transform.position, Quaternion.identity);
                ShootCDTimer = ShootCD;
                aud.Play();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(bullets.BulletPrefabs[3], this.transform.position, Quaternion.identity);
                ShootCDTimer = ShootCD;
                aud.Play();
            }
        }
        else ShootCDTimer -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision) //收到伤害掉血
    {
        
        if (collision.tag=="Enemy")
        { 
            CurrentHealth -= damage;
            Destroy(collision.gameObject);
            anim.SetTrigger("Hurt");
        }
        if(collision.tag=="HP")
        {
            if(CurrentHealth<MaxHealth)
                CurrentHealth++;
            Debug.Log("HP");
            Destroy(collision.gameObject);
        }
    }
}
