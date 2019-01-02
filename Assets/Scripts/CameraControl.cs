using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Target;//指玩家所处房间
    public Transform player;
    public Transform center;
    private RoomTemplates templates;

    public GameObject enemy;
    private float randx,randy;
    private int EnemyNumber=4;
    private int[] IsEnemySpawned = new int[100];

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
    }

    void Update()
    {
        for (int i = 0; i < templates.rooms.Count; i++)
        {
            center.position = templates.rooms[i].transform.position + new Vector3(9.74f, 3.2f, -10);
            //float Distance = Vector2.Distance(player.position, center.position);
            if (Mathf.Abs(player.position.x-center.position.x)<8&& Mathf.Abs(player.position.y - center.position.y) < 8)
            {
                transform.Translate((center.position - transform.position) * Time.deltaTime * 5);
                if (i!=0&&(IsEnemySpawned[i] != 1))
                {
                    for (int j = 0; j < EnemyNumber; j++)
                    {
                        randx = Random.Range(-7, 7);
                        randy = Random.Range(-7, 7);
                        Instantiate(enemy, center.transform.position + new Vector3(randx, randy, -center.transform.position.z), Quaternion.identity);
                        Debug.Log("EnemySpawned");
                    }
                    IsEnemySpawned[i] = 1;
                }
            }
        }
        
    }
    

}
