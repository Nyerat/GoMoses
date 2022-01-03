using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStats : MonoBehaviour
{
    public float enemyDamageDealt;
    public float enemyHitPoints;
    public float monsterMovementSpeed;

    private Rigidbody2D rb2d;
    public GameObject killPoint;
    public PlayerController playerController;
    

    public bool[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        killPoint = GameObject.Find("EnemyKillPoint");
        rb2d = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterMovementSpeed != 0)
        {
            rb2d.velocity = new Vector2(monsterMovementSpeed, rb2d.velocity.y);
        }

        if (transform.position.x < killPoint.transform.position.x)
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {

        playerController.scoreAddFromEnemyDying();
        Destroy(gameObject);
    }
    
}
