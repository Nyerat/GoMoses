using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    public GameObject room;
    public Transform genPoint;
    public float distanceBetween;

    private float groundWidth;

    public ObjectPooler theObjectPool;

    public EnemyGenerator theEnemyGenerator;

    // Start is called before the first frame update
    void Start()
    {
        //groundWidth = room.GetComponent<BoxCollider2D>().size.x;

        theEnemyGenerator = FindObjectOfType<EnemyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < genPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);
            //Instantiate(room, transform.position, transform.rotation);

            GameObject newRoom = theObjectPool.GetPooledObject();

            newRoom.transform.position = transform.position;
            newRoom.transform.rotation = transform.rotation;
            newRoom.SetActive(true);

            
        }
    }
    
    //Future use to better customize rooms when spawns
    void CreateRoom()
    {

    }
}
