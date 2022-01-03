using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float yDegreeSnap;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(transform.position.x, yDegreeSnap, transform.position.z);

        //switch (hazardType)
        //{
        //    case "Ground":
        //        transform.position = new Vector3(SpawnPoints[2].transform.position.x, SpawnPoints[2].transform.position.y, SpawnPoints[2].transform.position.z);
        //        break;
        //    case "Floor":
        //        transform.position = new Vector3(SpawnPoints[1].transform.position.x, SpawnPoints[1].transform.position.y, SpawnPoints[1].transform.position.z);
        //        break;
        //    case "Ceiling":
        //        transform.position = new Vector3(SpawnPoints[0].transform.position.x, SpawnPoints[0].transform.position.y, SpawnPoints[0].transform.position.z);
        //        break;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
