using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 for top door
    //2 for right door
    //3 for bottom door
    //4 for left door

    private RoomTemplates templates;
    private int rand;
    private bool Spawned = false;
 

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {
        if (Spawned == false)
        {
            if (openingDirection == 1)
            {
                //need a room with a top door;
                rand = Random.Range(0, templates.TopRooms.Length);
                Instantiate(templates.TopRooms[rand], transform.position - new Vector3(9.74f, 2.8f, 0), templates.TopRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //need a room with a right door;
                rand = Random.Range(0, templates.RightRooms.Length);
                Instantiate(templates.RightRooms[rand], transform.position - new Vector3(8.24f, 3.2f, 0), templates.RightRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //need a room with a bottom door;
                rand = Random.Range(0, templates.BottomRooms.Length);
                Instantiate(templates.BottomRooms[rand], transform.position - new Vector3(9.74f, 3.2f, 0), templates.BottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //need a room with a left door;
                rand = Random.Range(0, templates.LeftRooms.Length);
                Instantiate(templates.LeftRooms[rand], transform.position - new Vector3(9.74f, 3.2f, 0), templates.LeftRooms[rand].transform.rotation);
            }
            Spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("RoomSpawnPoints"))
        {
            if (other.GetComponent<RoomSpawner>().Spawned==false&&Spawned==false&& other.GetComponent<RoomSpawner>().openingDirection !=0)
            {
                
                if (openingDirection == 1)
                    Instantiate(templates.ClosedRooms, transform.position - new Vector3(9.74f, 2.8f, 0), Quaternion.identity);
                else if (openingDirection == 2)
                    Instantiate(templates.ClosedRooms, transform.position - new Vector3(8.24f, 3.2f, 0), Quaternion.identity);
                else if (openingDirection == 3)
                    Instantiate(templates.ClosedRooms, transform.position - new Vector3(9.74f, 3.2f, 0), Quaternion.identity);
                else if (openingDirection == 4)
                    Instantiate(templates.ClosedRooms, transform.position - new Vector3(9.74f, 3.2f, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            
            Spawned = true;
        }
    }
}
