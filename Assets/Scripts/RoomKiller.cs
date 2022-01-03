using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomKiller : MonoBehaviour
{
    public GameObject killPoint;

    // Start is called before the first frame update
    void Start()
    {
        killPoint = GameObject.Find("RoomKillPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < killPoint.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
