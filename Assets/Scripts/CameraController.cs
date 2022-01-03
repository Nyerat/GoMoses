using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject cameraTrack;

    private Vector3 lastPlayerPos;
    private float distanceToMove;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = cameraTrack.transform.position.x - lastPlayerPos.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPos = cameraTrack.transform.position;
    }
}
