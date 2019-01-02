using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] TopRooms;
    public GameObject[] RightRooms;
    public GameObject[] BottomRooms;
    public GameObject[] LeftRooms;

    public GameObject ClosedRooms;
    public List<GameObject> rooms;

    public float BossTime;
    public bool BossSpawned=false;
    public GameObject Boss;

    void Update()
    {
        if (BossTime <= 0 && BossSpawned == false)
        { for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(Boss, rooms[i].transform.position+new Vector3(9.74f, 3.2f, 0), Quaternion.identity);
                    BossSpawned = true;
                    Debug.Log("Boss Spawned");
                }

            }
        } else BossTime -= Time.deltaTime;
                
                    
    }
}
